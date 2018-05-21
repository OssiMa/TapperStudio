using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {

    #region Singleton

    public static CurrencyManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Paska koodaaja nyt on 2 Rahakonetta");
            return;
        }

        instance = this;
    }

    #endregion

    [HideInInspector]
    public int currency = 20;
    [HideInInspector]
    public int premiumCurrency = 20;

    public Text currencyText;
    public Text premiumCurrencyText;
    public GameObject noMoney;

    [HideInInspector]
   // public int amountOfCurrency;

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
        currency += amountofCurrency;
        currencyText.text = "" + currency;
    }

    public bool LoseCurrency(int amountofCurrency)
    {
        if (currency - amountofCurrency < 0)
        {
            StartCoroutine(NoMoneyWarning());
            print("Not enough currency, no currency chances were made");

            return false;
        }
        else
        {
            currency -= amountofCurrency;
            currencyText.text = "" + currency;
            return true;
        }

    }

    public void AddPremiumCurrency(int amountofCurrency)
    {
        premiumCurrency += amountofCurrency;
        premiumCurrencyText.text = "" + premiumCurrency;
    }

    public bool LosePremiumCurrency(int amountofCurrency)
    {
        if (premiumCurrency - amountofCurrency < 0)
        {
            print("Not enough currency, no currency chances were made");
            return false;
        }
        else
        {
            premiumCurrency -= amountofCurrency;
            premiumCurrencyText.text = "" + premiumCurrency;
            return true;
        }

    }

    IEnumerator NoMoneyWarning()
    {
        print("jaa");
        noMoney.SetActive(true);
        yield return new WaitForSeconds(3f);
        noMoney.SetActive(false);
    }
}
