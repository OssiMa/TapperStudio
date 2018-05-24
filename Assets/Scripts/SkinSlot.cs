using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour {

    Image spIcon1, spIcon2, spIcon3, spIcon4, spIcon5, spIcon6, spIcon7;
    GameObject greyImage;

    Button button;
    ColorBlock cb;
    Color32 buttonColor;

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
                newColor.r = 19;
                newColor.g = 177;
                newColor.b = 255;
                newColor.a = 200;
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

        greyColor.r = 90;
        greyColor.g = 90;
        greyColor.b = 90;
        greyColor.a = 200;

        //Set the instruments' parts' colors:
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
                //What color are the other parts?
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
                if (skin.trinketType == 0)
                {
                    newColor.a = 255;
                    spIcon1.color = newColor;
                    spIcon2.color = newColor;
                    spIcon3.color = newColor;
                    //What color are the other parts?
                }
                else
                {
                    newColor.a = 255;
                    spIcon2.color = newColor;
                    spIcon3.color = newColor;
                    spIcon4.color = newColor;
                }
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
                if (skin.trinketType == 0)
                {
                    newColor.a = 255;
                    spIcon1.color = newColor;
                    spIcon2.color = newColor;
                    //What color are the other parts?
                }
                else
                {
                    spIcon1.color = newColor;
                    spIcon3.color = newColor;
                    spIcon4.color = newColor;
                    spIcon5.color = newColor;
                }
            }
        }

        //The trinketed instruments' sprites::
        if (skin.trinketType != 0)
        {
            if (skin.instrument == 3)
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

            if (skin.instrument == 2)
            {
                spIcon1.sprite = skin.specialIcon1;
                spIcon2.sprite = skin.specialIcon2;
                spIcon3.sprite = skin.specialIcon3;
                spIcon4.sprite = skin.specialIcon4;
                spIcon5.sprite = skin.specialIcon5;
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
            }
        }
        //The standard instruments' sprites:
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
                spIcon1.sprite = skin.specialIcon1;
                spIcon2.sprite = skin.specialIcon2;
                spIcon3.sprite = skin.specialIcon3;
                spIcon4.sprite = skin.specialIcon4;

                spIcon1.enabled = true;
                spIcon2.enabled = true;
                spIcon3.enabled = true;
                spIcon4.enabled = true;
                spIcon5.enabled = false;
                spIcon6.enabled = false;
                spIcon7.enabled = false;
            }
            else if (skin.instrument == 3)
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
            }
        }

        //Instrument sizes
        if (skin.instrument == 2)
        {
            transform.localScale = new Vector2(.8f, 1);
        }
        else if (skin.instrument == 1)
        {
            transform.localScale = new Vector2(1.4f, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, .8f);
        }

        //Button is now interactable! It's made not interactable in LockSlot().
        button.interactable = true;
    }

    public void ClearSlot()
    {
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
