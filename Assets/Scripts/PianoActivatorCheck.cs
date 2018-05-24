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
    GameObject myAnimOne;
    GameObject myAnimLong;

    List<GameObject> animationObjects = new List<GameObject>();
    List<GameObject> animationLongObjects = new List<GameObject>();
    List<GameObject> activatorChildren = new List<GameObject>();
    GameObject[] notesInScene;
    GameObject[] longNotesInScene;

    // Use this for initialization
    void Awake()
    {
        mp = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
        GameObject keyborat = GameObject.Find("Keyborat");
        GameObject keyboratLong = GameObject.Find("KeyboratLong");
        GameObject activators = GameObject.Find("Activators");
       
        for (int i = 0; i < 5; i++)
        {
            animationObjects.Add(keyborat.transform.GetChild(i).gameObject);
            activatorChildren.Add(activators.transform.GetChild(i).gameObject);
            animationLongObjects.Add(keyboratLong.transform.GetChild(i).gameObject);

            if (gameObject == activatorChildren[i])
            {
                animOne = animationObjects[i].GetComponent<Animator>();
                myAnimOne = animationObjects[i];
                myAnimLong = animationLongObjects[i];
            }
        }

        myAnimLong.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderOn == true)
        {
            myAnimLong.SetActive(true);
            instrumentBase.exp += 0.01f * instrumentBase.combo;
            progression.songXP += 0.01f * instrumentBase.combo;
            //animLong.Play("");
        }
        else if (sliderOn == false)
        {
            for (int i = 0; i < 5; i++)
            {
                myAnimLong.SetActive(false);
            }
            //animLong.Rebind();      //Uh we'll see what this does
        }

        if (progression.menu == true || progression.endMenu == true)
        {
            notesInScene = GameObject.FindGameObjectsWithTag("Note");
            longNotesInScene = GameObject.FindGameObjectsWithTag("LongNote");

            foreach (GameObject normalNote in notesInScene)
            {
                Destroy(normalNote);
            }
            foreach (GameObject longerNote in notesInScene)     //Highly unreliable for LongNotes! Needs a fix 
            {
                Destroy(longerNote);
            }
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

            animOne.Play("");
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
