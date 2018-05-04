using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Shop : MonoBehaviour {
                  
    SkinInventory skinInv;
    NewItemGenerator nig;
    CurrencyManager cm;

    Item item;

    public int purchasedItemRarityRare;
    public int purchasedItemRarityMixed;
    public int purchasedItemRarityCommon;

    public int commonItemCost;
    public int mixedItemCost;
    public int rareItemCost;
    public int skinCost;
    public int premiumSkinCost;
    public int adBonus;

    public void PurchaseCurrencySmall()
    {
        PurchaseManager.purchaseManager.BuyCurrencySmall();
    }

    public void PurchaseCurrencyMedium()
    {
        PurchaseManager.purchaseManager.BuyCurrencyMedium();
    }

    public void PurchaseCurrencyBig()
    {
        PurchaseManager.purchaseManager.BuyCurrencyBig();
    }

    public void WatchAd()
    {
        print("Here we are again...");
        if (Advertisement.IsReady())
        {
            Advertisement.Show(new ShowOptions() { resultCallback = WatchAdResult});    //"" = name of the video
        }
    }

    void WatchAdResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            cm.AddCurrency(adBonus);
        }
        else if (result == ShowResult.Skipped)
        {
            cm.AddCurrency(adBonus);
        }
        else if (result == ShowResult.Failed)
        {
            print("Uhh the ad FAILED 0_0");
        }
        else
        {
            print("Something rather horrifying has happened related to the ads");
        }

        /*switch (result)
        {
            case ShowResult.Finished:
                cm.AddCurrency(adBonus);
                break;

            case ShowResult.Failed:
                print("Uhh the ad FAILED 0_0");
                break;
        }*/
    }

    /*void PurchaseNoAdds()
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
    }*/

    public void PurchaseSkin()
    {
        skinInv = GetComponent<SkinInventory>();
        cm = GetComponent<CurrencyManager>();

        skinInv.UnlockSkinNormal();       //not tested
        cm.LoseCurrency(skinCost);
    }

    public void PurchaseSkinPremium()
    {
        cm = GetComponent<CurrencyManager>();
        skinInv = GetComponent<SkinInventory>();

        skinInv.UnlockSkinPremium();       //not tested
        cm.LoseCurrency(premiumSkinCost);
    }

    public void PurchaseRareItem()
    {
        cm = GetComponent<CurrencyManager>();
        nig = GetComponent<NewItemGenerator>();

        purchasedItemRarityRare = 3;

        nig.NewItem(purchasedItemRarityRare);
        cm.LoseCurrency(rareItemCost);
    }

    public void PurchaseMixedItem()
    {
        cm = GetComponent<CurrencyManager>();
        nig = GetComponent<NewItemGenerator>();

        purchasedItemRarityMixed = Random.Range(1,3);

        nig.NewItem(purchasedItemRarityMixed);
        cm.LoseCurrency(mixedItemCost);
    }

    public void PurchaseCommonItem()
    {
        cm = GetComponent<CurrencyManager>();
        nig = GetComponent<NewItemGenerator>();

        purchasedItemRarityCommon = 1;

        nig.NewItem(purchasedItemRarityCommon);
        cm.LoseCurrency(commonItemCost);
    }
}
