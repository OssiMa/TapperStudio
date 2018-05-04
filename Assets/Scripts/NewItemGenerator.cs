using System.Collections;
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
           

    void Start()
    {
        drums = Resources.LoadAll<Sprite>("DrumIcon");
        guitar = Resources.LoadAll<Sprite>("GuitarIcon");
        piano = Resources.LoadAll<Sprite>("PianoIcon");
    }


    public void NewItem(int rarity)
    {
        item = new Item();
        item.rarity = rarity;
        item.slot = Random.Range(1,4);
        item.instrument = Random.Range(1, 4);
        ItemInstrumentSlot();
        IconChooser();
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
        Inventory.instance.AddItem(item);
    }

    void ItemInstrumentSlot()
    {
        if (item.slot == 1)
        {
            item.generationBoost = item.rarity;                                  // <<<Real values here
            item.boosts = "Passive generation";
        }
        else if(item.slot == 2)
        {           
            item.maxCombo = item.rarity;                                        // <<<Real values here
            item.boosts = "Maximum combo +";
        }
        else if (item.slot == 3)
        {
            item.xpBoost = item.rarity;                                       // <<<Real values here
            item.boosts = "Bonus experience";
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
