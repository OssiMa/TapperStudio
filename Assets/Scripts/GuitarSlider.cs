using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuitarSlider : MonoBehaviour {

    Slider s;
    int r;
    int x;

    RectTransform Srect;
    Vector2 Original = new Vector2();

    InstrumentBase guitar;

    
    // Use this for initialization
    void Start () {
        guitar = transform.parent.gameObject.GetComponent<InstrumentBase>();
        s = GetComponent<Slider>();
        Srect = s.GetComponent<RectTransform>();
        Original = s.transform.localPosition;
        Resize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Resize()
    {
        
        s.transform.localPosition = Original;
        r = Random.Range(0, 2);
        if (r == 0)
        {
            s.direction = Slider.Direction.RightToLeft;
            x = -1;
        }
        else
        {
            s.direction = Slider.Direction.LeftToRight;
            x = 1;
        }
        r = Random.Range(1, 4);
        Srect.sizeDelta = new Vector2(72 * r + 15, Srect.sizeDelta.y);
        if (r == 2)
        {
            r = Random.Range(2,4);
            s.transform.localPosition = new Vector2(s.transform.localPosition.x - x*34, s.transform.localPosition.y);
        }
        else if (r == 1)
        {
            r = Random.Range(1, 4);
            s.transform.localPosition = new Vector2(s.transform.localPosition.x - x*72, s.transform.localPosition.y);
        }
        else
        {
            s.transform.localPosition = new Vector2(s.transform.localPosition.x, s.transform.localPosition.y);
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
