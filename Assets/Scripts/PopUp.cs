using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Popup", menuName = "PopUps/New PopUp")]
public class PopUp : ScriptableObject {

    public string popUpName;

    public bool statsVisible;
    public bool picVisible;

    public string description;
    public List<string> stats = new List<string>();

    public int buttonAmount;

    //public GameObject button1;
    //public GameObject button2;

    public string buttonOne;
    public string buttonTwo;

    public float buttonPos1X = -309;
    public float buttonPos1Y = -1034;
    public float buttonPos2X = 301;
    public float buttonPos2Y = -1034;

    public float sizeX;
    public float sizeY;

    public Sprite pic;
    public Sprite bg;
}
