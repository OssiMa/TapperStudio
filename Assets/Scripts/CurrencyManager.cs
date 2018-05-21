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

    [HideInInspector]
    Achievements achievements;

    bool isAchieved = false;
    bool isAchieved2 = false;
    bool isAchieved3 = false;
    bool isAchieved4 = false;
    bool isAchieved5 = false;
    // public int amountOfCurrency;

    // Use this for initialization
    void Start ()
    {
        currency = 0;
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

        if (currency > 0 && !isAchieved)
        {
            isAchieved = true;
            achievements.AchievementDone(10);
        }
        else if (currency > 100 && !isAchieved2)
        {
            isAchieved2 = true;
            achievements.AchievementDone(10);
        }
        else if (currency > 1000 && !isAchieved3)
        {
            isAchieved3 = true;
            achievements.AchievementDone(10);
        }
        else if (currency > 10000 && !isAchieved4)
        {
            isAchieved4 = true;
            achievements.AchievementDone(10);
        }
        else if (currency > 100000 && !isAchieved5)
        {
            isAchieved5 = true;
            achievements.AchievementDone(10);
        }
    }

    public void AddCurrency(int amountofCurrency)
    {
        currency += amountofCurrency;
        currencyText.text = "" + currency;
    }

    public void LoseCurrency(int amountofCurrency)
    {
        currency -= amountofCurrency;
        currencyText.text = "" + currency;
    }

    public void AddPremiumCurrency(int amountofCurrency)
    {
        premiumCurrency += amountofCurrency;
        premiumCurrencyText.text = "" + premiumCurrency;
    }

    public void LosePremiumCurrency(int amountofCurrency)
    {
        premiumCurrency -= amountofCurrency;
        premiumCurrencyText.text = "" + premiumCurrency;
    }
}
