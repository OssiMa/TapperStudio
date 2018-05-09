using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Purposes
{ 
    commonItem, rareItem, allRarityItem, skin, skinPremium, watchAd, addCurrencySmall, addCurrencyMedium, addCurrencyBig
}

[CreateAssetMenu(fileName = "Popup", menuName = "PopUps/New PopUp")]
public class PopUp : ScriptableObject {

    public string popUpName;

    public Purposes purpose;
    //public AddCurrencyAmount addCurrencyAmount;
    //public BoughtItem boughtItem;

    //public int removeCurrencyAmount;

    public bool statsVisible;
    public bool picVisible;

    public GameObject popUpFrame;
    public GameObject selectedInvSlot;
    public Item selectedItem;

    public string description;
    public List<string> stats = new List<string>();

    public int buttonAmount;

    public string buttonOne;
    public string buttonTwo;
    public string buttonThree;

    public float buttonPos1X = -309;
    public float buttonPos1Y = -1034;
    public float buttonPos2X = 301;
    public float buttonPos2Y = -1034;
    public float buttonPos3X = 293;
    public float buttonPos3Y = -1034;

    public float sizeX;
    public float sizeY;

    public float posX;
    public float posY;

    public Sprite pic;
    public Sprite bg;
}
