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

    float maxTime = 1.0f;
    float minTime = 0.5f;

    private float time;
    private float spawnTime;

    System.Random newNote = new System.Random();
    System.Random newLongNote = new System.Random();
    System.Random shortOrLong = new System.Random();

    SongProgress sp;

    GameObject[] notesInSceneArray;
    GameObject[] longNotesInSceneArray;

    public List<GameObject> notesInScene = new List<GameObject>();
    //public List<GameObject> longNotesInSceneArray = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        SetRandomTime();
        time = minTime;

        sp = GameObject.Find("SongProgression").GetComponent<SongProgress>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;

        //notesInScene = 

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            spawnNote();
            SetRandomTime();
        }

        if (sp.menu == true || sp.endMenu == true)
        {
            activator1.GetComponent<PianoActivatorCheck>().active = false;
            activator1.GetComponent<PianoActivatorCheck>().sliderActive = false;
            spawnPoint1 = true;

            activator2.GetComponent<PianoActivatorCheck>().active = false;
            activator2.GetComponent<PianoActivatorCheck>().sliderActive = false;
            spawnPoint2 = true;

            activator3.GetComponent<PianoActivatorCheck>().active = false;
            activator3.GetComponent<PianoActivatorCheck>().sliderActive = false;
            spawnPoint3 = true;

            activator4.GetComponent<PianoActivatorCheck>().active = false;
            activator4.GetComponent<PianoActivatorCheck>().sliderActive = false;
            spawnPoint4 = true;

            activator5.GetComponent<PianoActivatorCheck>().active = false;
            activator5.GetComponent<PianoActivatorCheck>().sliderActive = false;
            spawnPoint5 = true;

            if (notesInScene.Count != 0)
            {
                for (int i = notesInScene.Count - 1; i >= 0; i--)
                {
                    Destroy(notesInScene[i]);
                    notesInScene.Remove(notesInScene[i]);
                }
            }
            longSpawned = false;
        }
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    void spawnNote()
    {
        if (sp.menu == false && sp.endMenu == false)
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
                else if (notePosition == 2 && spawnPoint2 == true)
                {
                    Instantiate(note).transform.parent = empty.transform;
                    note.transform.position = new Vector2(activator2.transform.position.x, activator2.transform.position.y + 2.5f);
                }
                else if (notePosition == 3 && spawnPoint3 == true)
                {
                    Instantiate(note).transform.parent = empty.transform;
                    note.transform.position = new Vector2(activator3.transform.position.x, activator3.transform.position.y + 2.5f);
                }
                else if (notePosition == 4 && spawnPoint4 == true)
                {
                    Instantiate(note).transform.parent = empty.transform;
                    note.transform.position = new Vector2(activator4.transform.position.x, activator4.transform.position.y + 2.5f);
                }
                else if (notePosition == 5 && spawnPoint5 == true)
                {
                    Instantiate(note).transform.parent = empty.transform;
                    note.transform.position = new Vector2(activator5.transform.position.x, activator5.transform.position.y + 2.5f);
                }

                notesInSceneArray = GameObject.FindGameObjectsWithTag("Note");

                foreach (GameObject noteObject in notesInSceneArray)
                {
                    if (!notesInScene.Contains(noteObject))
                    {
                        notesInScene.Add(noteObject);
                    }
                }
                /*if (spawnPoint1 == false && spawnPoint2 == false && spawnPoint3 == false && spawnPoint4 == false && spawnPoint5 == false)
                {

                }
                else
                {

                }*/
            }
        }
    }

    void spawnLongNote()
    {


        int caseSwitch = Random.Range(1, 6);

        switch (caseSwitch)
        {
            case 1:

                longNote.transform.position = new Vector2(activator1.transform.position.x, activator1.transform.position.y + 6);
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
        longNotesInSceneArray = GameObject.FindGameObjectsWithTag("LongNote");

        foreach (GameObject longNoteObject in longNotesInSceneArray)
        {
            if (!notesInScene.Contains(longNoteObject))
            {
                notesInScene.Add(longNoteObject);
            }
        }
    }

    public void ActivateLane(GameObject note)
    {
        longSpawned = false;

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
    }


}
