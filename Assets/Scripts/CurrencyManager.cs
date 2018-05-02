using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {

    [HideInInspector]
    public int currency = 20;

    public Text currencyText;

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
    }

    public void AddCurrency(int amountofCurrency)
    {
        currency += amountOfCurrency;
    }

    public void LoseCurrency(int amountofCurrency)
    {
        print("amount lost" + amountOfCurrency);
        currency -= amountOfCurrency;
        print("currency" + currency);
    }
}
