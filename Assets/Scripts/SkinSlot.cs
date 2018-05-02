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

        //cb = button.colors;
        cb.normalColor = skin.color;
        //button.colors = cb;

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

    public Skin GetSkin()
    {
        return skin;
    }

}
