using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour {

    Image icon;

    Button button;
    ColorBlock cb;
    Color buttonColor;

    Skin skin;

    public void AddSkin(Skin newSkin)
    {
        skin = newSkin;

        button = GetComponent<Button>();
        cb = button.colors;
        cb.normalColor = skin.color;
        button.colors = cb;

        icon.sprite = skin.instrumentIcon;
        icon.enabled = true;
        button.interactable = true;
    }

    public void ClearSlot()     //Dunno if this will be even needed
    {
        button = GetComponent<Button>();
        skin = null;

        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
    }

    public Skin GetSkin()
    {
        return skin;
    }

}
