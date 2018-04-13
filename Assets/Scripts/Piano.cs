using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour {

    //public InstrumentBase instrumentBase;

    bool active = false;
    public GameObject activator;
    GameObject note;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        
        
            active = true;
            if (col.gameObject.tag == "Note")
            {

                note = col.gameObject;

            }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
        //Destroy(note);
    }
    public void Destroy()
    {
        if (active == true)
        {
            Destroy(note);
            active = false;
        }
    }
}
