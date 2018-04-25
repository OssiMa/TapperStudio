using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpDisplay : MonoBehaviour {

    public PopUp popUp;

    bool statsVisible;
    bool picVisible;
    //Getting this should be automated as well - only the Scriptable should be manual
                                                        //These can be created as children, too

    int buttonAmount;

    GameObject button1;
    GameObject button2;

    float sizeX;
    float sizeY;

    Image pic;
    //Sprite pic;

    void Start()
    {
        statsVisible = popUp.statsVisible;
        picVisible = popUp.picVisible;

        SetText();

        if (picVisible == true)
        {
            SetPicture();
        }

        SetBg();

        buttonAmount = popUp.buttonAmount;  //How many buttons there are (1 or 2)

        button1 = popUp.button1;      //The first button
        button2 = popUp.button2;        //The second button

        SetPopupSize();

        SetButtons();

        SetPopupSize();
    }

    void ActivatePopup()
    {
        //Set the pop up object active
        //or create it, or whatever

        SetBg();

        //Put everything from Start() to here once finished
        statsVisible = popUp.statsVisible;
        picVisible = popUp.picVisible;

        SetText();

        if (picVisible == true)
        {
            SetPicture();
        }

        buttonAmount = popUp.buttonAmount;  //How many buttons there are (1 or 2)

        button1 = popUp.button1;      //The first button
        button2 = popUp.button2;        //The second button

        SetPopupSize();

        SetButtons();

        SetPopupSize();
    }

    void SetText()
    {
        GameObject descriptionText;

        descriptionText = GameObject.Find("Popup Description");

        Text textItself = descriptionText.GetComponent<Text>();

        textItself.enabled = true;
        textItself.text = popUp.description;     //What it says on the PopUp. ("You got x gold!", etc.)
        textItself.alignment = TextAnchor.MiddleCenter;

        if (statsVisible == true)
        {
            GameObject emptyStats = GameObject.Find("Empty Stats");

            List<Transform> emptyStatses = new List<Transform>();

            List<Text> statTexts = new List<Text>();

            for (int i = 0; i < 4; i++)
            {  
                emptyStatses.Add(emptyStats.transform.GetChild(i));
                statTexts.Add(emptyStatses[i].GetComponent<Text>());
                //statTexts[i] = emptyStatses[i].GetComponent<Text>();
                statTexts[i].text = popUp.stats[i];
            }


            /*for (int i = 0; i < 3; i++)
            {
                statTexts[i] = emptyStatses[i].GetComponent<Text>();
                statTexts[i].text = popUp.stats[i];
            }*/

            statTexts[0].alignment = TextAnchor.LowerRight;
            statTexts[1].alignment = TextAnchor.LowerRight;
            statTexts[2].alignment = TextAnchor.LowerRight;
            statTexts[3].alignment = TextAnchor.LowerRight;
        }
    }

    void SetButtons()
    {
        if (buttonAmount == 1)
        {
            GameObject button = Instantiate(button1, new Vector3(0, 0, 0), Quaternion.identity);
            button.transform.SetParent(GameObject.Find("Menu").transform);

            RectTransform buttonPos = button.GetComponent<RectTransform>();
            buttonPos.anchoredPosition = new Vector2(0, -101);
        }
        else if (buttonAmount == 2)
        {
            //Button one
            GameObject buttonOne = Instantiate(button1, new Vector3(0, 0, 0), Quaternion.identity);
            buttonOne.transform.SetParent(GameObject.Find("Menu").transform);

            RectTransform buttonPos1 = buttonOne.GetComponent<RectTransform>();
            buttonPos1.anchoredPosition = new Vector2(87, -101);

            //Button two
            GameObject buttonTwo = Instantiate(button2, new Vector3(0, 0, 0), Quaternion.identity);
            buttonTwo.transform.SetParent(GameObject.Find("Menu").transform);

            RectTransform buttonPos2 = buttonTwo.GetComponent<RectTransform>();
            buttonPos2.anchoredPosition = new Vector2(104, -101);
        }
    }

    void SetPicture()
    {
        GameObject emptyPic = GameObject.Find("Empty PopUp Image");

        Image emptyPicImage = emptyPic.GetComponent<Image>();

        emptyPicImage.sprite = popUp.pic;
        emptyPicImage.enabled = true;
    }

    void SetBg()
    {
        Image img;
        img = GetComponent<Image>();

        img.sprite = popUp.bg;
    }

    void SetPopupSize()
    {
        sizeX = popUp.sizeX;      //Size of the popup
        sizeY = popUp.sizeY;
        transform.localScale = new Vector3(sizeX, sizeY, 0);  //Not sure this will work since it happens on the canvas
    }

    void ClosePopUp()
    {
        
    }
}
