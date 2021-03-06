﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryUI : MonoBehaviour {

    #region Singleton

    public static InventoryUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Paska koodaaja nyt on 2 inventory UItä");
            return;
        }

        instance = this;
    }

    #endregion

    Inventory inventory;

    InventorySlot chosenSlot;
    InventorySlot[] slots;

    EquipSlot[] equipSlots;

    Item chosenItem;
    Item combineWith;
    List<Item> itemsToShow;
    List<Item> equippedItems;

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
        inventory.onItemChangedCallback += ShowEquipped;
        inventory.onItemChangedCallback += UpdateUI;

        equipSlots = GetComponentsInChildren<EquipSlot>().OrderBy(slots => slots.name).ToArray();
        slots = GetComponentsInChildren<InventorySlot>();
        itemsToShow = new List<Item>();
        equippedItems = new List<Item>();

        for (int i = 0; i < 9; i++)
        {
            equippedItems.Add(null);
        }

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

    void ShowEquipped()
    {
        for (int i = 0; i < equipSlots.Length; i++)
        {
            equipSlots[i].EquipItem(equippedItems[(instrumentToLook - 1) * 3 + i]);        
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
                if (craftInProgress == true && itemsToShow[i+xPage].rarity != chosenItem.rarity )
                {
                    slots[i].CraftingFilter();
                }
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public Item EquipBoosts(int ins, int slot)
    {
        Item x = equippedItems[(ins - 1) * 3 + slot - 1];
        return x;
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

    public void SelectCraftable(InventorySlot chosen)   //used when clicking on items in inventory
    {
        if (craftInProgress == true)
        {
            combineWith = chosen.GetItem();
            print("you chose item to combine with");
        }
        else
        {
            chosenSlot = chosen;
            chosenItem = chosen.GetItem();
            print("you selected an item");
        }
    }

    public void BeginCrafting() //from item inspect, enables crafting mode, inventory selection for item to combine with
    {
        if (chosenItem != null)
        {
            craftInProgress = true;
            print("starting crafting sequence");
            inventory.onItemChangedCallback.Invoke();
            chosenSlot.CraftingFilter();
        }
        else
        {
            print("no item selected");
        }

    }

    public void Crafting()  //Proceeds with the crafting, removing the used items and adding a new one, crafting mode off
    {
        if (combineWith != null)
        {
            print("craft in progress");
            Inventory.instance.RemoveItem(chosenSlot.GetItem());
            Inventory.instance.RemoveItem(combineWith);
            NewItemGenerator.instance.NewCraftedItem(combineWith.rarity + 1, combineWith.slot, combineWith.instrument);
            if (equippedItems.Contains(chosenSlot.GetItem())||equippedItems.Contains(chosenSlot.GetItem()))
            {
                equippedItems[(instrumentToLook - 1) * 3 + slotToLook - 1] = null;
            }
            craftInProgress = false;
            inventory.onItemChangedCallback.Invoke();
            combineWith = null;
            chosenItem = null;
            print("craft succesful");
        }
        else
        {
            print("second item not selected");
        }
        
    }

    public void CancelCrafting()
    {
        if (craftInProgress == true)
        {
            print("cancelling crafting");
            combineWith = null;
            chosenItem = null;
            craftInProgress = false;
            inventory.onItemChangedCallback.Invoke();
        }
        else
        {
            print("crafting is not in progress");
        }

    }

    public void Equip()
    {
        equippedItems[(instrumentToLook-1)*3 + slotToLook - 1] = chosenItem;
        inventory.onItemChangedCallback.Invoke();
        // in statwise
    }


}
