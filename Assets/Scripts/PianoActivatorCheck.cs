using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoActivatorCheck : MonoBehaviour
{

    public Piano piano;

    public InstrumentBase instrumentBase;
    public SongProgress progression;
    MusicPlayer mp;

    bool active = false;
    bool sliderActive = false;
    bool sliderOn = false;

    GameObject note;
    GameObject longNote;
    Animator animOne;

    List<GameObject> animationObjects = new List<GameObject>();
    List<GameObject> activatorChildren = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        mp = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
        GameObject keyborat = GameObject.Find("Keyborat");
        GameObject activators = GameObject.Find("Activators");
       
        for (int i = 0; i < 4; i++)
        {
            animationObjects.Add(keyborat.transform.GetChild(i).gameObject);
            activatorChildren.Add(activators.transform.GetChild(i).gameObject);

            if (gameObject == activatorChildren[i])
            {
                animOne = animationObjects[i].GetComponent<Animator>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderOn == true)
        {
            instrumentBase.exp += 0.01f * instrumentBase.combo;
            progression.songXP += 0.01f * instrumentBase.combo;
            //Animation 2?
            /*if (!animLong.GetBool("atStart"))
            {
                animLong.SetBool("atStart", true);     //I wonder if we'll have to make an extra thing for this?
            }*/
        }
        else if (sliderOn == false)
        {
            //animLong.SetBool("atStart", false);     //Something like this??
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
            piano.ActivateLane(longNote);
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
            mp.KeyboardStarted();
            mp.StartTheMusic();
            active = false;

            //Animation 1
            if (!animOne.GetBool("atStart"))
            {
                //animOne.SetBool("true");
            }
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
