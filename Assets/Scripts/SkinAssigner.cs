using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinAssigner : MonoBehaviour {

    int instrument;

    ColorBlock cb;
    Color32 color;
    string colorString;

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

        GetTrinkets();
    }

    void GetTrinkets()
    {
        pianoSpecialsObj = GameObject.Find("Panel_Keyboard").transform.GetChild(8);
        pianoSpecialImage = pianoSpecialsObj.GetComponent<Image>();

        guitarSpecialsObj = GameObject.Find("Panel_Guitar").transform.GetChild(4);
        guitarSpecialImage = guitarSpecialsObj.GetComponent<Image>();

        //drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(4);
        //drumSpecialImage = drumSpecialsObj.GetComponent<Image>();
    }

    public void AssignSkin(SkinSlot slot)
    {
        instrument = slot.skin.instrument;
        
        if (instrument == 1)
        {
            Color32 newColor = slot.skin.color;
            newColor.a = 255;
            drumDeco1.GetComponent<Image>().color = newColor;
            drumDeco2.GetComponent<Image>().color = newColor;
            drumDeco3.GetComponent<Image>().color = newColor;
        }
        else if (instrument == 2)
        {
            Color32 newColor = slot.skin.color;
            newColor.a = 255;
            guitarBoard.GetComponent<Image>().color = newColor;
            guitarOutline.GetComponent<Image>().color = newColor;
        }
        else if (instrument == 3)
        {
            Color32 newColor = slot.skin.color;
            newColor.a = 255;
            pianoBG.GetComponent<Image>().color = newColor;
            pianoEdge.GetComponent<Image>().color = newColor;
        }
        
        if (slot.skin.trinketType != 0)
        {
            print("going");
            AssignTrinket(slot);
        }
    }

    void AssignTrinket(SkinSlot slot)
    {
        instrument = slot.skin.instrument;

        if (instrument == 1)
        {
            /*if (slot.skin.trinketType == 1)
            {
                drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(4);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }
            else if (slot.skin.trinketType == 1)
            {
                drumSpecialImage.enabled = false;
                drumSpecialsObj = GameObject.Find("2_decoration").transform.GetChild(4);
                drumSpecialImage = guitarSpecialsObj.GetComponent<Image>();
                drumSpecialImage.enabled = true;
            }*/
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
        //pianoSpecialsObjDefault.image.sprite vaihtuu
        //itse asiassa vois olla helpompaa vaan laittaa image aktiiviseksi scenessä
        //montako variaatioita on?
        //bonus: pitäiskö trinkettiskineille olla vähän erilainen ikoni?
    }
}
