using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    CurrencyManager cm;                    
    Inventory inv;

    bool purchaseConfirmed;
    bool clicked;

    List<Item> rareItems = new List<Item>();
    List<Item> uncommonItems = new List<Item>();
    List<Item> commonItems = new List<Item>();

    Item item;

    string itemRarity;

    public float currency = 0;
    //public Text currencyText;

    // Use this for initialization
    void Start ()
    {
        //sp = GetComponent<SongProgress>();
        inv = GetComponent<Inventory>();
        cm = GetComponent<CurrencyManager>();

        clicked = false;

        //items = Get list of items
        //get the items with a for loop? Basically get items until you have a full list
        //...can there be a for loop in the start method?

        for (int i = 1; i <= 10; i++)
        {
            //Get an item with a tag or something
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (clicked == true)//&& popup still exists
        {
            //Make the popup go away
        }
    }

    void PurchaseCurrencySmall()
    {
        //When a thing is pressed, a purchase happens
        //Note: The purchase won't actually happen here in the final game, instead this method will activate the popup which has the options
        //'yes'/'no' for the purchase. Pressign 'yes' will complete the purchase.

        PopUp();

        if (clicked == true)
        {
            if (purchaseConfirmed == true)
            {
                PurchaseManager.purchaseManager.BuyCurrencySmall();
                clicked = false;
                ConfirmPopUp();
            }
        }
    }

    void PurchaseCurrencyMedium()
    {
        PopUp();

        if (clicked == true)
        {
            if (purchaseConfirmed == true)
            {
                PurchaseManager.purchaseManager.BuyCurrencyMedium();
                clicked = false;
                ConfirmPopUp();
            }
        }
    }

    void PurchaseCurrencyBig()
    {
        PopUp();

        if (clicked == true)
        {
            if (purchaseConfirmed == true)
            {
                PurchaseManager.purchaseManager.BuyCurrencyBig();
                clicked = false;
                ConfirmPopUp();
            }
        }
    }

    void PurchaseNoAdds()
    {
        PopUp();

        if (clicked == true)
        {
            if (purchaseConfirmed == true)
            {
                PurchaseManager.purchaseManager.BuyNoAds();
                clicked = false;
                ConfirmPopUp();
            }
        }
    }

    void PurchaseSkin()
    {
        if (clicked == true)
        {
            PopUp();

            if (purchaseConfirmed == true)
            {
                //Still unclear on how we'll do this, make this happen once everything else is done

                currency -= 5000;
                clicked = false;
                ConfirmPopUp();
            }
        }
    }

    void PurchaseRareItem()
    {
        //Randomize an item (from a list?) and add it to the player's Inventory (Inventory.AddItem(item)). 
        //I guess items are going to be given their identity through ScriptableObjects, so basically we would pick a random ScriptableObject for an item object?
        PopUp();

        if (clicked == true)
        {
            if (purchaseConfirmed == true)
            {
                itemRarity = "Rare";

                RandomizeItem();

                //item = the item from the randomization

                //inv.AddItem(item);

                currency -= 5000;
                clicked = false;
                ConfirmPopUp();
            }
        }
    }

    void PurchaseUncommonItem()
    {
        //Randomize an item (from a list?) and add it to the player's Inventory (Inventory.AddItem(item)). 
        //I guess items are going to be given their identity through ScriptableObjects, so basically we would pick a random ScriptableObject for an item object?
        PopUp();

        if (clicked == true)
        {
            if (purchaseConfirmed == true)
            {
                itemRarity = "Uncommon";

                RandomizeItem();

                //item = the item from the randomization

                //inv.AddItem(item);

                currency -= 5000;
                clicked = false;
                ConfirmPopUp();
            }
        }
    }

    void PurchaseCommonItem()
    {
        //Randomize an item (from a list?) and add it to the player's Inventory (Inventory.AddItem(item)). 
        //I guess items are going to be given their identity through ScriptableObjects, so basically we would pick a random ScriptableObject for an item object?
        PopUp();

        if (clicked == true)
        {
            if (purchaseConfirmed == true)
            {
                itemRarity = "Common";

                RandomizeItem();

                //inv.AddItem(item);

                currency -= 5000;
                clicked = false;
                ConfirmPopUp();
            }
        }
    }

    void RandomizeItem()
    {
        if (itemRarity == "Rare")
        {
            //Take an item from the 'rareItems' list by random
            //item = the item from the randomization
        }
        else if (itemRarity == "Uncommon")
        {
            //Take an item from the 'uncommonItems' list by random
            //item = the item from the randomization
        }
        else if (itemRarity == "Common")
        {
            //Take an item from the 'commonItems' list by random
            //item = the item from the randomization
        }
    }

    void PopUp()
    {
        //Create popup for the current purchase with yes/no options
    }

    void ConfirmPopUp()
    {
        //"You got ___!"
        //"Ok" to make it go away
    }

    void Yes()
    {
        purchaseConfirmed = true;
        clicked = true;
        //Could the popup be destroyed over here?
    }

    void No()
    {
        purchaseConfirmed = false;
        clicked = true;
        //Could the popup be destroyed over here?
    }

    void Ok()
    {
        //Destroys the ConfirmPopUp
    }
}
