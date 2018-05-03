using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkinInventory : MonoBehaviour {

    SkinInventory skinInventory;

    SkinSlot[] slots;

    List<Skin> shownSkins;

    [HideInInspector]
    public int instrumentToLook = 1;
    [HideInInspector]
    public int slotToLook = 1;

    int maxSkins;

    // Use this for initialization
    void Start ()
    {
        skinInventory = GameObject.Find("GameManager").GetComponent<SkinInventory>();

        skinInventory.onSkinsChangedCallback += WhatIsShown;
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

    void WhatIsShown()
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

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < shownSkins.Count)
            {
                slots[i].AddSkin(shownSkins[i]);

                if (slots[i].skin.unlocked == false)
                {
                    slots[i].LockSlot();
                }
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    
}
