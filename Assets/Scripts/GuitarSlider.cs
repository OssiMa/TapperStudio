using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuitarSlider : MonoBehaviour {

    Slider s;
    int r;

    RectTransform Srect;

    InstrumentBase guitar;

    
    // Use this for initialization
    void Start () {
        guitar = transform.parent.gameObject.GetComponent<InstrumentBase>();
        
        Resize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Resize()
    {
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
        r = Random.Range(2, 5);
        Srect = s.GetComponent<RectTransform>();
        Srect.sizeDelta = new Vector2(50 * r, Srect.sizeDelta.y);
        if (r == 3)
        {
            r = Random.Range(2,4);
            Srect.transform.position = new Vector2(60*r , Srect.transform.position.y);
        }
        else if (r == 2)
        {
            r = Random.Range(1, 4);
            Srect.transform.position = new Vector2(20+65*r, Srect.transform.position.y);
        }
        else
        {
            Srect.transform.position = new Vector2(150, Srect.transform.position.y);
        }
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
            guitar.BigExpReward();
            this.gameObject.SetActive(false);
        }
    }
}
