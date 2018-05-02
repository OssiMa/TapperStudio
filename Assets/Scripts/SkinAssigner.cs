using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAssigner : MonoBehaviour {

    //Check what's in the Skin Inventory, and then change the respective sprites

    SkinInventory skinInventory;


    GameObject pianoBGObj, pianoEdgeObj, drumDecoObj, guitarBGObj;

    Sprite pianoBG, pianoEdge, drumDeco, guitarBG;

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
        pianoBGObj = GameObject.Find("");
        pianoEdgeObj = GameObject.Find("");
        drumDecoObj = GameObject.Find("");
        guitarBGObj = GameObject.Find("");

        //Specials

        AssignTo();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void AssignTo()
    {
        //check instrument,
        //change color, 
        //change (/add?) trinkets
    }
}
