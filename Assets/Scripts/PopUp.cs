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

    /*public string stats1;
    public string stats2;
    public string stats3;
    public string stats4;*/

    public int buttonAmount;

    //public Button button1;
    //public Button button2;

    public GameObject button1;
    public GameObject button2;

    public float sizeX;
    public float sizeY;

    public Sprite pic;
    public Sprite bg;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
