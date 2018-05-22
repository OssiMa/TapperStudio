using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InstrumentInfos : MonoBehaviour {

    public Text textBox;
    public GameObject vintageButton;
    public int shownBase;

    GameObject[] bases;

	// Use this for initialization
	void Start ()
    {
		bases = GameObject.FindGameObjectsWithTag("Instrument").OrderBy(instruments => instruments.name).ToArray();
    }

    public void ShowStatsFor(int x)
    {
        shownBase = x;
        SetTexts();
        VintageButton();
    }

    void SetTexts()
    {
        textBox.enabled = true;
        textBox.text = "Instrument level: " + bases[shownBase-1].GetComponent<InstrumentBase>().level + "\nInstrument experience: " +
            bases[shownBase - 1].GetComponent<InstrumentBase>().exp + "\nNext level at " + bases[shownBase - 1].GetComponent<InstrumentBase>().expToNext + 
            "\nBoosts from equipment: ";
    }

    public void HideTexts()
    {
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
