using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InstrumentInfos : MonoBehaviour {

    Sprite[] icons;

    public Text textBox;
    public Image icon;
    public Button vintageButton;
    public Slider xP;
    int shownBase;

    GameObject[] bases;

	// Use this for initialization
	void Start ()
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
        textBox.text = "Level: " + ins.level + "\nExperience: " + ins.exp + "\nNext level at " + ins.expToNext +
            "\nBoosts from equipment:\nGeneration Boost: " + ins.GetBoosts(1) + "\nAdditional Combo: " + ins.GetBoosts(2) + "\nBonus experience: "
            + ins.GetBoosts(3); ;
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
