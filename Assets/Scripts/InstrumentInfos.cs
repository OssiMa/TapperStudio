using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InstrumentInfos : MonoBehaviour {

    Sprite[] icons;

    public Text textBox;
    public Text LevelInfo;
    public Text xPNow;
    public Text xPToGo;
    public Image icon;
    public Button vintageButton;
    public Slider xP;
    int shownBase;

    GameObject[] bases;

	// Use this for initialization
	void Awake()
    {
		bases = GameObject.FindGameObjectsWithTag("Instrument").OrderBy(instruments => instruments.name).ToArray();
        icons = Resources.LoadAll<Sprite>("InstrumentIcons");
    }

    public void ShowStatsFor(int x)
    {
        shownBase = x;
        SetTexts();
        SetIcon();
        setBar();
        VintageButton();
    }

    void SetTexts()
    {
        textBox.enabled = true;
        InstrumentBase ins = bases[shownBase - 1].GetComponent<InstrumentBase>();
        textBox.text = "Vintage: " + ins.vintageLevel + "\n\nBoosts from equipment:\nGeneration Boost: " + ins.GetBoosts(1) + "\nAdditional Combo: " 
        + ins.GetBoosts(2) + "\nBonus Experience: " + ins.GetBoosts(3); ;
        LevelInfo.enabled = true;
        LevelInfo.text = "Level: " + ins.level;
        xPNow.enabled = true;
        xPNow.text = "Experience: " + ins.exp;
        xPToGo.enabled = true;
        xPToGo.text = NextLevel(ins);
    }

    string NextLevel(InstrumentBase ins)
    {
        string text;
        if(ins.level < 20)
        {
            text = "Next level at: " + ins.expToNext;
        }
        else
        {
            text = "Max Level Reached";
        }
        return text;
    }

    void SetIcon()
    {
        icon.enabled = true;
        icon.sprite = icons[shownBase-1];
    }

    void setBar()
    {
        xP.gameObject.SetActive(true);
        xP.maxValue = bases[shownBase - 1].GetComponent<InstrumentBase>().xpBar.maxValue;
        xP.minValue = bases[shownBase - 1].GetComponent<InstrumentBase>().xpBar.minValue;
        xP.value = bases[shownBase - 1].GetComponent<InstrumentBase>().xpBar.value;
    }

    public void HideTexts()
    {
        icon.enabled = false;
        textBox.enabled = false;
        textBox.text = "";
        LevelInfo.enabled = false;
        LevelInfo.text = "";
        xPNow.enabled = false;
        xPNow.text = "";
        xPToGo.enabled = false;
        xPToGo.text = "";
        xP.gameObject.SetActive(false);
        vintageButton.interactable = false;
    }

    public void VintageButton()
    {
        if (bases[shownBase - 1].GetComponent<InstrumentBase>().level == 20)
        {
            vintageButton.interactable = true;
        }
    }
	
    public void VintageUp()
    {
        bases[shownBase - 1].GetComponent<InstrumentBase>().VintageLvlUp();
        vintageButton.interactable = false;
    }
}
