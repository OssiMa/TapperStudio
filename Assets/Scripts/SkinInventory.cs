using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinInventory : MonoBehaviour {

    //List of strings for each colour?
    //
    //Separate object that has reference to a color and changes it on the instrument?
    //sprite.drum[].color or whatever


    //Skin is it's own, separate object which, similarly to Item, has values for what it is.
    //Colour & instrument at least, maybe also rarity if we'll do that

    //This script keeps track of the created Skins. There is a separate script for creating new Skins.
    //I think I can use NewItemGenerator, Item & Inventory as reference for this

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
