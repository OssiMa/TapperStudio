using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Drums : MonoBehaviour {

    float RotationTimer= 5;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RotationTimer -= Time.deltaTime;
        if (RotationTimer <= 0)
        {

        }
	}
    void NewRotation()
    {
        RotationTimer = 5;
        //
    }
}
