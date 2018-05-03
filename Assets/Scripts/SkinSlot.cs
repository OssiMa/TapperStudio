using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour {

    Image icon;

    Button button;
    ColorBlock cb;
    Color32 buttonColor;

    [HideInInspector]
    public Skin skin;

    public void AddSkin(Skin newSkin)
    {
        icon = GetComponent<Image>();

        skin = newSkin;

        button = GetComponent<Button>();

        cb = button.colors;
        Color32 newColor = skin.color;
        newColor.a = 255;
        cb.normalColor = newColor;
        button.colors = cb;

        icon.sprite = skin.instrumentIcon;
        icon.enabled = true;
        button.interactable = true;
    }

    public void ClearSlot()
    {
        icon = GetComponent<Image>();

        button = GetComponent<Button>();

        //cb = button.colors;
        //cb.normalColor = skin.color;
        //button.colors = cb;

        //icon.sprite = Resources.Load<Sprite>("tab_menubackground");
        //print(icon.sprite);
        button.interactable = false;
    }

    public void LockSlot()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        //If we want to add an extra sprite here, just add a child with the sprite to all slot objects. 
        //When a slot is locked, set the child (or the child's sprite) to true.
    }

    public Skin GetSkin()
    {
        return skin;
    }

}
