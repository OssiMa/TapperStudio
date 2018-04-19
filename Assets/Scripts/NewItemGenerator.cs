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

    string[] instruments = new string[] {"Drums", "Guitar", "Piano" };
    int rarityVal = 0;                      // rarityval = item rarity?

    void Start()
    {
    }


    public void NewItem()
    {
        item = new Item();
        item.slot = Random.Range(1,4);
        item.instrument = instruments[Random.Range(0, instruments.Length - 1)];
        ItemInstrumentSlot();
        Inventory.instance.AddItem(item);
    }

    void ItemInstrumentSlot()
    {
        if (item.slot == 1)
        {
            item.maxCombo = Random.Range(1,2+rarityVal);
        }
        else if(item.slot == 2)
        {
            item.generationBoost = Random.Range(1,3);                            //Real values here
        }
        else if (item.slot == 3)
        {
            item.xpBoost = Random.Range(1,3);
        }

    }
	
    

}
