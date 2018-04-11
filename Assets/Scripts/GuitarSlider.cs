using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuitarSlider : MonoBehaviour {

    Slider s;
    int r;

	// Use this for initialization
	void Start () {
        s = GetComponent<Slider>();
        r = Random.Range(0, 2);
        if (r == 0)
        {
            s.direction = Slider.Direction.RightToLeft;
        }
        else
        {
            s.direction = Slider.Direction.LeftToRight;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SliderCheck()
    {
        if (s.value <= 1)
        {
            s.value = 0;
        }
    }
    public void SliderRemove()
    {
        if (s.value == 1)
        {
            s.value = 0;
            this.gameObject.SetActive(false);
        }
    }
}
