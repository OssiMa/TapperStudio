using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkinInventory : MonoBehaviour {

    SkinInventory skinInventory;

    SkinSlot[] slots;

    List<Skin> shownSkins;

    public int instrumentToLook = 1;
    public int slotToLook = 1;

    int maxSkins;

    // Use this for initialization
    void Start ()
    {
        skinInventory.onSkinsChangedCallback += WhatIsShown;
        //skinInventory.onSkinsChangedCallback += PageUpdate;
        skinInventory.onSkinsChangedCallback += UpdateUI;

        slots = GetComponentsInChildren<SkinSlot>();
        shownSkins = new List<Skin>();
        skinInventory.onSkinsChangedCallback.Invoke();
    }

    public void SetInstrument(int x)
    {
        instrumentToLook = x;
        skinInventory.onSkinsChangedCallback.Invoke();
    }

    void WhatIsShown()     //Currently, this adds the skins which correspond to the chosen instrument to the
    {
        shownSkins.Clear();

        for (int i = 0; i < skinInventory.skins.Count; i++)
        {
            if (skinInventory.skins[i].instrument == instrumentToLook)
            {
                shownSkins.Add(skinInventory.skins[i]);
            }
        }
    }

    /*void PageUpdate()
    {
        if (unlockedSkins.Count > slots.Length)
        {
            int i = unlockedSkins.Count;
            while (i > slots.Length)
            {
                i -= slots.Length;
            }
        }

        /*if (page > maxPages)
        {
            page = maxPages;
            print("nope");
        }

        if (page == 1)
        {
            pgBack.interactable = false;
        }
        else
        {
            pgBack.interactable = true;
        }

        if (maxPages > 1 && page != maxPages)
        {
            pgNext.interactable = true;
        }
        else
        {
            pgNext.interactable = false;
        }
        currPage.text = "Page " + page + "/" + maxPages;
    }*/

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)      //This one adds a skin to a slot until the slots are full. 
        {
            if (i < shownSkins.Count)
            {
                slots[i].AddSkin(shownSkins[i]);    //The slots are full. Now, we need to put some sprites on top of those that are not unlocked.
            }

            /*if (shownSkins[i].vintageLock <= MISSINGSCRIPT.vintageLevel)
            {
                //Add sprite on them
            }*/
        }
    }

}
