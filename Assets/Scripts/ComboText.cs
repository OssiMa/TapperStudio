using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboText : MonoBehaviour {

    float x;
    float y;
 
    Text text;

    Color32 color32;

    Color32 green;
    Color32 invisible;

    float combo;
    float time;
    float startTime;
    float elapsedTime;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "COMBO " + combo;
        green.r = 0;
        green.g = 255;
        green.b = 33;
        green.a = 255;

        invisible = green;
        invisible.a = 0;

        text.color = green;
        text.enabled = true;

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update ()
    {
        elapsedTime = Time.time - startTime;

        x += Time.deltaTime;
        y += Time.deltaTime;

        color32 = Color.Lerp(green, invisible, (elapsedTime * 0.2f));
        text.color = color32;

        transform.localScale = new Vector2(x,y);

        if (x >= 5f)
        {
            Destroy(gameObject);
        }
	}

    public void MyInstrument(float parentCombo)
    {
        combo = parentCombo;
    }
}
