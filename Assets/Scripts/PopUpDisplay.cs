using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpDisplay : MonoBehaviour {

    public PopUp popUp;
    public PopUp craftWindow;

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
    bool infoVisible;

    bool craftMode = false;

    int buttonAmount;

    GameObject button1;
    GameObject button2;
    GameObject button3;

    float buttonPos1X;
    float buttonPos1Y;
    float buttonPos2X;
    float buttonPos2Y;
    float buttonPos3X;
    float buttonPos3Y;

    Image emptyPicImage;
    Image bg;

    float sizeX;
    float sizeY;
    float posX;
    float posY;

    GameObject InvSlot;
    GameObject InvSlot2;
    GameObject NewInvSlot;
    GameObject NewInvSlot2;

    Text textItself;

    List<Transform> emptyStatses;
    List<Text> statTexts;

    List<Transform> emptyInfo;
    List<Text> infoTexts;

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

        infoVisible = popUp.infoVisible;
        statsVisible = popUp.statsVisible;
        SetText();

        picVisible = popUp.picVisible;
        if (picVisible == true)
        {
            SetPicture();
        }

        if (infoVisible == true)
        {
            SetInfoStats();
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
            //shop.WatchAd();
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

        if(infoVisible == true)
        {
            GameObject InfoText = GameObject.Find("Empty Info");

            emptyInfo = new List<Transform>();

            infoTexts = new List<Text>();

            for (int i = 0; i<2; i++)
            {
                emptyInfo.Add(InfoText.transform.GetChild(i));
                infoTexts.Add(emptyInfo[i].GetComponent<Text>());
                infoTexts[i].text = popUp.info[i];

                foreach (Text infotext in infoTexts)
                {
                    infotext.enabled = true;
                    infotext.alignment = TextAnchor.MiddleCenter;
                }
            }
        }

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
        else if (buttonAmount == 3)
        {
            button1 = GameObject.Find(popUp.buttonOne);
            button2 = GameObject.Find(popUp.buttonTwo);
            button3 = GameObject.Find(popUp.buttonThree);

            button1.GetComponent<Image>().enabled = true;
            button2.GetComponent<Image>().enabled = true;
            button3.GetComponent<Image>().enabled = true;

            button1.GetComponent<Button>().enabled = true;
            button2.GetComponent<Button>().enabled = true;
            button3.GetComponent<Button>().enabled = true;

            buttonPos1X = popUp.buttonPos1X;
            buttonPos1Y = popUp.buttonPos1Y;

            buttonPos2X = popUp.buttonPos2X;
            buttonPos2Y = popUp.buttonPos2Y;

            buttonPos3X = popUp.buttonPos3X;
            buttonPos3Y = popUp.buttonPos3Y;

            button1.transform.GetChild(0).GetComponent<Text>().enabled = true;
            button2.transform.GetChild(0).GetComponent<Text>().enabled = true;
            button3.transform.GetChild(0).GetComponent<Text>().enabled = true;

            RectTransform buttonPos1 = button1.GetComponent<RectTransform>();
            buttonPos1.anchoredPosition = new Vector2(buttonPos1X, buttonPos1Y);

            RectTransform buttonPos2 = button2.GetComponent<RectTransform>();
            buttonPos2.anchoredPosition = new Vector2(buttonPos2X, buttonPos2Y);

            RectTransform buttonPos3 = button3.GetComponent<RectTransform>();
            buttonPos3.anchoredPosition = new Vector2(buttonPos3X, buttonPos3Y);
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
        
        if (craftMode == false)
        {
            InvSlot = GameObject.Find("Empty InventorySlot");
            InvSlot2 = GameObject.Find("Empty InventorySlot2");
            popUp.popUpFrame = GameObject.Find("Empty PopUp Background");
            ClosePopUp();

            if (InvSlot.transform.childCount > 0)
            {
                Destroy(NewInvSlot);
            }
            if (InvSlot2.transform.childCount > 0)
            {
                Destroy(NewInvSlot2);
            }

            NewInvSlot = Instantiate(popUp.selectedInvSlot, InvSlot.transform);
            RectTransform rt = NewInvSlot.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(52, 52);
            Button btn = NewInvSlot.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.disabledColor = new Color32(255,255,255,255);
            btn.colors = cb;
            btn.interactable = false;

            SetBg();

            statsVisible = popUp.statsVisible;
            SetText();

            if (statsVisible == true)
            {
                SetItemStats();
            }

            picVisible = popUp.picVisible;
            if (picVisible == true)
            {
                SetPicture();
            }

            SetPopupSize();

            buttonAmount = popUp.buttonAmount;
            SetButtons();

            if (popUp.selectedItem.level > 2 && popUp.buttonOne == "Upgrade")
            {
                button1.GetComponent<Button>().interactable = false;
                button1.GetComponentInChildren<Text>().text = "Maxed out";
            }
            else if (popUp.buttonOne == "Upgrade")
            {
                button1.GetComponent<Button>().interactable = true;
                button1.GetComponentInChildren<Text>().text = "Upgrade";
            }

            SetPopupSize();
        }
        else if(craftMode == true)
        {
            InvSlot2 = GameObject.Find("Empty InventorySlot2");
            if (InvSlot2.transform.childCount > 0)
            {
                Destroy(NewInvSlot2);
            }
            NewInvSlot2 = Instantiate(popUp.selectedInvSlot, InvSlot2.transform);

            RectTransform rt2 = NewInvSlot2.GetComponent<RectTransform>();
            rt2.sizeDelta = new Vector2(52, 52);
            Button btn = NewInvSlot2.GetComponent<Button>();
            ColorBlock cb = btn.colors;
            cb.disabledColor = new Color32(255, 255, 255, 255);
            btn.colors = cb;
            btn.interactable = false;

            button1.GetComponent<Button>().interactable = true;
        }
        
    }

    void SetItemStats()
    {
        statTexts[0].text = popUp.selectedItem.itemName;
        statTexts[1].text = "Rarity: " + popUp.selectedItem.rarityName;
        statTexts[2].text = "Effect: " + popUp.selectedItem.boosts;
        statTexts[3].text = "Item Level: " + (popUp.selectedItem.level);
    }

    void SetInfoStats()
    {
        if (popUp.name == "pop_sellItem")
        {
            infoTexts[0].text = popUp.info[0] + (100 * InventoryUI.instance.chosenItem.rarity + (InventoryUI.instance.chosenItem.level * 25));                //BALANCED SELL PRICE
        }
        else if(popUp.name == "pop_upgrade")
        {
            infoTexts[0].text = popUp.info[0] + (50 * InventoryUI.instance.chosenItem.rarity + (InventoryUI.instance.chosenItem.level * 15));                     //BALANCED COST
        }
        infoTexts[1].text = popUp.info[1] + CurrencyManager.instance.currency;
    }

    void CraftingPopUp()
    {
        InvSlot = GameObject.Find("Empty InventorySlot");
        craftWindow.popUpFrame = GameObject.Find("Empty PopUp Background");

        if (InvSlot.transform.childCount > 0)
        {
            Destroy(NewInvSlot);
        }

        NewInvSlot = Instantiate(popUp.selectedInvSlot, InvSlot.transform);
        RectTransform rt = NewInvSlot.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(52, 52);
        Button btn = NewInvSlot.GetComponent<Button>();
        ColorBlock cb = btn.colors;
        cb.disabledColor = new Color32(255, 255, 255, 255);
        btn.colors = cb;
        btn.interactable = false;

        SetBg();

        statsVisible = craftWindow.statsVisible;
        SetText();

        picVisible = craftWindow.picVisible;
        if (picVisible == true)
        {
            SetPicture();
        }

        SetCraftingButton();

        SetPopupSize();
    }

    void SetCraftingButton()
    {
        button1 = GameObject.Find(craftWindow.buttonOne);
        button2 = GameObject.Find(craftWindow.buttonTwo);

        button1.GetComponent<Image>().enabled = true;
        button2.GetComponent<Image>().enabled = true;

        button1.GetComponent<Button>().enabled = true;
        button2.GetComponent<Button>().enabled = true;

        button1.GetComponent<Button>().interactable = false;

        buttonPos1X = craftWindow.buttonPos1X;
        buttonPos1Y = craftWindow.buttonPos1Y;

        buttonPos2X = craftWindow.buttonPos2X;
        buttonPos2Y = craftWindow.buttonPos2Y;

        button1.transform.GetChild(0).GetComponent<Text>().enabled = true;
        button2.transform.GetChild(0).GetComponent<Text>().enabled = true;

        RectTransform buttonPos1 = button1.GetComponent<RectTransform>();
        buttonPos1.anchoredPosition = new Vector2(buttonPos1X, buttonPos1Y);

        RectTransform buttonPos2 = button2.GetComponent<RectTransform>();
        buttonPos2.anchoredPosition = new Vector2(buttonPos2X, buttonPos2Y);
    }

    public void Crafting()
    {
        craftMode = true;
        CraftingPopUp();
    }

    public void CraftingOver()
    {
        craftMode = false;
        ClosePopUp();
    }

   /* public void ItemUpgrade()
    {
        if (popUp.selectedItem.level <3)
        {
            print("lul");
            ActivatePopup();
        }
        else
        {
            print("jees");
            popUp.popUpFrame = GameObject.Find("Empty PopUp Background");

            SetBg();

            statsVisible = popUp.statsVisible;

            GameObject descriptionText;

            descriptionText = GameObject.Find("Popup Description");

            textItself = descriptionText.GetComponent<Text>();

            textItself.enabled = true;
            textItself.text = "Max level reached";
            textItself.alignment = TextAnchor.MiddleCenter;

            picVisible = popUp.picVisible;
            if (picVisible == true)
            {
                SetPicture();
            }

            SetPopupSize();


            button1 = GameObject.Find(popUp.buttonTwo);

            button1.GetComponent<Image>().enabled = true;
            button1.GetComponent<Button>().enabled = true;

            button1.transform.GetChild(0).GetComponent<Text>().enabled = true;

            buttonPos1X = popUp.buttonPos1X;
            buttonPos1Y = popUp.buttonPos1Y;

            RectTransform buttonPos = button1.GetComponent<RectTransform>();
            buttonPos.anchoredPosition = new Vector2(buttonPos1X, buttonPos1Y);

            SetPopupSize();
        }
    }*/

    public void HideButtons()
    {
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
        else if (buttonAmount == 3)
        {
            button1.GetComponent<Image>().enabled = false;
            button1.GetComponent<Button>().enabled = false;

            button1.transform.GetChild(0).GetComponent<Text>().enabled = false;

            button2.GetComponent<Image>().enabled = false;
            button2.GetComponent<Button>().enabled = false;

            button2.transform.GetChild(0).GetComponent<Text>().enabled = false;

            button3.GetComponent<Image>().enabled = false;
            button3.GetComponent<Button>().enabled = false;

            button3.transform.GetChild(0).GetComponent<Text>().enabled = false;
        }
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

        if (infoVisible == true)
        {
            emptyInfo.Clear();

            foreach (Text text in infoTexts)
            {
                text.enabled = false;
            }
        }

        HideButtons();

        //Hide image
        if (picVisible == true)
        {
            emptyPicImage.enabled = false;
        }


        //Destroy inventory popup slot
        InvSlot = GameObject.Find("Empty InventorySlot");
        InvSlot2 = GameObject.Find("Empty InventorySlot2");
        if (InvSlot.transform.childCount > 0)
        {
            Destroy(NewInvSlot);
        }
        if (InvSlot2.transform.childCount > 0)
        {
            Destroy(NewInvSlot2);
        }

        //Hide the popup frame
        popUp.popUpFrame = GameObject.Find("Empty PopUp Background");
        bg = popUp.popUpFrame.GetComponent<Image>();
        bg.sprite = popUp.bg;
        bg.enabled = false;

        //The popup should now be closed
    }
}
