using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;

    SongProgress sp;
    Piano piano;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GameObject.Find("SongProgression").GetComponent<SongProgress>();
        piano = GameObject.Find("Piano").GetComponent<Piano>();

    }

    // Use this for initialization
    void Start ()
    {
        rb.velocity = new Vector2(0, -speed);
    }
    private void OnEnable()
    {
        rb.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update ()
    {
        /*if (sp.menu == true || sp.endMenu == true)
        {
            if (gameObject.tag == "LongNote")
            {
                piano.ActivateLane(gameObject);
            }

            Destroy(gameObject);
        }*/

    }

}
