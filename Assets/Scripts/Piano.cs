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


    System.Random r = new System.Random();
    System.Random newNote = new System.Random();
    System.Random shortOrLong = new System.Random();
    System.Random noteSize = new System.Random();

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        int noteSpawn = r.Next(1, 40);
        if(noteSpawn == 1)
        {
            spawnNote();
        }
        
    }


    void spawnNote()
    {
        int whichNote = shortOrLong.Next(1,3);
        if (whichNote == 1)
        {
            spawnLongNote();
        }
        else
        {
            
            Instantiate(note);
        }
        int notePosition = newNote.Next(1,6);
        if (notePosition == 1)
        {
            note.transform.position = new Vector2(activator1.transform.position.x, activator1.transform.position.y + 2.5f);
        }
        if (notePosition == 2)
        {
            note.transform.position = new Vector2(activator2.transform.position.x, activator2.transform.position.y + 2.5f);
        }
        if (notePosition == 3)
        {
            note.transform.position = new Vector2(activator3.transform.position.x, activator3.transform.position.y + 2.5f);
        }
        if (notePosition == 4)
        {
            note.transform.position = new Vector2(activator4.transform.position.x, activator4.transform.position.y + 2.5f);
        }
        if (notePosition == 5)
        {
            note.transform.position = new Vector2(activator5.transform.position.x, activator5.transform.position.y + 2.5f);
        }
    }

    void spawnLongNote()
    {
         int notePosition = newNote.Next(1,6);
        Instantiate(longNote);

        int whichSize = noteSize.Next(1, 4);
        if (whichSize == 1)
        {
            longNote.transform.localScale = new Vector2(0.2f, 2f);
        }
        if (whichSize == 2)
        {
            longNote.transform.localScale = new Vector2(0.2f, 3f);
        }
        if (whichSize == 3)
        {
            longNote.transform.localScale = new Vector2(0.2f, 5f);
        }

        if (notePosition == 1)
        {
            longNote.transform.position = new Vector2(activator1.transform.position.x, activator1.transform.position.y + 2.5f);
        }
        if (notePosition == 2)
        {
            longNote.transform.position = new Vector2(activator2.transform.position.x, activator2.transform.position.y + 2.5f);
        }
        if (notePosition == 3)
        {
            longNote.transform.position = new Vector2(activator3.transform.position.x, activator3.transform.position.y + 2.5f);
        }
        if (notePosition == 4)
        {
            longNote.transform.position = new Vector2(activator4.transform.position.x, activator4.transform.position.y + 2.5f);
        }
        if (notePosition == 5)
        {
            longNote.transform.position = new Vector2(activator5.transform.position.x, activator5.transform.position.y + 2.5f);
        }

    }
}
