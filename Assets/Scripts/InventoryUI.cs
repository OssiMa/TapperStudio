﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    Inventory inventory;

    InventorySlot chosenSlot;
    InventorySlot[] slots;

    Item combineWith;
    List<Item> itemsToShow;

    public Button pgUp;
    public Button pgDown;
    public Text currPage;

    bool craftInProgress = false;

    public int instrumentToLook = 1;
    public int slotToLook =1;
    public int page = 1;
    public int maxPages = 1;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += WhatToShow;
        inventory.onItemChangedCallback += PageUpdate;
        inventory.onItemChangedCallback += UpdateUI;

        slots = GetComponentsInChildren<InventorySlot>();
        itemsToShow = new List<Item>();
        inventory.onItemChangedCallback.Invoke();
    }
	

    void WhatToShow()
    {
        itemsToShow.Clear();
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.items[i].instrument == instrumentToLook && inventory.items[i].slot == slotToLook)
            {
                itemsToShow.Add(inventory.items[i]);
            }
        }
    }

    void PageUpdate()
    {
        maxPages = 1;
        if (itemsToShow.Count > slots.Length)
        {
            int i = itemsToShow.Count;
            while (i > slots.Length)
            {
                i -= slots.Length;
                maxPages += 1;
            }
        }
        if (page > maxPages)
        {
            page = maxPages;
            print("nope");
        }
        if (page == 1)
        {
            pgDown.interactable = false;
        }
        else
        {
            pgDown.interactable = true;
        }
        if (maxPages > 1 && page != maxPages)
        {
            pgUp.interactable = true;
        }
        else
        {
            pgUp.interactable = false;
        }
        currPage.text = "Page " + page + "/" + maxPages;
    }

    void UpdateUI()
    {
        
        int  xPage = slots.Length * (page - 1);
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < itemsToShow.Count-xPage)
            {
                slots[i].AddItem(itemsToShow[i+xPage]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void SetInstrument(int x)
    {
        instrumentToLook = x;
        inventory.onItemChangedCallback.Invoke();
    }

    public void SetSlotLooker(int x)
    {
        slotToLook = x;
        inventory.onItemChangedCallback.Invoke();
    }

    public void PageUp()
    {
        page += 1;
        inventory.onItemChangedCallback.Invoke();
    }

    public void PageDown()
    {
        page -= 1;
        inventory.onItemChangedCallback.Invoke();
    }

    public void SelectCraftable(InventorySlot chosen)
    {
        if (craftInProgress == true)
        {
            combineWith = chosen.GetItem();
            print("you chose item to combine with");
        }
        else
        {
            chosenSlot = chosen;
            print("you selected an item");
        }
    }

    public void BeginCrafting()
    {
        craftInProgress = true;
        print("starting crafting sequence");
    }

    public void Crafting()
    {
        print("craft in progress");
        Inventory.instance.RemoveItem(chosenSlot.GetItem());
        Inventory.instance.RemoveItem(combineWith);
        NewItemGenerator.instance.NewItem(1);
        craftInProgress = false;
        inventory.onItemChangedCallback.Invoke();
        print("craft succesful");
    }


}