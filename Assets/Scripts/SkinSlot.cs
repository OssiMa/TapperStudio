using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour {

    Image icon;
    Image spIcon1;
    Image spIcon2;
    Image spIcon3;
    Image spIcon4;
    Image spIcon5;

    Button button;
    ColorBlock cb;
    //ColorBlock cbOrigin;
    Color32 buttonColor;
    //Color32 originColor;

    [HideInInspector]
    public Skin skin;

    public void AddSkin(Skin newSkin)
    {
        icon = GetComponent<Image>();
        spIcon1 = transform.GetChild(0).GetComponent<Image>();
        spIcon2 = transform.GetChild(1).GetComponent<Image>();
        spIcon3 = transform.GetChild(2).GetComponent<Image>();
        spIcon4 = transform.GetChild(3).GetComponent<Image>();
        spIcon5 = transform.GetChild(4).GetComponent<Image>();

        skin = newSkin;

        button = GetComponent<Button>();

        cb = button.colors;
        Color32 newColor = skin.color;

        if (skin.baseInstrument == false)
        {
            newColor.a = 255;
            newColor.g += 75;
            newColor.b += 75;
        }
        else
        {
            if (skin.instrument == 1 || skin.instrument == 0)
            {
                newColor.r = 19;
                newColor.g = 177;
                newColor.b = 255;
                newColor.a = 255;
            }
            else if (skin.instrument == 2)
            {
                newColor.r = 255;
                newColor.g = 215;
                newColor.b = 146;
                newColor.a = 255;
            }
            else if (skin.instrument == 3)
            {
                newColor.r = 255;
                newColor.g = 255;
                newColor.b = 255;
                newColor.a = 255;
            }
        }
        cb.normalColor = newColor;
        cb.highlightedColor = newColor;
        cb.pressedColor = new Color(0, 0, 0, 255);
        button.colors = cb;

        if (skin.instrument == 1 || skin.instrument == 0)
        {
            spIcon1.color = newColor;
        }
        else if (skin.instrument == 2)
        {
            spIcon2.color = newColor;
            spIcon3.color = newColor;
            spIcon4.color = newColor;
        }
        else if (skin.instrument == 3)
        {
            spIcon1.color = newColor;
            spIcon2.color = newColor;
        }


        if (skin.trinketType != 0)
        {
            spIcon1.sprite = skin.specialIcon1;
            spIcon2.sprite = skin.specialIcon2;
            spIcon3.sprite = skin.specialIcon3;
            spIcon1.enabled = true;
            spIcon2.enabled = true;
            spIcon3.enabled = true;

            print("Yeah, it's" + skin.specialIcon1);

            if (skin.instrument != 3)
            {
                spIcon4.sprite = skin.specialIcon4;
                spIcon5.sprite = skin.specialIcon5;
                spIcon4.enabled = true;
                spIcon5.enabled = true;
            }

            icon.enabled = false;
        }
        else
        {
            if (skin.instrument == 1 || skin.instrument == 0)       //Script not finding skin when starting???
            {
                print("Well?");
                icon.sprite = skin.instrumentIcon;
                icon.enabled = true;

                spIcon1.enabled = false;
                spIcon2.enabled = false;
                spIcon3.enabled = false;
                spIcon4.enabled = false;
                spIcon5.enabled = false;
                print(spIcon1);
            }
            else if (skin.instrument == 2)
            {
                icon.sprite = skin.instrumentIcon;
                icon.enabled = true;

                spIcon1.enabled = false;
                spIcon2.enabled = false;
                spIcon3.enabled = false;
                spIcon4.enabled = false;
                spIcon5.enabled = false;
            }
            else if (skin.instrument == 3)
            {
                icon.sprite = skin.instrumentIcon;
                icon.enabled = true;

                spIcon1.enabled = false;
                spIcon2.enabled = false;
                spIcon3.enabled = false;
                spIcon4.enabled = false;
                spIcon5.enabled = false;
            }
        }

        if (skin.instrument == 2)
        {
            transform.localScale = new Vector2(.8f, 1);
        }
        else
        {
            transform.localScale = new Vector2(.8f, .8f);
        }

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
