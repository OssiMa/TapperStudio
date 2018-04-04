using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongProgress : MonoBehaviour {

    public Slider Progress;
    public Text SongText;

    float songXP;
    float songXPMax = 20;
    float songCount = 1;
    float songCountMax = 3;



	// Use this for initialization
	void Start () {
        Progress.maxValue = songXPMax;

	}
	
	// Update is called once per frame
	void Update () {
        Progress.value = songXP;
        SongText.text = songCount + "/" + songCountMax;

        if (songXP >= songXPMax)
        {
            songCount += 1;
            songXP = 0;
        }
        if (songCount > songCountMax)
        {
            songCount = 1;
        }
	}

    public void GainXP()
    {
        songXP += 1;
    }
}
