using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryUI : MonoBehaviour {



    Inventory inventory;

    InventorySlot chosenSlot;
    InventorySlot[] slots;

    EquipSlot[] equipSlots;
    Toggle[] toggles;

    public Item chosenItem;
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

    int[] availableEquipSlots = new int[3] {1,1,1};

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

        equippedItems = new List<Item>();

        for (int i = 0; i < 9; i++)
        {
            equippedItems.Add(null);
        }

        GameObject tab = GameObject.Find("Tab_Panel");
        toggles = tab.GetComponentsInChildren<Toggle>().OrderBy(toggless => toggless.name).ToArray();
    }

    #endregion


	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += CheckAvailableEquips;
        inventory.onItemChangedCallback += WhatToShow;
        inventory.onItemChangedCallback += PageUpdate;
        inventory.onItemChangedCallback += ShowEquipped;
        inventory.onItemChangedCallback += UpdateUI;

        equipSlots = GetComponentsInChildren<EquipSlot>().OrderBy(slots => slots.name).ToArray();
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
        itemsToShow = itemsToShow.OrderByDescending(items => items.rarity).ToList();

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
                else if(craftInProgress == true && chosenItem == itemsToShow[i+xPage])
                {
                    slots[i].CraftingFilter();
                }
                if (equippedItems.Contains(itemsToShow[i+xPage]))
                {
                    slots[i].Equipped();
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

    public void SelectCraftable(InventorySlot chosen)   //used when clicking on items in inventory (Bad name, I know)
    {
        if (craftInProgress == true)
        {
            combineWith = chosen.GetItem();
        }
        else
        {
            chosenSlot = chosen;
            chosenItem = chosen.GetItem();
        }
    }

    public void BeginCrafting() //from item inspect, enables crafting mode, inventory selection for item to combine with
    {
        if (chosenItem != null)
        {
            craftInProgress = true;
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
            Inventory.instance.RemoveItem(chosenItem);
            Inventory.instance.RemoveItem(combineWith);
            NewItemGenerator.instance.NewCraftedItem(combineWith.rarity + 1, combineWith.slot, combineWith.instrument);
            if (equippedItems.Contains(chosenItem)||equippedItems.Contains(combineWith))
            {
                equippedItems[(instrumentToLook - 1) * 3 + slotToLook - 1] = null;
            }
            craftInProgress = false;
            inventory.onItemChangedCallback.Invoke();
            combineWith = null;
            chosenItem = null;
            chosenSlot = null;
        }
        else
        {
            print("second item not selected");
        }
        
    }

    public void UpgradeItem()
    {
        if (chosenItem != null && chosenItem.level < 3)
        {
            if (CurrencyManager.instance.LoseCurrency(50 * chosenItem.rarity + (chosenItem.level * 15)) == true)
            {
                chosenItem.level += 1;
                inventory.onItemChangedCallback.Invoke();
                chosenItem = null;
                chosenSlot = null;
            }
            else
            {
                print("Not enough currency for upgrade");
            }
        }
        else
        {
            print("no item selected or already at max");
        }
    }

    public void SellItem()
    {
        if (chosenItem != null)
        {
            Inventory.instance.RemoveItem(chosenItem);
            if (equippedItems.Contains(chosenItem))
            {
                equippedItems[(instrumentToLook - 1) * 3 + slotToLook - 1] = null;
            }
            CurrencyManager.instance.AddCurrency(100*chosenItem.rarity+(chosenItem.level*25));                         //BALANCED MONEY SCALING HERE
            inventory.onItemChangedCallback.Invoke();
            chosenItem = null;
            chosenSlot = null;
        }
        else
        {
            print("no item selected");
        }
    }

    public void CancelCrafting()
    {
        if (craftInProgress == true)
        {
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
        if(slotToLook == chosenItem.slot && instrumentToLook == chosenItem.instrument)
        {
            equippedItems[(instrumentToLook - 1) * 3 + slotToLook - 1] = chosenItem;
            inventory.onItemChangedCallback.Invoke();
        }

    }

    public void CheckAvailableEquips()
    {


        if (availableEquipSlots[instrumentToLook - 1] == 1)
        {
            toggles[0].interactable = true;
            toggles[1].interactable = false;
            GameObject icon = toggles[1].transform.Find("Lock").gameObject;
            icon.SetActive(true);
            toggles[2].interactable = false;
            GameObject icon2 = toggles[2].transform.Find("Lock").gameObject;
            icon2.SetActive(true);
            if (slotToLook > 1)
            {
                slotToLook = 1;
                toggles[0].isOn = true;
            }
        }
        else if(availableEquipSlots[instrumentToLook - 1] == 2)
        {
            toggles[0].interactable = true;
            toggles[1].interactable = true;
            GameObject icon = toggles[1].transform.Find("Lock").gameObject;
            icon.SetActive(false);
            toggles[2].interactable = false;
            GameObject icon2 = toggles[2].transform.Find("Lock").gameObject;
            icon2.SetActive(true);
            if (slotToLook > 2)
            {
                slotToLook = 1;
                toggles[0].isOn = true;
            }
        }
        else if(availableEquipSlots[instrumentToLook - 1] == 3)
        {
            toggles[0].interactable = true;
            toggles[1].interactable = true;
            GameObject icon = toggles[1].transform.Find("Lock").gameObject;
            icon.SetActive(false);
            toggles[2].interactable = true;
            GameObject icon2 = toggles[2].transform.Find("Lock").gameObject;
            icon2.SetActive(false);
        }
        else
        {
            print("ny hajos koko paska gg syytä ittees");
        }

    }

    public void GainEquipSlot(InstrumentBase x)
    {
        if (x.gameObject.name == "Drums")
        {
            availableEquipSlots[0] = x.availableSlots;
        }
        else if (x.gameObject.name == "Guitar")
        {
            availableEquipSlots[1] = x.availableSlots;
        }
        else if (x.gameObject.name == "Piano")
        {
            availableEquipSlots[2] = x.availableSlots;
        }
    }

}
