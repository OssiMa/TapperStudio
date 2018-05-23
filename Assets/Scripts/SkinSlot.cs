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
    Image spIcon6;
    Image spIcon7;
    GameObject greyImage;

    Button button;
    ColorBlock cb;
    //ColorBlock cbOrigin;
    Color32 buttonColor;
    //Color32 originColor;

    [HideInInspector]
    public Skin skin;

    InstrumentBase instrumentBaseDrums;
    InstrumentBase instrumentBaseGuitar;
    InstrumentBase instrumentBasePiano;

    void Awake()
    {
        instrumentBaseDrums = GameObject.Find("Drums").GetComponent<InstrumentBase>();
        instrumentBaseGuitar = GameObject.Find("Guitar").GetComponent<InstrumentBase>();
        instrumentBasePiano = GameObject.Find("Piano").GetComponent<InstrumentBase>();
    }

    public void AddSkin(Skin newSkin)
    {
        icon = GetComponent<Image>();
        spIcon1 = transform.GetChild(0).GetComponent<Image>();
        spIcon2 = transform.GetChild(1).GetComponent<Image>();
        spIcon3 = transform.GetChild(2).GetComponent<Image>();
        spIcon4 = transform.GetChild(3).GetComponent<Image>();
        spIcon5 = transform.GetChild(4).GetComponent<Image>();
        spIcon6 = transform.GetChild(5).GetComponent<Image>();
        spIcon7 = transform.GetChild(6).GetComponent<Image>();

        skin = newSkin;

        button = GetComponent<Button>();

        cb = button.colors;
        Color32 newColor = skin.color;
        Color32 greyColor;

        if (skin.baseInstrument == false)
        {
            newColor.a = 255;
            newColor.g += 75;
            newColor.b += 75;
        }
        else
        {
            if (skin.instrument == 1)
            {
                if (skin.vintageLock <= instrumentBaseDrums.vintageLevel)
                {
                    newColor.r = 19;
                    newColor.g = 177;
                    newColor.b = 255;
                    newColor.a = 200;
                }
            }
            else if (skin.instrument == 2)
            {
                if (skin.vintageLock <= instrumentBaseGuitar.vintageLevel)
                {
                    newColor.r = 255;
                    newColor.g = 215;
                    newColor.b = 146;
                    newColor.a = 255;
                }
            }
            else if (skin.instrument == 3)
            {
                if (skin.vintageLock <= instrumentBaseGuitar.vintageLevel)
                {
                    newColor.r = 255;
                    newColor.g = 255;
                    newColor.b = 255;
                    newColor.a = 255;
                }
            }
        }
        cb.normalColor = newColor;
        cb.highlightedColor = newColor;
        cb.pressedColor = new Color(0, 0, 0, 255);
        button.colors = cb;

        greyColor.r = 90;
        greyColor.g = 90;
        greyColor.b = 90;
        greyColor.a = 200;

        if (skin.instrument == 1)
        {
            if (skin.vintageLock > instrumentBasePiano.vintageLevel)
            {
                //newColor.a = 200;
                spIcon1.color = greyColor;
                spIcon2.color = greyColor;
                spIcon2.color = greyColor;
                spIcon3.color = greyColor;
                spIcon4.color = greyColor;
                spIcon5.color = greyColor;
                spIcon6.color = greyColor;
                spIcon7.color = greyColor;
            }
            else
            {
                newColor.a = 255;
                spIcon1.color = newColor;
            }
        }
        else if (skin.instrument == 2)
        {
            if (skin.vintageLock > instrumentBasePiano.vintageLevel)
            {
                //newColor.a = 200;
                spIcon1.color = greyColor;
                spIcon2.color = greyColor;
                spIcon2.color = greyColor;
                spIcon3.color = greyColor;
                spIcon4.color = greyColor;
                spIcon5.color = greyColor;
                spIcon6.color = greyColor;
            }
            else
            {
                newColor.a = 255;
                spIcon2.color = newColor;
                spIcon3.color = newColor;
                spIcon4.color = newColor;
            }
        }
        else if (skin.instrument == 3)
        {
            if (skin.vintageLock > instrumentBasePiano.vintageLevel)
            {
                //newColor.a = 200;
                spIcon1.color = greyColor;
                spIcon2.color = greyColor;
                spIcon2.color = greyColor;
                spIcon3.color = greyColor;
                spIcon4.color = greyColor;
                spIcon5.color = greyColor;
                spIcon6.color = greyColor;
            }
            else
            {
                newColor.a = 255;
                spIcon1.color = newColor;
                spIcon2.color = newColor;
            }
        }


        if (skin.trinketType != 0)
        {
            if (skin.instrument == 3)
            {
                spIcon1.sprite = skin.specialIcon1;
                spIcon2.sprite = skin.specialIcon2;
                spIcon3.sprite = skin.specialIcon3;
                spIcon1.enabled = true;
                spIcon2.enabled = true;
                spIcon3.enabled = true;
                spIcon4.enabled = false;
                spIcon5.enabled = false;
                spIcon6.enabled = false;
                spIcon7.enabled = false;

                //As many enabled as the final version has them
            }

            if (skin.instrument == 2)
            {
                spIcon1.sprite = skin.specialIcon1;
                spIcon2.sprite = skin.specialIcon2;
                spIcon3.sprite = skin.specialIcon3;
                spIcon4.sprite = skin.specialIcon4;
                spIcon5.sprite = skin.specialIcon5;
                spIcon6.sprite = skin.specialIcon6;
                spIcon1.enabled = true;
                spIcon2.enabled = true;
                spIcon3.enabled = true;
                spIcon4.enabled = true;
                spIcon5.enabled = true;
                spIcon6.enabled = false;
                spIcon7.enabled = false;
            }
            if (skin.instrument == 1)
            {
                spIcon1.sprite = skin.specialIcon1;
                spIcon2.sprite = skin.specialIcon2;
                spIcon3.sprite = skin.specialIcon3;
                spIcon4.sprite = skin.specialIcon4;
                spIcon5.sprite = skin.specialIcon5;
                spIcon6.sprite = skin.specialIcon6;
                spIcon7.sprite = skin.specialIcon7;
                spIcon1.enabled = true;
                spIcon2.enabled = true;
                spIcon3.enabled = true;
                spIcon4.enabled = true;
                spIcon5.enabled = true;
                spIcon6.enabled = true;
                spIcon7.enabled = true;

                //As many enabled as the final version has them
            }

            //icon.enabled = false;
        }
        else
        {
            if (skin.instrument == 1)
            {
                spIcon1.sprite = skin.specialIcon1;
                spIcon2.sprite = skin.specialIcon2;
                spIcon3.sprite = skin.specialIcon3;
                spIcon4.sprite = skin.specialIcon4;
                spIcon5.sprite = skin.specialIcon5;
                spIcon6.sprite = skin.specialIcon6;
                spIcon7.sprite = skin.specialIcon7;
                spIcon1.enabled = true;
                spIcon2.enabled = true;
                spIcon3.enabled = true;
                spIcon4.enabled = true;
                spIcon5.enabled = true;
                spIcon6.enabled = true;
                spIcon7.enabled = false;
            }
            else if (skin.instrument == 2)
            {
                //icon.sprite = skin.instrumentIcon;
                //icon.enabled = true;
                spIcon1.sprite = skin.specialIcon1;
                spIcon2.sprite = skin.specialIcon2;
                spIcon3.sprite = skin.specialIcon3;
                spIcon4.sprite = skin.specialIcon4;
                spIcon5.sprite = skin.specialIcon5;
                spIcon6.sprite = skin.specialIcon6;
                spIcon7.sprite = skin.specialIcon7;

                spIcon1.enabled = true;
                spIcon2.enabled = true;
                spIcon3.enabled = true;
                spIcon4.enabled = true;
                spIcon5.enabled = true;
                spIcon6.enabled = false;
                spIcon7.enabled = false;
            }
            else if (skin.instrument == 3)
            {
                //icon.sprite = skin.instrumentIcon;
                //icon.enabled = true;
                spIcon1.sprite = skin.specialIcon1;
                spIcon2.sprite = skin.specialIcon2;
                spIcon3.sprite = skin.specialIcon3;
                spIcon4.sprite = skin.specialIcon4;
                spIcon5.sprite = skin.specialIcon5;
                spIcon6.sprite = skin.specialIcon6;
                spIcon7.sprite = skin.specialIcon7;

                spIcon1.enabled = true;
                spIcon2.enabled = true;
                spIcon3.enabled = true;
                spIcon4.enabled = false;
                spIcon5.enabled = false;
                spIcon6.enabled = false;
                spIcon7.enabled = false;
            }
        }

        if (skin.instrument == 2)
        {
            transform.localScale = new Vector2(.8f, 1);
        }
        else if (skin.instrument == 1)
        {
            //if (skin.trinketType != 0)
            //{
                transform.localScale = new Vector2(1.4f, 1);
            /*}
            else
            {
                transform.localScale = new Vector2(1.08f, 1);
            }*/
        }
        else
        {
            //if (skin.trinketType != 0)
            //{
                transform.localScale = new Vector2(1, .8f);
            /*}
            else
            {
                transform.localScale = new Vector2(.8f, .8f);
            }*/
        }

        button.interactable = true;
    }

    public void ClearSlot()
    {
        icon = GetComponent<Image>();

        button = GetComponent<Button>();

        button.interactable = false;
    }

    public void LockSlot()
    {
        button = GetComponent<Button>();
        button.interactable = false;
    }

    public Skin GetSkin()
    {
        return skin;
    }

}
