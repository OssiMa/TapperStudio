using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpDisplay : MonoBehaviour {

    public PopUp popUp;

    Purposes? purpose = null;
    //AddCurrencyAmount addCurrencyAmount;
    //BoughtItem boughtItem;

    GameObject gm;
    CurrencyManager currencyManager;
    NewItemGenerator nig;
    Shop shop;

    [HideInInspector]
    public int removeCurrencyAmount;

    //GameObject popUpFrame;

    bool statsVisible;
    bool picVisible;

    int buttonAmount;

    GameObject button1;
    GameObject button2;

    float buttonPos1X;
    float buttonPos1Y;
    float buttonPos2X;
    float buttonPos2Y;

    Image emptyPicImage;
    Image bg;

    float sizeX;
    float sizeY;
    float posX;
    float posY;

    GameObject InvSlot;
    GameObject NewInvSlot;

    Text textItself;

    List<Transform> emptyStatses;
    List<Text> statTexts;

    int rarityValue;

    /*void Start()
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
    }*/

    public void ActivatePopup()
    {
        gm = GameObject.Find("GameManager");
        shop = gm.GetComponent<Shop>();

        purpose = popUp.purpose;

        //removeCurrencyAmount = popUp.removeCurrencyAmount;

        //addCurrencyAmount = popUp.addCurrencyAmount;

        currencyManager = gm.GetComponent<CurrencyManager>();
        nig = gm.GetComponent<NewItemGenerator>();

        popUp.popUpFrame = GameObject.Find("Empty PopUp Background");

        SetBg();

        statsVisible = popUp.statsVisible;
        SetText();

        picVisible = popUp.picVisible;
        if (picVisible == true)
        {
            SetPicture();
        }

        SetPopupSize();

        buttonAmount = popUp.buttonAmount;
        SetButtons();

        SetPopupSize();
    }

    /*public void Purpose()
    {
        //currencyManager.currency -= currencyAmount;
        if (purpose == Purposes.removeCurrency)
        {
            if (boughtItem == BoughtItem.rareItem)
            {
                rarityValue = Random.Range(0, 4);
                nig.NewItem(rarityValue);   
            }
            else if (boughtItem == BoughtItem.commonItem)
            {
                //Rarity from a random range of 4-10
                rarityValue = Random.Range(4, 10);
                nig.NewItem(rarityValue);
            }
            else if (boughtItem == BoughtItem.allRarityItem)
            {
                //Rarity from a random range of 1-10
                rarityValue = Random.Range(1, 10);
                nig.NewItem(rarityValue); 
            }
            currencyManager.currency -= removeCurrencyAmount;
        }
        else if (purpose == Purposes.addCurrency)
        {
            if (addCurrencyAmount == AddCurrencyAmount.small)
            {
                PurchaseManager.purchaseManager.BuyCurrencySmall();
            }
            else if (addCurrencyAmount == AddCurrencyAmount.medium)
            {
                PurchaseManager.purchaseManager.BuyCurrencyMedium();
            }
            else if (addCurrencyAmount == AddCurrencyAmount.big)
            {
                PurchaseManager.purchaseManager.BuyCurrencyBig();
            }
        }
        ClosePopUp();
    }*/

    public void Purpose()
    {
        gm = GameObject.Find("GameManager");
        shop = gm.GetComponent<Shop>();

        if (purpose == Purposes.rareItem)
        {
            shop.PurchaseRareItem();
        }
        else if (purpose == Purposes.commonItem)
        {
            shop.PurchaseCommonItem();
        }
        else if (purpose == Purposes.allRarityItem)
        {
            shop.PurchaseMixedItem();
        }
        else if (purpose == Purposes.skin)
        {
            shop.PurchaseSkin();
        }
        else if (purpose == Purposes.skinPremium)
        {
            shop.PurchaseSkinPremium();
        }
        else if (purpose == Purposes.addCurrencySmall)
        {
            shop.PurchaseCurrencySmall();
        }
        else if (purpose == Purposes.addCurrencyMedium)
        {
            shop.PurchaseCurrencyMedium();
        }
        else if (purpose == Purposes.addCurrencyBig)
        {
            shop.PurchaseCurrencyBig();
        }
        else if (purpose == Purposes.watchAd)          //if purpose is something else, don't watch ad
        {
            shop.WatchAd();
        }
        print(purpose);
        purpose = null;
        ClosePopUp();
    }

    public void Print()
    {
        print("metodi");
    }

    void SetBg()
    {
        bg = popUp.popUpFrame.GetComponent<Image>();

        bg.sprite = popUp.bg;

        bg.enabled = true;
    }

    void SetText()
    {
        GameObject descriptionText;

        descriptionText = GameObject.Find("Popup Description");

        textItself = descriptionText.GetComponent<Text>();

        textItself.enabled = true;
        textItself.text = popUp.description;
        textItself.alignment = TextAnchor.MiddleCenter;

        if (statsVisible == true)
        {
            GameObject emptyStats = GameObject.Find("Empty Stats");

            emptyStatses = new List<Transform>();

            statTexts = new List<Text>();

            for (int i = 0; i < 4; i++)
            {  
                emptyStatses.Add(emptyStats.transform.GetChild(i));
                statTexts.Add(emptyStatses[i].GetComponent<Text>());
                statTexts[i].text = popUp.stats[i];
            }

            foreach (Text statText in statTexts)
            {
                statText.enabled = true;
            }

            statTexts[0].alignment = TextAnchor.MiddleLeft;
            statTexts[1].alignment = TextAnchor.MiddleLeft;
            statTexts[2].alignment = TextAnchor.MiddleLeft;
            statTexts[3].alignment = TextAnchor.MiddleLeft;
        }
    }

    void SetButtons()
    {
        if (buttonAmount == 1)
        { 
            button1 = GameObject.Find(popUp.buttonOne);

            button1.GetComponent<Image>().enabled = true;
            button1.GetComponent<Button>().enabled = true;

            button1.transform.GetChild(0).GetComponent<Text>().enabled = true;

            buttonPos1X = popUp.buttonPos1X;
            buttonPos1Y = popUp.buttonPos1Y;

            RectTransform buttonPos = button1.GetComponent<RectTransform>();
            buttonPos.anchoredPosition = new Vector2(buttonPos1X, buttonPos1Y);
        }
        else if (buttonAmount == 2)
        {
            button1 = GameObject.Find(popUp.buttonOne);
            button2 = GameObject.Find(popUp.buttonTwo);

            button1.GetComponent<Image>().enabled = true;
            button2.GetComponent<Image>().enabled = true;

            button1.GetComponent<Button>().enabled = true;
            button2.GetComponent<Button>().enabled = true;

            buttonPos1X = popUp.buttonPos1X;
            buttonPos1Y = popUp.buttonPos1Y;

            buttonPos2X = popUp.buttonPos2X;
            buttonPos2Y = popUp.buttonPos2Y;

            button1.transform.GetChild(0).GetComponent<Text>().enabled = true;
            button2.transform.GetChild(0).GetComponent<Text>().enabled = true;

            RectTransform buttonPos1 = button1.GetComponent<RectTransform>();
            buttonPos1.anchoredPosition = new Vector2(buttonPos1X, buttonPos1Y);

            RectTransform buttonPos2 = button2.GetComponent<RectTransform>();
            buttonPos2.anchoredPosition = new Vector2(buttonPos2X, buttonPos2Y);
        }
    }

    void SetPicture()
    {
        GameObject emptyPic = GameObject.Find("Empty PopUp Image");

        emptyPicImage = emptyPic.GetComponent<Image>();

        emptyPicImage.sprite = popUp.pic;
        emptyPicImage.enabled = true;
    }

    void SetPopupSize()
    {
        sizeX = popUp.sizeX;      //Size of the popup
        sizeY = popUp.sizeY;
        posX = popUp.posX;
        posY = popUp.posY;
        popUp.popUpFrame.transform.localScale = new Vector3(sizeX, sizeY, 0);  //Not sure this will work since it happens on the canvas
        popUp.popUpFrame.transform.localPosition = new Vector2(posX, posY);
    }

    public void SetSelectedInvSlot(GameObject invslot)
    {
        popUp.selectedInvSlot = invslot;
        InventorySlot slotscript = invslot.GetComponent<InventorySlot>();
        popUp.selectedItem = slotscript.GetItem();
    }

    public void SetInventoryPopUp()
    {
        InvSlot = GameObject.Find("Empty InventorySlot");
        popUp.popUpFrame = GameObject.Find("Empty PopUp Background");

        if (InvSlot.transform.childCount >0)
        {
            Destroy(NewInvSlot);
        }

        NewInvSlot = Instantiate(popUp.selectedInvSlot, InvSlot.transform);
        RectTransform rt = NewInvSlot.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(52,52);

        SetBg();

        statsVisible = popUp.statsVisible;
        SetText();
        SetItemStats();

        picVisible = popUp.picVisible;
        if (picVisible == true)
        {
            SetPicture();
        }


        SetPopupSize();

        buttonAmount = popUp.buttonAmount;
        SetButtons();

        SetPopupSize();
    }

    void SetItemStats()
    {
        statTexts[0].text = popUp.selectedItem.itemName;
        statTexts[1].text = "Rarity: " + popUp.selectedItem.rarity;
        statTexts[2].text = "Effect: " + popUp.selectedItem.boosts;
        statTexts[3].text = "Item Level: " + popUp.selectedItem.level;
    }

    public void ClosePopUp()
    {
        //There could be something that indicates what closing the popup will do

        //Hide the the main text (description)
        GameObject descriptionText;
        descriptionText = GameObject.Find("Popup Description");
        textItself = descriptionText.GetComponent<Text>();
        textItself.enabled = false;

        //Empty stats & stat texts
        if (statsVisible == true)
        {
            emptyStatses.Clear();

            foreach (Text statText in statTexts)
            {
                statText.enabled = false;
            }

            statTexts.Clear();
        }

        //Destroy one button
        if (buttonAmount == 1)
        {
            button1.GetComponent<Image>().enabled = false;
            button1.GetComponent<Button>().enabled = false;

            button1.transform.GetChild(0).GetComponent<Text>().enabled = false;
        }
        //Destroy two buttons
        else if (buttonAmount == 2)
        {
            button1.GetComponent<Image>().enabled = false;
            button1.GetComponent<Button>().enabled = false;

            button1.transform.GetChild(0).GetComponent<Text>().enabled = false;

            button2.GetComponent<Image>().enabled = false;
            button2.GetComponent<Button>().enabled = false;

            button2.transform.GetChild(0).GetComponent<Text>().enabled = false;
        }

        //Hide image
        if (picVisible == true)
        {
            emptyPicImage.enabled = false;
        }

        //Deselect inventoy slot
        if (popUp.selectedInvSlot != null)
        {
            popUp.selectedInvSlot = null;
        }

        //Destroy inventory popup slot
        if (InvSlot.transform.childCount > 0)
        {
            Destroy(NewInvSlot);
        }

        //Hide the popup frame
        popUp.popUpFrame = GameObject.Find("Empty PopUp Background");
        bg = popUp.popUpFrame.GetComponent<Image>();
        bg.sprite = popUp.bg;
        bg.enabled = false;

        //The popup should now be closed
    }
}
