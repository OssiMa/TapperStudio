using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuitarSlider : MonoBehaviour {

    Slider s;
    int r;
    int x;

    RectTransform Srect;
    RectTransform Original;

    InstrumentBase guitar;

    
    // Use this for initialization
    void Start () {
        guitar = transform.parent.gameObject.GetComponent<InstrumentBase>();
        s = GetComponent<Slider>();
        Original = s.GetComponent<RectTransform>();
        print(Original.transform.position.x);
        Resize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Resize()
    {
        Srect = Original;
        r = Random.Range(0, 2);
        if (r == 0)
        {
            s.direction = Slider.Direction.RightToLeft;
            x = -8;
        }
        else
        {
            s.direction = Slider.Direction.LeftToRight;
            x = +8;
        }
        r = Random.Range(2, 5);
        Srect.sizeDelta = new Vector2(50 * r, Srect.sizeDelta.y);
        if (r == 3)
        {
            r = Random.Range(2,4);
            Srect.transform.localPosition = new Vector2(Srect.transform.localPosition.x - x*r, Original.transform.localPosition.y);
            print(Srect.transform.position.x + "r3");
        }
        else if (r == 2)
        {
            r = Random.Range(1, 4);
            Srect.transform.localPosition = new Vector2(Srect.transform.localPosition.x - r*x, Original.transform.localPosition.y);
            print(Srect.transform.position.x + "r2");
        }
        else
        {
            Srect.transform.position = new Vector2(Original.transform.position.x, Original.transform.position.y);
            print(Srect.transform.position.x + "normi");
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
