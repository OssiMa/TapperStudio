using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentBase : MonoBehaviour {


    float exp;
    float expToNext = 15;
    float level;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        

        if (exp >= expToNext)
        {
            level += 1;
            expToNext = expToNext*2.5f;
            print("lvl up");
            print("nex lvl at "+ expToNext);
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
