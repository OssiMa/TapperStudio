using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

    Text text;

    MusicPlayer mp;

	// Use this for initialization
	void Start ()
    {
        mp = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
        text = transform.GetChild(0).GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (mp.allMute == true)
        {
            text.text = "Unmute";
        }
        else
        {
            text.text = "Mute";
        }
	}
}
