using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpDisplay : MonoBehaviour {

    public PopUp popUp;

    bool statsVisible;
    bool picVisible;

    public Text descriptionText;

    public List<Text> statTexts = new List<Text>();

    int buttonAmount;

    Button button1;
    Button button2;

    float size;

    Sprite pic;
    Sprite bg;

	// Use this for initialization
	void Start ()
    {
        statsVisible = popUp.statsVisible;      //
        picVisible = popUp.picVisible;

        descriptionText.text = popUp.description;     //What it says on the PopUp. ("You got x gold!", etc.)

        if (statsVisible == true)       //This might break at some point - do I need to define whether the text objects have anything? not sure
        {
            statTexts[0].text = popUp.stats[0];
            statTexts[1].text = popUp.stats[1];
            statTexts[2].text = popUp.stats[2];
            statTexts[3].text = popUp.stats[3];
        }

        if (picVisible == true)
        {
            pic = popUp.pic;        //A picture, if the popup has one
        }

        bg = popUp.bg;

        buttonAmount = popUp.buttonAmount;  //How many buttons there are (1 or 2)

        button1 = popUp.button1;      //The first button
        button2 = popUp.button2;        //The second button

        size = popUp.size;      //Size of the popup
    }
	
	// Update is called once per frame
	void Update ()
    {
        descriptionText.alignment = TextAnchor.LowerRight;
        //Position of the description text (always the same?)

        //Positions of the stats (always the same)

        //If button amount is one, place the button in the middle
        //If button amount is two, place them side by side

        //
    }

    void ClosePopUp()
    {
        //Closes the popup. Accessible at least from the "Ok", "No" and "Cancel" buttons. Also when user clicks outside of the popup
    }
}
