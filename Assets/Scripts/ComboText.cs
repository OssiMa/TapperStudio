using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboText : MonoBehaviour {

    float x;
    float y;
 
    Text text;

    Color lerpedColor = Color.white;
    Color color;

    int instrument;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "COMBO " + instrument;

        color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update ()
    {
        x += Time.deltaTime;
        y += Time.deltaTime;

        //lerpedColor = Color.Lerp(color, lerpedColor, Mathf.PingPong(Time.time, 1));
        //text.color = lerpedColor;
        lerpedColor = Color.Lerp(Color.green, color, Mathf.PingPong(Time.time, 1.5f));
        text.color = lerpedColor;

        transform.localScale = new Vector2(x,y);

        if (x >= 5)
        {
            Destroy(gameObject);
        }
	}

    public void MyInstrument(int parentInst)
    {
        instrument = parentInst;
    }
}
