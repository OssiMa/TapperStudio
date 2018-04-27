﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewItemGenerator : MonoBehaviour {


    #region Singleton

    public static NewItemGenerator instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Paska koodaaja nyt on 2 inventoryy");
            return;
        }

        instance = this;
    }

    #endregion


    Item item;

    Sprite[] drums;
    Sprite[] guitar;
    Sprite[] piano;

    int rarityVal = 0;            

    void Start()
    {
        drums = Resources.LoadAll<Sprite>("DrumIcon");
        guitar = Resources.LoadAll<Sprite>("GuitarIcon");
        piano = Resources.LoadAll<Sprite>("PianoIcon");
    }


    public void NewItem(int Rarity)
    {
        item = new Item();
        rarityVal = Rarity;
        item.slot = Random.Range(1,4);
        item.instrument = Random.Range(1, 4);
        ItemInstrumentSlot();
        IconChooser();
        Inventory.instance.AddItem(item);
    }

    void ItemInstrumentSlot()
    {
        if (item.slot == 1)
        {
            item.maxCombo = rarityVal;                                      // <<<Real values here
        }
        else if(item.slot == 2)
        {
            item.generationBoost = rarityVal;                            // <<<Real values here
        }
        else if (item.slot == 3)
        {
            item.xpBoost = rarityVal;                                       // <<<Real values here
        }

    }

    void IconChooser()
    {
        if (item.instrument == 1)
        {
            item.icon = drums[item.slot-1];
        }
        else if (item.instrument == 2)
        {
            item.icon = guitar[item.slot-1];
        }
        if (item.instrument == 3)
        {
            item.icon = piano[item.slot-1];
        }



    }
}