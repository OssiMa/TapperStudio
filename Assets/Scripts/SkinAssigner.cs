﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinAssigner : MonoBehaviour {

    int instrument;

    ColorBlock cb;
    Color32 color;
    string colorString;

    Color32 guitarOriginColor;
    Color32 drumOriginColor;

    SkinInventory skinInventory;

    Transform pianoBG, pianoEdge;
    Transform guitarOutline, guitarBoard;
    Transform drumDeco1, drumDeco2, drumDeco3;

    Transform pianoSpecialsObj, pianoSpecialsObj1, pianoSpecialsObj2, pianoSpecialsObj3, pianoSpecialsObj4, pianoSpecialsObj5, pianoSpecialsObj6, pianoSpecialsObj7;
    Image pianoSpecialImage;

    Transform guitarSpecialsObj, guitarSpecialsObj1, guitarSpecialsObj2, guitarSpecialsObj3, guitarSpecialsObj4, guitarSpecialsObj5, guitarSpecialsObj6, guitarSpecialsObj7;
    Image guitarSpecialImage;

    Transform drumSpecialsObj, drumSpecialsObj1, drumSpecialsObj2, drumSpecialsObj3, drumSpecialsObj4, drumSpecialsObj5, drumSpecialsObj6,drumSpecialsObj7;
    Image drumSpecialImage;

    Image toggleImageGuitar1;
    Image toggleImageGuitar2;
    Image toggleImageGuitar3;
    GameObject togglesGuitar;
    Image toggleImageGuitarSpecial1;
    Image toggleImageGuitarSpecial2;
    Image toggleImageGuitarSpecial3;
    GameObject togglesGuitarSpecial;

    GameObject togglesDrums;
    Image toggleImageDrums1, toggleImageDrums2, toggleImageDrums3, toggleImageDrums4, toggleImageDrums5, toggleImageDrums6;
    GameObject togglesDrumsSpecial;
    Image toggleImageDrumsSpecial1, toggleImageDrumsSpecial2, toggleImageDrumsSpecial3, toggleImageDrumsSpecial4, toggleImageDrumsSpecial5, toggleImageDrumsSpecial6, toggleImageDrumsSpecial7;
    //I guess the special toggle images could just be gameobjects that are put on accordingly

    Image toggleImagePiano1;
    Image toggleImagePiano2;
    GameObject togglesPiano;

    Image togglePianoSpecial1, togglePianoSpecial2, togglePianoSpecial3, togglePianoSpecial4, togglePianoSpecial5, togglePianoSpecial6, togglePianoSpecial7;
    GameObject togglesPianoSpecial;

    InstrumentBase instrumentBaseDrums;
    InstrumentBase instrumentBaseGuitar;
    InstrumentBase instrumentBasePiano;

    // Use this for initialization
    void Awake ()
    {
        pianoBG = GameObject.Find("Panel_Keyboard").transform.GetChild(7);
        pianoEdge = GameObject.Find("Panel_Keyboard").transform.GetChild(0);

        drumDeco1 = GameObject.Find("2_decoration").transform.GetChild(1);
        drumDeco2 = GameObject.Find("2_decoration1").transform.GetChild(1);
        drumDeco3 = GameObject.Find("2_decoration2").transform.GetChild(1);

        guitarBoard = GameObject.Find("Panel_Guitar").transform.GetChild(0);
        guitarOutline = GameObject.Find("Panel_Guitar").transform.GetChild(1);

        instrumentBaseDrums = GameObject.Find("Drums").GetComponent<InstrumentBase>();
        instrumentBaseGuitar = GameObject.Find("Guitar").GetComponent<InstrumentBase>();
        instrumentBasePiano = GameObject.Find("Piano").GetComponent<InstrumentBase>();


        GetTrinkets();
        GetToggles();
    }

    void GetToggles()
    {
        togglesGuitar = GameObject.Find("TogglesGuitar");
        toggleImageGuitar1 = GameObject.Find("guitar_buttonImage_body").GetComponent<Image>();
        toggleImageGuitar2 = GameObject.Find("guitar_buttonImage_head").GetComponent<Image>();
        toggleImageGuitar3 = GameObject.Find("guitar_buttonImage_neck").GetComponent<Image>();
        togglesGuitarSpecial = GameObject.Find("TogglesGuitarSpecial");
        toggleImageGuitarSpecial1 = GameObject.Find("guitar_buttonImage_body (1)").GetComponent<Image>();
        toggleImageGuitarSpecial2 = GameObject.Find("guitar_buttonImage_head (1)").GetComponent<Image>();
        toggleImageGuitarSpecial3 = GameObject.Find("guitar_buttonImage_neck (1)").GetComponent<Image>();
        //togglesGuitarSpecial.SetActive(false);

        togglesDrums = GameObject.Find("TogglesDrums");
        toggleImageDrums1 = GameObject.Find("drum_buttonImage_body").GetComponent<Image>();
        /*toggleImageDrums2 = GameObject.Find("drum_buttonImage (2)").GetComponent<Image>();
        toggleImageDrums3 = GameObject.Find("drum_buttonImage (4)").GetComponent<Image>();
        toggleImageDrums4 = GameObject.Find("drum_buttonImage (5)").GetComponent<Image>();
        toggleImageDrums5 = GameObject.Find("drum_buttonImage (3)").GetComponent<Image>();
        toggleImageDrums6 = GameObject.Find("drum_buttonImage (1)").GetComponent<Image>();*/

        //Drum specials
        togglesDrumsSpecial = GameObject.Find("ToggleDrumsSpecial");
        toggleImageDrumsSpecial1 = GameObject.Find("drum_buttonImage (4)_special").GetComponent<Image>();
        /*toggleImageDrumsSpecial2 = GameObject.Find("drum_buttonImage (2)_special").GetComponent<Image>();
        toggleImageDrumsSpecial3 = GameObject.Find("drum_buttonImage_body_special").GetComponent<Image>();
        toggleImageDrumsSpecial4 = GameObject.Find("drum_buttonImage (5)_special").GetComponent<Image>();
        toggleImageDrumsSpecial5 = GameObject.Find("drum_buttonImage (3)_special").GetComponent<Image>();
        toggleImageDrumsSpecial6 = GameObject.Find("drum_buttonImage (1)_special").GetComponent<Image>();
        toggleImageDrumsSpecial7 = GameObject.Find("drum_buttonImage (6)_special").GetComponent<Image>();*/

        toggleImagePiano1 = GameObject.Find("keyboard_buttonImage_head").GetComponent<Image>();
        toggleImagePiano2 = GameObject.Find("keyboard_buttonImage_bottom").GetComponent<Image>();
        togglesPiano = GameObject.Find("TogglesPiano");
        togglesPianoSpecial = GameObject.Find("TogglesPianoSpecial");
        togglePianoSpecial1 = GameObject.Find("keyboard_buttonImage_bottom_special").GetComponent<Image>();
        togglePianoSpecial2 = GameObject.Find("keyboard_buttonImage_head_special").GetComponent<Image>();
        togglePianoSpecial3 = GameObject.Find("keyboard_buttonImage (3)_special").GetComponent<Image>();
        togglePianoSpecial4 = GameObject.Find("keyboard_buttonImage (4)_special").GetComponent<Image>();
        togglePianoSpecial5 = GameObject.Find("keyboard_buttonImage (5)_special").GetComponent<Image>();
        togglePianoSpecial6 = GameObject.Find("keyboard_buttonImage (6)_special").GetComponent<Image>();
        togglePianoSpecial7 = GameObject.Find("keyboard_buttonImage (10)_special").GetComponent<Image>();

        togglesPianoSpecial.SetActive(false);
        togglesGuitarSpecial.SetActive(false);
        togglesDrumsSpecial.SetActive(false);
    }

    void GetTrinkets()
    {
        pianoSpecialsObj = GameObject.Find("Panel_Keyboard").transform.GetChild(8);
        pianoSpecialImage = pianoSpecialsObj.GetComponent<Image>();

        guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(3);
        guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();

        drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(4);
        drumSpecialImage = drumSpecialsObj.GetComponent<Image>();
    }

    public void AssignSkin(SkinSlot slot)
    {
        instrument = slot.skin.instrument;

        if (instrument == 1)
        {
            if (slot.skin.vintageLock > instrumentBaseDrums.vintageLevel)
            {
                if (slot.skin.trinketType != 0)
                {
                    AssignTrinket(slot);
                    togglesDrums.SetActive(false);
                    togglesDrumsSpecial.SetActive(true);
                }
                else if (slot.skin.trinketType == 0)
                {
                    togglesDrums.SetActive(true);
                    togglesDrumsSpecial.SetActive(false);
                }

                if (slot.skin.baseInstrument == false)
                {
                    Color32 newColor = slot.skin.color;
                    newColor.a = 255;
                    drumDeco1.GetComponent<Image>().color = newColor;
                    drumDeco2.GetComponent<Image>().color = newColor;
                    drumDeco3.GetComponent<Image>().color = newColor;
                    toggleImageDrums1.color = newColor;
                    toggleImageDrumsSpecial1.color = newColor;
                }
                else
                {
                    Color32 newColor;
                    newColor.r = 19;
                    newColor.g = 177;
                    newColor.b = 255;
                    newColor.a = 255;

                    drumDeco1.GetComponent<Image>().color = newColor;
                    drumDeco2.GetComponent<Image>().color = newColor;
                    drumDeco3.GetComponent<Image>().color = newColor;
                    toggleImageDrumsSpecial1.color = newColor;
                    toggleImageDrums1.color = newColor;
                }
            }
        }
        else if (instrument == 2)
        {
            if (slot.skin.vintageLock > instrumentBaseGuitar.vintageLevel)
            {
                if (slot.skin.trinketType != 0)
                {
                    AssignTrinket(slot);
                    togglesGuitar.SetActive(false);
                    togglesGuitarSpecial.SetActive(true);
                }
                else if (slot.skin.trinketType == 0)
                {
                    togglesGuitar.SetActive(true);
                    togglesGuitarSpecial.SetActive(false);
                }
                if (slot.skin.baseInstrument == false)
                {
                    Color32 newColor = slot.skin.color;
                    newColor.a = 255;
                    guitarBoard.GetComponent<Image>().color = newColor;
                    guitarOutline.GetComponent<Image>().color = newColor;
                    toggleImageGuitar1.color = newColor;
                    toggleImageGuitar2.color = newColor;
                    toggleImageGuitar3.color = newColor;
                    toggleImageGuitarSpecial1.color = newColor;
                    toggleImageGuitarSpecial2.color = newColor;
                    toggleImageGuitarSpecial3.color = newColor;
                }
                else
                {
                    Color32 newColor1;
                    newColor1.r = 159;
                    newColor1.g = 133;
                    newColor1.b = 105;
                    newColor1.a = 255;

                    guitarBoard.GetComponent<Image>().color = newColor1;
                    guitarOutline.GetComponent<Image>().color = newColor1;

                    Color32 newColor2; //= new Color(159, 133, 105, 255);
                    newColor2.r = 255;
                    newColor2.g = 215;
                    newColor2.b = 146;
                    newColor2.a = 255;

                    toggleImageGuitar1.color = newColor2;
                    toggleImageGuitar2.color = newColor2;
                    toggleImageGuitar3.color = newColor2;
                    toggleImageGuitarSpecial1.color = newColor2;
                    toggleImageGuitarSpecial2.color = newColor2;
                    toggleImageGuitarSpecial3.color = newColor2;
                }
            }
        }
        else if (instrument == 3)
        {
            if (slot.skin.vintageLock > instrumentBaseDrums.vintageLevel)
            {
                if (slot.skin.trinketType != 0)
                {
                    AssignTrinket(slot);
                    togglesPiano.SetActive(true);
                    togglesPianoSpecial.SetActive(false);
                }
                else if (slot.skin.trinketType == 0)
                {
                    togglesPiano.SetActive(false);
                    togglesPianoSpecial.SetActive(true);
                }

                Color32 newColor = slot.skin.color;
                newColor.a = 255;
                pianoBG.GetComponent<Image>().color = newColor;
                pianoEdge.GetComponent<Image>().color = newColor;

                toggleImagePiano1.color = newColor;
                toggleImagePiano2.color = newColor;

                togglePianoSpecial1.color = newColor;
                togglePianoSpecial2.color = newColor;
                togglePianoSpecial3.color = newColor;
                togglePianoSpecial4.color = newColor;
                togglePianoSpecial5.color = newColor;
                togglePianoSpecial6.color = newColor;
                togglePianoSpecial7.color = newColor;
            }
        }
    }

    void AssignTrinket(SkinSlot slot)
    {
        instrument = slot.skin.instrument;

        if (instrument == 1)
        {
            if (slot.skin.trinketType == 1)
            {
                drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(4);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 2)
            {
                drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(5);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 3)
            {
                drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(6);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 4)
            {
                drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(7);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 5)
            {
                drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(8);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 6)
            {
                drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(9);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 7)
            {
                drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(10);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 8)
            {
                drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(11);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            //togglesDrums.SetActive(false);
            //togglesDrumsSpecial.SetActive(true);
        }
        else if (instrument == 2)
        { 
            if (slot.skin.trinketType == 1)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(6);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 2)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(7);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 3)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(8);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 4)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(9);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 5)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(10);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 6)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(11);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 7)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(12);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            togglesGuitar.SetActive(false);
            togglesGuitarSpecial.SetActive(true);
            print(guitarSpecialImage);
        } 
        else if (instrument == 3)
        {
            if (slot.skin.trinketType == 1)
            {
                pianoSpecialImage.enabled = false;
                pianoSpecialsObj = GameObject.Find("Panel_Keyboard").transform.GetChild(9);
                pianoSpecialImage = pianoSpecialsObj.GetComponent<Image>();
                pianoSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 2)
            {
                pianoSpecialImage.enabled = false;
                pianoSpecialsObj = GameObject.Find("Panel_Keyboard").transform.GetChild(10);
                pianoSpecialImage = pianoSpecialsObj.GetComponent<Image>();
                pianoSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 3)
            {
                pianoSpecialImage.enabled = false;
                pianoSpecialsObj = GameObject.Find("Panel_Keyboard").transform.GetChild(11);
                pianoSpecialImage = pianoSpecialsObj.GetComponent<Image>();
                pianoSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 4)
            {
                pianoSpecialImage.enabled = false;
                pianoSpecialsObj = GameObject.Find("Panel_Keyboard").transform.GetChild(12);
                pianoSpecialImage = pianoSpecialsObj.GetComponent<Image>();
                pianoSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 5)
            {
                pianoSpecialImage.enabled = false;
                pianoSpecialsObj = GameObject.Find("Panel_Keyboard").transform.GetChild(13);
                pianoSpecialImage = pianoSpecialsObj.GetComponent<Image>();
                pianoSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 6)
            {
                pianoSpecialImage.enabled = false;
                pianoSpecialsObj = GameObject.Find("Panel_Keyboard").transform.GetChild(14);
                pianoSpecialImage = pianoSpecialsObj.GetComponent<Image>();
                pianoSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 7)
            {
                pianoSpecialImage.enabled = false;
                pianoSpecialsObj = GameObject.Find("Panel_Keyboard").transform.GetChild(15);
                pianoSpecialImage = pianoSpecialsObj.GetComponent<Image>();
                pianoSpecialImage.enabled = true;
            }
        }

        //togglesPiano.SetActive(false);
        //togglesPianoSpecial.SetActive(true);
    }
}
