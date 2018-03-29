using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentBase : MonoBehaviour {

    public Slider xpBar;
    public Text currLvl;
    public Text nxtLvl;

    float exp;
    float expToNext = 15;
    float level = 1;
    float nextLevel = 2;


	// Use this for initialization
	void Start () {
        xpBar.maxValue = expToNext;
        currLvl.text = "" + level;
        nxtLvl.text = "" + nextLevel;
        nextLevel = level + 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        xpBar.value = exp;
        nxtLvl.text = "" + nextLevel;
        currLvl.text = "" + level;

        if (exp >= expToNext)
        {
            level += 1;
            nextLevel += 1;
            expToNext = expToNext*2.5f;
            xpBar.minValue = exp;
            xpBar.maxValue = expToNext;
        }
	}

    public void Tap()
    {
        exp += 1;
        print(exp);
        print(expToNext);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tap();
        }
    }

}
