﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;


public class PurchaseManager : MonoBehaviour, IStoreListener {

    public static PurchaseManager purchaseManager
    {
        set;
        get;
    }

    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    //Our products and their names given in the Google Play Dev Console.
    public static string PURCHASE_GETCURRENCY_SMALL = "consumable";       //Replace the "consumable" with whatever we name the product in the Google Play Dev Console
    public static string PURCHASE_GETCURRENCY_MEDIUM = "consumable2";     //Replace the "consumable" with whatever we name the product in the Google Play Dev Console
    public static string PURCHASE_GETCURRENCY_BIG = "consumable3";        //Replace the "consumable" with whatever we name the product in the Google Play Dev Console
    public static string PURCHASE_GETNOADS = "nonconsumable";     //Replace the "non-consumable" with whatever we name the product in the Google Play Dev Console
    public static string kProductIDSubscription = "subscription";

    // Google Play Store-specific product identifier subscription product.
    private static string kProductNameGooglePlaySubscription = "com.unity3d.subscription.original";

    CurrencyManager cm;

    void Awake()
    {
        purchaseManager = this;
    }

    void Start()
    {
        cm = GetComponent<CurrencyManager>();

        if (m_StoreController == null)
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Our products, with their consumable types
        builder.AddProduct(PURCHASE_GETCURRENCY_SMALL, ProductType.Consumable);       // Consumable purchase = something you can purchase over and over
        builder.AddProduct(PURCHASE_GETCURRENCY_MEDIUM, ProductType.Consumable);
        builder.AddProduct(PURCHASE_GETCURRENCY_BIG, ProductType.Consumable);

        builder.AddProduct(PURCHASE_GETNOADS, ProductType.NonConsumable);     // Non-consumable purchase = something you can purchase only once

        //Below is a builder for a subscription product, which we aren't planning to use atm. I'll leave it here for refence or if we need for some reason.

        /*builder.AddProduct(kProductIDSubscription, ProductType.Subscription, new IDs(){
            { kProductNameGooglePlaySubscription, GooglePlay.Name },
        });*/

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    // The next four methods are for buying the consumable product using its general identifier. Expect a response either 
    // through ProcessPurchase or OnPurchaseFailed asynchronously.

    public void BuyCurrencySmall()
    {
        BuyProductID(PURCHASE_GETCURRENCY_SMALL);
    }

    public void BuyCurrencyMedium()
    {
        BuyProductID(PURCHASE_GETCURRENCY_MEDIUM);
    }

    public void BuyCurrencyBig()
    {
        BuyProductID(PURCHASE_GETCURRENCY_BIG);
    }

    public void BuyNoAds()      
    {
        BuyProductID(PURCHASE_GETNOADS);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");

        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // A consumable product has been purchased by the user.
        if (System.String.Equals(args.purchasedProduct.definition.id, PURCHASE_GETCURRENCY_SMALL, System.StringComparison.Ordinal))
        {
            //The currency has been purchased. Add the currency to the existing currency.
            cm.AddCurrency(5);
            Debug.Log("You purchased 5 diamonds or whatever we call these. We thank you but also hope you go buy some more because this is only enough for like one beer, if that.");
        }
        else if (System.String.Equals(args.purchasedProduct.definition.id, PURCHASE_GETCURRENCY_MEDIUM, System.StringComparison.Ordinal))
        {
            //The currency has been purchased. Add the currency to the existing currency.
            cm.AddCurrency(10);
            Debug.Log("You purchased 10 diamonds or whatever we call these. This is better, but come on, we're greedy bastards. Give us money!!");
        }
        // Or ... a subscription product has been purchased by this user.
        else if (System.String.Equals(args.purchasedProduct.definition.id, PURCHASE_GETCURRENCY_BIG, System.StringComparison.Ordinal))
        {
            //The currency has been purchased. Add the currency to the existing currency.
            cm.AddCurrency(50);
            Debug.Log("You purchased 50 diamonds or whatever we call these. Okay, now we're talking! Here I come, Jamaica!");
        }
        else if (System.String.Equals(args.purchasedProduct.definition.id, PURCHASE_GETNOADS, System.StringComparison.Ordinal))
        {
            //The player gave money to get rid of the adds. Stop the adds from playing.
            Debug.Log("Thaaank youuu!");
        }
        // An unknown product has been purchased by this user
        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        // Return a flag indicating whether this product has completely been received, or if the application needs 
        // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
        // saving purchased products to the cloud, and when that save is delayed. 
        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
