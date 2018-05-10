using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {

    [HideInInspector]
    public int currency = 20;
    [HideInInspector]
    public int premiumCurrency = 20;

    public Text currencyText;
    public Text premiumCurrencyText;

    [HideInInspector]
    public int amountOfCurrency;

    // Use this for initialization
    void Start ()
    {
        currency = 20;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currencyText.text = currency + "£";

        if (currency < 0)
        {
            currency = 0;
        }

        //premiumCurrencyText.text = premiumCurrency + "£";

        if (premiumCurrency < 0)
        {
            premiumCurrency = 0;
        }
    }

    public void AddCurrency(int amountofCurrency)
    {
        currency += amountOfCurrency;
    }

    public void LoseCurrency(int amountofCurrency)
    {
        currency -= amountOfCurrency;
    }

    public void AddPremiumCurrency(int amountofCurrency)
    {
        premiumCurrency += amountOfCurrency;
    }

    public void LosePremiumCurrency(int amountofCurrency)
    {
        premiumCurrency -= amountOfCurrency;
    }
}
