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
    public GameObject empty;

    

    public bool spawnPoint1 = true;
    public bool spawnPoint2 = true;
    public bool spawnPoint3 = true;
    public bool spawnPoint4 = true;
    public bool spawnPoint5 = true;
    bool longSpawned = false;

    float maxTime = 0.5f;
    float minTime = 0.2f;

    private float time;
    private float spawnTime;

    System.Random newNote = new System.Random();
    System.Random newLongNote = new System.Random();
    System.Random shortOrLong = new System.Random();

    SongProgress sp;

    // Use this for initialization
    void Start()
    {
        SetRandomTime();
        time = minTime;

        sp = GameObject.Find("SongProgress").GetComponent<SongProgress>();
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
        if (sp.menu == false)
        {
            time = 0;
            int whichNote = shortOrLong.Next(1, 5);
            if (whichNote == 1 && longSpawned == false)
            {
                spawnLongNote();
                longSpawned = true;
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
                    Instantiate(note).transform.parent = empty.transform;
                    note.transform.position = new Vector2(activator1.transform.position.x, activator1.transform.position.y + 2.5f);
                }
                if (notePosition == 2 && spawnPoint2 == true)
                {
                    Instantiate(note).transform.parent = empty.transform;
                    note.transform.position = new Vector2(activator2.transform.position.x, activator2.transform.position.y + 2.5f);
                }
                if (notePosition == 3 && spawnPoint3 == true)
                {
                    Instantiate(note).transform.parent = empty.transform;
                    note.transform.position = new Vector2(activator3.transform.position.x, activator3.transform.position.y + 2.5f);
                }
                if (notePosition == 4 && spawnPoint4 == true)
                {
                    Instantiate(note).transform.parent = empty.transform;
                    note.transform.position = new Vector2(activator4.transform.position.x, activator4.transform.position.y + 2.5f);
                }
                if (notePosition == 5 && spawnPoint5 == true)
                {
                    Instantiate(note).transform.parent = empty.transform;
                    note.transform.position = new Vector2(activator5.transform.position.x, activator5.transform.position.y + 2.5f);
                }
                if (spawnPoint1 == false && spawnPoint2 == false && spawnPoint3 == false && spawnPoint4 == false && spawnPoint5 == false)
                {

                }
                else
                {

                }
            }
        }
    }

    void spawnLongNote()
    {
        //int LongNotePosition = newLongNote.Next(1,6);
        //longNote.transform.localScale = new Vector2(0.2f, Random.Range(2, 5));

        ////while (spawnPoint1 == false && LongNotePosition == 1)
        ////{
        ////    LongNotePosition = newLongNote.Next(1, 6);
        ////}
        ////while (spawnPoint2 == false && LongNotePosition == 2)
        ////{
        ////    LongNotePosition = newLongNote.Next(1, 6);
        ////}
        ////while (spawnPoint3 == false && LongNotePosition == 3)
        ////{
        ////    LongNotePosition = newLongNote.Next(1, 6);
        ////}
        ////while (spawnPoint4 == false && LongNotePosition == 4)
        ////{
        ////    LongNotePosition = newLongNote.Next(1, 6);
        ////}
        ////while (spawnPoint5 == false && LongNotePosition == 5)
        ////{
        ////    LongNotePosition = newLongNote.Next(1, 6);
        ////}

        //if (LongNotePosition == 1)
        //{
        //    Instantiate(longNote);
        //    longNote.transform.position = new Vector2(activator1.transform.position.x, activator1.transform.position.y +7);
        //    spawnPoint1 = false;
        //    print("Activator 1: " + activator1.transform.position.x + "\n"
        //          + longNote.transform.position);
        //}
        //else if (LongNotePosition == 2)
        //{
        //    Instantiate(longNote);
        //    longNote.transform.position = new Vector2(activator2.transform.position.x, activator2.transform.position.y + 7);
        //    spawnPoint2 = false;
        //    print("2: " + activator2.transform.position.x + "\n"
        //          + longNote.transform.position);
        //}
        //else if (LongNotePosition == 3)
        //{
        //    Instantiate(longNote);
        //    longNote.transform.position = new Vector2(activator3.transform.position.x, activator3.transform.position.y + 7);
        //    spawnPoint3 = false;
        //    print("3: " + activator3.transform.position.x + "\n"
        //          + longNote.transform.position);
        //}
        //else if (LongNotePosition == 4)
        //{
        //    Instantiate(longNote);
        //    longNote.transform.position = new Vector2(activator4.transform.position.x, activator4.transform.position.y + 7);
        //    spawnPoint4 = false;
        //    print("4: " + activator4.transform.position.x + "\n"
        //          + longNote.transform.position);
        //}
        //else if (LongNotePosition == 5)
        //{
        //    Instantiate(longNote);
        //    longNote.transform.position = new Vector2(activator5.transform.position.x, activator5.transform.position.y + 7);
        //    spawnPoint5 = false;
        //    print("5: " + activator5.transform.position.x + "\n"
        //          + longNote.transform.position);
        //}
        //if (spawnPoint1 == false && spawnPoint2 == false && spawnPoint3 == false && spawnPoint4 == false && spawnPoint5 == false)
        //{

        //}
        //else
        //{

        //}


        int caseSwitch = Random.Range(1,6);

        switch (caseSwitch)
        {
            case 1:
                    
                    longNote.transform.position = new Vector2(activator1.transform.position.x, activator1.transform.position.y +6);
                Instantiate(longNote).transform.parent = empty.transform;
                spawnPoint1 = false;
                break;

            case 2:
                    
                    longNote.transform.position = new Vector2(activator2.transform.position.x, activator2.transform.position.y + 6);
                Instantiate(longNote).transform.parent = empty.transform;
                spawnPoint2 = false;
                break;

            case 3:
                    
                    longNote.transform.position = new Vector2(activator3.transform.position.x, activator3.transform.position.y + 6);
                Instantiate(longNote).transform.parent = empty.transform;
                spawnPoint3 = false;
                break;

            case 4:
                    
                    longNote.transform.position = new Vector2(activator4.transform.position.x, activator4.transform.position.y + 6);
                Instantiate(longNote).transform.parent = empty.transform;
                spawnPoint4 = false;
                break;

            case 5:
                    
                    longNote.transform.position = new Vector2(activator5.transform.position.x, activator5.transform.position.y + 6);
                Instantiate(longNote).transform.parent = empty.transform;
                spawnPoint5 = false;
                break;

            default:
                print("suatana");
                break;
        }

    }

    public void ActivateLane(GameObject note)
    {
        if (Mathf.Abs(note.transform.position.x - activator1.transform.position.x) < 0.01)
        {
            spawnPoint1 = true;
        }
        else if (Mathf.Abs(note.transform.position.x - activator2.transform.position.x) < 0.01)
        {
            spawnPoint2 = true;
        }
        else if (Mathf.Abs(note.transform.position.x - activator3.transform.position.x) < 0.01)
        {
            spawnPoint3 = true;
        }
        else if (Mathf.Abs(note.transform.position.x - activator4.transform.position.x) < 0.01)
        {
            spawnPoint4 = true;
        }
        else if (Mathf.Abs(note.transform.position.x - activator5.transform.position.x) < 0.01)
        {
            spawnPoint5 = true;
        }
        longSpawned = false;

    }


}
