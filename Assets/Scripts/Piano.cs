using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour {

    public GameObject note;
    public GameObject longNote;

    public GameObject activator1;
    public GameObject activator2;
    public GameObject activator3;
    public GameObject activator4;
    public GameObject activator5;

    public bool spawnPoint1 = true;
    public bool spawnPoint2 = true;
    public bool spawnPoint3 = true;
    public bool spawnPoint4 = true;
    public bool spawnPoint5 = true;

    float maxTime = 0.5f;
    float minTime = 0.2f;

    private float time;
    private float spawnTime;

    System.Random newNote = new System.Random();
    System.Random shortOrLong = new System.Random();

    // Use this for initialization
    void Start()
    {
        SetRandomTime();
        time = minTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            spawnNote();
            SetRandomTime();
        }
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    void spawnNote()
    {
        time = 0;
        int whichNote = shortOrLong.Next(1,5);
        if (whichNote == 1)
        {
            spawnLongNote();
        }
        else
        {


            int notePosition = newNote.Next(1, 6);

            while (spawnPoint1 == false && notePosition == 1)
            {
                notePosition = newNote.Next(1, 6);
            }
            while (spawnPoint2 == false && notePosition == 2)
            {
                notePosition = newNote.Next(1, 6);
            }
            while (spawnPoint3 == false && notePosition == 3)
            {
                notePosition = newNote.Next(1, 6);
            }
            while (spawnPoint4 == false && notePosition == 4)
            {
                notePosition = newNote.Next(1, 6);
            }
            while (spawnPoint5 == false && notePosition == 5)
            {
                notePosition = newNote.Next(1, 6);
            }


            if (notePosition == 1 && spawnPoint1 == true)
            {
                Instantiate(note);
                note.transform.position = new Vector2(activator1.transform.position.x, activator1.transform.position.y + 2.5f);
            }
            if (notePosition == 2 && spawnPoint2 == true)
            {
                Instantiate(note);
                note.transform.position = new Vector2(activator2.transform.position.x, activator2.transform.position.y + 2.5f);
            }
            if (notePosition == 3 && spawnPoint3 == true)
            {
                Instantiate(note);
                note.transform.position = new Vector2(activator3.transform.position.x, activator3.transform.position.y + 2.5f);
            }
            if (notePosition == 4 && spawnPoint4 == true)
            {
                Instantiate(note);
                note.transform.position = new Vector2(activator4.transform.position.x, activator4.transform.position.y + 2.5f);
            }
            if (notePosition == 5 && spawnPoint5 == true)
            {
                Instantiate(note);
                note.transform.position = new Vector2(activator5.transform.position.x, activator5.transform.position.y + 2.5f);
            }
            if (spawnPoint1 == false && spawnPoint2 == false && spawnPoint3 == false && spawnPoint4 == false && spawnPoint5 == false)
            {
                Debug.Log("mitä vitun saatanaa");
            }
            else
            {
                 
            }
        }
    }

    void spawnLongNote()
    {
         int notePosition = newNote.Next(1,6);
        longNote.transform.localScale = new Vector2(0.2f, Random.Range(2, 5));

        if (notePosition == 1 && spawnPoint1 == true)
        {
            Instantiate(longNote);
            longNote.transform.position = new Vector2(activator1.transform.position.x, activator1.transform.position.y + 7f);
            spawnPoint1 = false;
        }
        if (notePosition == 2 && spawnPoint2 == true)
        {
            Instantiate(longNote);
            longNote.transform.position = new Vector2(activator2.transform.position.x, activator2.transform.position.y + 7f);
            spawnPoint2 = false;
        }
        if (notePosition == 3 && spawnPoint3 == true)
        {
            Instantiate(longNote);
            longNote.transform.position = new Vector2(activator3.transform.position.x, activator3.transform.position.y + 7f);
            spawnPoint3 = false;
        }
        if (notePosition == 4 && spawnPoint4 == true)
        {
            Instantiate(longNote);
            longNote.transform.position = new Vector2(activator4.transform.position.x, activator4.transform.position.y + 7f);
            spawnPoint4 = false;
        }
        if (notePosition == 5 && spawnPoint5 == true)
        {
            Instantiate(longNote);
            longNote.transform.position = new Vector2(activator5.transform.position.x, activator5.transform.position.y + 7f);
            spawnPoint5 = false;
        }
        if (spawnPoint1 == false && spawnPoint2 == false && spawnPoint3 == false && spawnPoint4 == false && spawnPoint5 == false)
        {
            Debug.Log("mitä vitun saatanaa");
        }
        else
        {
            
        }

    }


}
