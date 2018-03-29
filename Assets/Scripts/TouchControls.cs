using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

   // public GameObject drums;

    //private InstrumentBase instr;

    Vector3 touchPosWorld;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            RaycastHit2D hitInfo = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if (hitInfo.collider != null)
            {
                GameObject touchedObject = hitInfo.transform.gameObject;
                if (touchedObject.tag == "In")
                {
                }
            }

        }
    }
}
