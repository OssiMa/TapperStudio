﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;

public class NewItemGenerator : MonoBehaviour {

    [HideInInspector]
    public Item item;

    Sprite[] drums;
    Sprite[] guitar;
    Sprite[] piano;

    String[] drumNames;
    String[] guitarNames;
    String[] pianoNames;
    String[] rarityNames;

    InstrumentBase[] bases;

    #region Singleton

    public static NewItemGenerator instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Paska koodaaja nyt on 2 inventoryy");
            return;
        }
        drums = Resources.LoadAll<Sprite>("DrumIcon");
        guitar = Resources.LoadAll<Sprite>("GuitarIcon");
        piano = Resources.LoadAll<Sprite>("PianoIcon");
        drumNames = new string[] { "Pedal", "Metronome", "Sticks" };
        guitarNames = new string[] { "Guitar1", "Guitar2", "Guitar3" };
        pianoNames = new string[] { "Stool", "Notestand", "Frame" };
        rarityNames = new string[] { "Common", "Uncommon", "Rare", "Epic", "Legendary" };
        bases = FindObjectsOfType<InstrumentBase>().OrderBy(ins => ins.name).ToArray();

        instance = this;
    }

    #endregion


    public void NewItem(int rarity)     // Random item
    {
        item = new Item();
        item.rarity = rarity;
        item.instrument = Random.Range(1, 4);
        item.slot = Random.Range(1, bases[item.instrument-1].availableSlots+1);
        ItemInstrumentSlot();
        IconChooser();
        RarityName();
        Inventory.instance.AddItem(item);
    }

    public void NewCraftedItem(int rarity, int itemSlot, int instrument)
    {
        item = new Item();
        item.rarity = rarity;
        item.slot = itemSlot;
        item.instrument = instrument;
        ItemInstrumentSlot();
        IconChooser();
        RarityName();
        Inventory.instance.AddItem(item);
    }

    void ItemInstrumentSlot()
    {
        if (item.slot == 1)
        {
            item.boosts = "Passive generation";
            item.boostPower = item.rarity;                  //<- Balanced values here 
        }
        else if(item.slot == 2)
        {           
            item.boosts = "Maximum combo +";
            item.boostPower = item.rarity;                  //<- Balanced values here 
        }
        else if (item.slot == 3)
        {
            item.boosts = "Bonus experience";
            item.boostPower = item.rarity;                  //<- Balanced values here 
        }

    }

    void IconChooser()
    {
        if (item.instrument == 1)
        {
            item.icon = drums[item.slot-1];
            item.itemName = drumNames[item.slot-1];
        }
        else if (item.instrument == 2)
        {
            item.icon = guitar[item.slot-1];
            item.itemName = guitarNames[item.slot - 1];
        }
        if (item.instrument == 3)
        {
            item.icon = piano[item.slot-1];
            item.itemName = pianoNames[item.slot - 1];
        }
    }

    void RarityName()
    {
        if(item.rarity < 6)
        {
            item.rarityName = rarityNames[item.rarity - 1];
        }
        else
        {
            item.rarityName = "Legendary +" + (item.rarity-5);
        }
    }
}
