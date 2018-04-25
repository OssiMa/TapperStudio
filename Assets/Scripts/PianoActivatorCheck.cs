﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoActivatorCheck : MonoBehaviour
{

    public Piano piano;

    public InstrumentBase instrumentBase;
    public SongProgress progression;
    bool active = false;
    bool sliderActive = false;
    bool sliderOn = false;

    GameObject note;
    GameObject longNote;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(sliderOn == true)
        {
            instrumentBase.exp += 0.01f * instrumentBase.combo;
            progression.songXP += 0.01f * instrumentBase.combo;
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {



        if (col.gameObject.tag == "Note")
        {

            note = col.gameObject;
            active = true;
        }
        if (col.gameObject.tag == "LongNote")
        {

            longNote = col.gameObject;
            sliderActive = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject == note)
        {
            active = false;
        }

        if(col.gameObject == longNote)
        {
            sliderActive = false;
            if (col.gameObject.transform.position.x == piano.activator1.transform.position.x && piano.spawnPoint1 == false)
            {
                piano.spawnPoint1 = true;    
            }
            if (col.gameObject.transform.position.x == piano.activator2.transform.position.x && piano.spawnPoint2 == false)
            {
                piano.spawnPoint2 = true;
            }
            if (col.gameObject.transform.position.x == piano.activator3.transform.position.x && piano.spawnPoint3 == false)
            {
                piano.spawnPoint3 = true;
            }
            if (col.gameObject.transform.position.x == piano.activator4.transform.position.x && piano.spawnPoint4 == false)
            {
                piano.spawnPoint4 = true;
            }
            if (col.gameObject.transform.position.x == piano.activator5.transform.position.x && piano.spawnPoint5 == false)
            {
                piano.spawnPoint5 = true;
            }
            sliderOn = false;
        }
        Destroy(col.gameObject);

    }
    public void Destroy()
    {
        if (active == true)
        {
            Destroy(note);
            instrumentBase.ComboTap();
            active = false;
        }
    }
    public void sliderPressed()
    {
        
        if(sliderActive == true)
        {
            sliderOn = true;
        }
    }

    public void sliderNotPressed()
    {
        sliderOn = false;
    }
}
