using System.Collections;
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
