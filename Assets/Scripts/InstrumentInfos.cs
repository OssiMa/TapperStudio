using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InstrumentInfos : MonoBehaviour {

    Sprite[] icons;

    public Text textBox;
    public Image icon;
    public GameObject vintageButton;
    public int shownBase;

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
        VintageButton();
    }

    void SetTexts()
    {
        textBox.enabled = true;
        InstrumentBase ins = bases[shownBase - 1].GetComponent<InstrumentBase>();
        textBox.text = "Instrument level: " + ins.level + "\nInstrument experience: " + ins.exp + "\nNext level at " + ins.expToNext +
            "\nBoosts from equipment:\nGeneration Boost: " + ins.GetBoosts(1) + "\nAdditional Combo: " + ins.GetBoosts(2) + "\nBonus experience: "
            + ins.GetBoosts(3); ;
    }

    void SetIcon()
    {
        icon.enabled = true;
        icon.sprite = icons[shownBase-1];
    }

    public void HideTexts()
    {
        icon.enabled = false;
        textBox.enabled = false;
        textBox.text = "";
        vintageButton.SetActive(false);
    }

    public void VintageButton()
    {
        if (bases[shownBase - 1].GetComponent<InstrumentBase>().level == 20)
        {
            vintageButton.SetActive(true);
        }
    }
	
    public void VintageUp()
    {
        bases[shownBase - 1].GetComponent<InstrumentBase>().VintageLvlUp();
        vintageButton.SetActive(false);
    }
}
