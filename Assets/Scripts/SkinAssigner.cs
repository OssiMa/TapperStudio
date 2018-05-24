using System.Collections;
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

    GameObject togglesGuitar;

    GameObject togglesGuitarSpecial;

    GameObject togglesDrums;
    GameObject togglesDrumsSpecial;

    GameObject togglesPiano;

    Image togglePianoSpecial1, togglePianoSpecial2, togglePianoSpecial3, togglePianoSpecial4, togglePianoSpecial5, togglePianoSpecial6;
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

        guitarBoard = GameObject.Find("Panel_Guitar").transform.GetChild(7);
        guitarOutline = GameObject.Find("Panel_Guitar").transform.GetChild(8);

        instrumentBaseDrums = GameObject.Find("Drums").GetComponent<InstrumentBase>();
        instrumentBaseGuitar = GameObject.Find("Guitar").GetComponent<InstrumentBase>();
        instrumentBasePiano = GameObject.Find("Piano").GetComponent<InstrumentBase>();


        GetTrinkets();
        GetToggles();
    }

    void GetToggles()
    {
        togglesGuitar = GameObject.Find("TogglesGuitar");
        togglesGuitarSpecial = GameObject.Find("TogglesGuitarSpecial");

        togglesDrums = GameObject.Find("TogglesDrums");
        togglesDrumsSpecial = GameObject.Find("ToggleDrumsSpecial");

        togglesPiano = GameObject.Find("TogglesPiano");
        togglesPianoSpecial = GameObject.Find("TogglesPianoSpecial");

        togglesPianoSpecial.SetActive(false);
        togglesGuitarSpecial.SetActive(false);
        togglesDrumsSpecial.SetActive(false);
    }

    void GetTrinkets()
    {
        //The gameobjects that have their sprites changed
        pianoSpecialsObj = GameObject.Find("Panel_Keyboard").transform.GetChild(8);
        pianoSpecialImage = pianoSpecialsObj.GetComponent<Image>();

        guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(10);
        guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();

        drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(4);
        drumSpecialImage = drumSpecialsObj.GetComponent<Image>();
    }

    public void AssignSkin(SkinSlot slot)
    {
        instrument = slot.skin.instrument;

        if (instrument == 1)
        {
            Color32 newColor;

            if (slot.skin.trinketType != 0)     //If the skin has a trinket
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
                newColor = slot.skin.color;
                newColor.a = 255;
            }
            else
            {
                newColor.r = 19;                        //If base instrument is equipped
                newColor.g = 177;
                newColor.b = 255;
                newColor.a = 255;
            }

            drumDeco1.GetComponent<Image>().color = newColor;
            drumDeco2.GetComponent<Image>().color = newColor;
            drumDeco3.GetComponent<Image>().color = newColor;
            togglesDrums.transform.GetChild(1).GetComponent<Image>().color = newColor;
            togglesDrumsSpecial.transform.GetChild(1).GetComponent<Image>().color = newColor;
        }
        else if (instrument == 2)
        {
                if (slot.skin.trinketType != 0)          //If the skin has a trinket
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
                    togglesGuitar.transform.GetChild(0).GetComponent<Image>().color = newColor;
                    togglesGuitar.transform.GetChild(1).GetComponent<Image>().color = newColor;
                    togglesGuitar.transform.GetChild(2).GetComponent<Image>().color = newColor;
                    togglesGuitarSpecial.transform.GetChild(1).GetComponent<Image>().color = newColor;
                    togglesGuitarSpecial.transform.GetChild(2).GetComponent<Image>().color = newColor;
                    togglesGuitarSpecial.transform.GetChild(3).GetComponent<Image>().color = newColor;
                }
                else
                {
                    Color32 newColor1;
                    newColor1.r = 159;
                    newColor1.g = 133;
                    newColor1.b = 105;
                    newColor1.a = 255;

                    Color32 newColor2;
                    newColor2.r = 255;
                    newColor2.g = 215;
                    newColor2.b = 146;
                    newColor2.a = 255;

                    guitarBoard.GetComponent<Image>().color = newColor1;
                    guitarOutline.GetComponent<Image>().color = newColor1;
                    togglesGuitar.transform.GetChild(0).GetComponent<Image>().color = newColor2;
                    togglesGuitar.transform.GetChild(1).GetComponent<Image>().color = newColor2;
                    togglesGuitar.transform.GetChild(2).GetComponent<Image>().color = newColor2;
                    togglesGuitarSpecial.transform.GetChild(1).GetComponent<Image>().color = newColor2;
                    togglesGuitarSpecial.transform.GetChild(2).GetComponent<Image>().color = newColor2;
                    togglesGuitarSpecial.transform.GetChild(3).GetComponent<Image>().color = newColor2;
            }
        }
        else if (instrument == 3)
        {
            Color32 newColor;

            if (slot.skin.trinketType != 0)          //If the skin has a trinket
            {
                AssignTrinket(slot);
                togglesPiano.SetActive(true);
                togglesPianoSpecial.SetActive(false);
            }
            else if (slot.skin.trinketType == 0)    //If the skin doesn't have a trinket
            {
                togglesPiano.SetActive(false);
                togglesPianoSpecial.SetActive(true);
            }

            if (slot.skin.baseInstrument == false)
            {
                newColor = slot.skin.color;
                newColor.a = 255;
                pianoBG.GetComponent<Image>().color = newColor;
                pianoEdge.GetComponent<Image>().color = newColor;
            }
            else
            {
                newColor.r = 255;
                newColor.g = 255;
                newColor.b = 255;
                newColor.a = 255;
            }

            togglesPiano.transform.GetChild(0).GetComponent<Image>().color = newColor;
            togglesPiano.transform.GetChild(1).GetComponent<Image>().color = newColor;
            togglesPianoSpecial.transform.GetChild(0).GetComponent<Image>().color = newColor;
            togglesPianoSpecial.transform.GetChild(2).GetComponent<Image>().color = newColor;
            togglesPianoSpecial.transform.GetChild(3).GetComponent<Image>().color = newColor;
            togglesPianoSpecial.transform.GetChild(4).GetComponent<Image>().color = newColor;
        }
    }

    void AssignTrinket(SkinSlot slot)
    {
        instrument = slot.skin.instrument;

        if (instrument == 1)
        {
            if (slot.skin.trinketType == 1)
            {
                //drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(3);
                drumSpecialImage.enabled = true;
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
            }
            else if (slot.skin.trinketType == 2)
            {
                //drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(4);
                drumSpecialImage.enabled = true;
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
            }
            else if (slot.skin.trinketType == 3)
            {
                //drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(5);
                drumSpecialImage.enabled = true;
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
            }
            else if (slot.skin.trinketType == 4)
            {
                //drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(6);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 5)
            {
                //drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(7);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 6)
            {
                //drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(8);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 7)
            {
                //drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(9);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 8)
            {
                //drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(10);
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
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(0);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 2)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(1);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 3)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(2);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 4)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(3);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 5)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(4);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 6)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(5);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 7)
            {
                guitarSpecialImage.enabled = false;
                guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(6);
                guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                guitarSpecialImage.enabled = true;
            }
            //togglesGuitar.SetActive(false);
            //togglesGuitarSpecial.SetActive(true);
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
