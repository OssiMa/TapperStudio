using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIAchievementInventory : MonoBehaviour {
    Inventory inventory;

    AchievementSlot chosenSlot;
    AchievementSlot[] slots;

    EquipSlot[] equipSlots;

    ScriptableAchievement chosenAchievement;
    List<ScriptableAchievement> AchievementsToShow;
    List<ScriptableAchievement> equippedAchievements;

    public Button pgUp;
    public Button pgDown;
    public Text currPage;

    public int slotToLook = 1;
    public int page = 1;
    public int maxPages = 3;


    // Use this for initialization
    void Start () {
        inventory = Inventory.instance;
        inventory.onAchievementChangedCallback += WhatToShow;
        inventory.onAchievementChangedCallback += PageUpdate;
        inventory.onAchievementChangedCallback += ShowEquipped;
        inventory.onAchievementChangedCallback += UpdateUI;

        equipSlots = GetComponentsInChildren<EquipSlot>().OrderBy(slots => slots.name).ToArray();
        slots = GetComponentsInChildren<AchievementSlot>();
        AchievementsToShow = new List<ScriptableAchievement>();


        inventory.onAchievementChangedCallback.Invoke();
    }

    void WhatToShow()
    {
        AchievementsToShow.Clear();
        for (int i = 0; i < inventory.Achievements.Count; i++)
        {
            if (inventory.Achievements[i].slot == slotToLook)
            {
                AchievementsToShow.Add(inventory.Achievements[i]);
            }
        }
        AchievementsToShow = AchievementsToShow.OrderByDescending(Achievements => Achievements.order).ToList();

    }

    void ShowEquipped()
    {
        for (int i = 0; i < equipSlots.Length; i++)
        {
            equipSlots[i].EquipAchievement(equippedAchievements[i]);
        }
    }

    void PageUpdate()
    {
        maxPages = 3;
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
            if (i < AchievementsToShow.Count-xPage)
            {
                slots[i].AddAchievement(AchievementsToShow[i+xPage]);

            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void PageUp()
    {
        page += 1;
        inventory.onAchievementChangedCallback.Invoke();
    }

    public void PageDown()
    {
        page -= 1;
        inventory.onAchievementChangedCallback.Invoke();
    }
}
