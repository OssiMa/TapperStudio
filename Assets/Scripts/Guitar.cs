using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guitar : MonoBehaviour {

    bool pointsOnScreen;
    float timer = 0.2f;
    GameObject[] points;


	// Use this for initialization
	void Start () {
        points = GameObject.FindGameObjectsWithTag("Guitar button");
        Hide();
	}
	
	// Update is called once per frame
	void Update () {
        CheckForPoints();
        if(pointsOnScreen == false)
        {
            Reveal();
        }
	}

    void Hide()
    {
        for(int i = 0; i < points.Length; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void Reveal()
    {
        pointsOnScreen = true;
        for(int i = 0; i < 4; i++)
        {
            
            int temp = Random.Range(0, points.Length);
            points[temp].SetActive(true);
            timer = 0.2f;
        }
    }

    void CheckForPoints()
    {
        for(int i = 0; i < points.Length; i++)
        {
            if(points[i].active == true)
            {
                pointsOnScreen = true;
                break;
            }
            pointsOnScreen = false;
        }
    }
}
