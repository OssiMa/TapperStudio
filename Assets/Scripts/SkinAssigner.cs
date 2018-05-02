using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinAssigner : MonoBehaviour {

    //Check what's in the Skin Inventory, and then change the respective sprites

    int instrument;

    ColorBlock cb;
    Color32 color;
    string colorString;

    SkinInventory skinInventory;

    GameObject pianoBGObj, pianoEdgeObj, guitarBGObj;
    List<Transform> drumDecoObj = new List<Transform>();
    Transform drumDecoObjReal;

    Sprite pianoBG, pianoEdge, guitarBG;
    Sprite[] drumDeco;

    Sprite[] pianoSpecials1, pianoSpecials2, pianoSpecials3;

    GameObject[] pianoSpecialsObj1, pianoSpecialsObj2, pianoSpecialsObj3;

    Sprite[] guitarSpecials1, guitarSpecials2, guitarSpecials3;

    GameObject[] guitarSpecialsObj1, guitarSpecialsObj2, guitarSpecialsObj3;

    Sprite[] drumSpecials1, drumSpecials2, drumSpecials3;

    GameObject[] drumSpecialsObj1, drumSpecialsObj2, drumSpecialsObj3;

    // Use this for initialization
    void Start ()
    {
        //A fuckton of finding stuff from the scene	
        pianoBGObj = GameObject.Find("imageKeyboard");
        pianoEdgeObj = GameObject.Find("");

        drumDecoObjReal = GameObject.Find("plate2_sprites").transform.GetChild(1);

        for (int i = 0; i < 3; i++)
        {
            drumDecoObj.Add(GameObject.Find("plate2_sprites").transform.GetChild(i));
        }
        guitarBGObj = GameObject.Find("imageGuitar");

        //Specials
	}

    //When clicked, this
    public void AssignSkin(SkinSlot slot)
    {
        instrument = slot.skin.instrument;
        
        if (instrument == 1)
        {
            Image image = drumDecoObjReal.GetComponent<Image>();                //Pitää tehdä TAIIIIIIIIKATEMPPUJA 
            Color newColor = drumDecoObjReal.GetComponent<Image>().color;
            newColor = slot.skin.color;
            image.color = newColor;
            /*foreach (Transform deco in drumDecoObj)
            {
                deco.GetComponent<Image>().color = slot.skin.color;
                print("nailed it");
            }*/
        }
        else if (instrument == 2)
        {
            guitarBGObj.GetComponent<Image>().color = slot.skin.color;
            print("nailed it here, as well");
        }
        else if (instrument == 3)
        {
            pianoBGObj.GetComponent<Image>().color = slot.skin.color;
            print("nailing anywhere, anyday");
        }
        
        if (slot.skin.trinket == true)
        {
            //Add stuffs
        }
        //change (/add?) trinkets
    }
}
