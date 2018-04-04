using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Drums : MonoBehaviour {

    float RotationTimer= 5;



	// Use this for initialization
	void Start () {
        WithForeachLoop();
        WithForLoop();
    }
	
	// Update is called once per frame
	void Update () {
        RotationTimer -= Time.deltaTime;
        if (RotationTimer <= 0)
        {
            NewRotation();
        }
	}
    void NewRotation()
    {
        RotationTimer = 5;
        //thing
    }
    void WithForeachLoop()
    {
        foreach (Transform child in transform)
            print("Foreach loop: " + child);
    }

    void WithForLoop()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
            print("For loop: " + transform.GetChild(i));
    }
}
