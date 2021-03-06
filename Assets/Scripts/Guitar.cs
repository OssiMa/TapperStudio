﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Guitar : MonoBehaviour {

    bool pointsOnScreen;
    int activeSlider;

    GameObject[] points;
    GameObject[] sliders;


	// Use this for initialization
	void Start () {
        points = GameObject.FindGameObjectsWithTag("Guitar button").OrderBy(points => points.name).ToArray();
        sliders = GameObject.FindGameObjectsWithTag("Guitar slider").OrderBy(sliders => sliders.name).ToArray();
        Hide();
	}
	
	// Update is called once per frame
	void Update () {
        CheckForPoints();
        if(pointsOnScreen == false)                                                 //If no clickables left, spawn more
        {
            activeSlider = 5;
            StartCoroutine(BigReveal());
        }
	}

    //Hides all the clickable objects
    void Hide()
    {
        foreach(GameObject point in points)
        {
            point.SetActive(false);
        }

        foreach(GameObject slid in sliders)
        {
            slid.SetActive(false);
        }

    }

    //Starts the generation of new clickables
    IEnumerator BigReveal()
    {
        SliderReveal();
        for (int i = 0; i < 4; i++)
        {
            Reveal();
            yield return new WaitForSeconds(0.2f);
        }
    }

    //Randomizes the balls and reveals them
    void Reveal()
    {
        int temp= Random.Range(0, points.Length);

            if (activeSlider == 0)
            {
                while (points[temp].activeInHierarchy || temp <= 3)
                {
                    temp = Random.Range(4, points.Length);
                }
            }
            else if (activeSlider == 1)
            {
                while (points[temp].activeInHierarchy || temp >= 4 && temp <= 7)
                {
                    temp = Random.Range(0, points.Length);
                } 
            }
            else if (activeSlider == 2)
            {
                while (points[temp].activeInHierarchy || temp >= 8 && temp <= 11)
                {
                    temp = Random.Range(0, points.Length);
                } 
            }
            else if (activeSlider == 3)
            {
                while (points[temp].activeInHierarchy || temp >=12)
                {
                    temp = Random.Range(0, points.Length - 4);
                }
            }

          while (points[temp].activeInHierarchy)
          {
               temp = Random.Range(0, points.Length);
          }
        points[temp].SetActive(true);
    }

    //Decides if slider is revealed and reveals it if was chosen to
    void SliderReveal()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            int i = Random.Range(0, sliders.Length);
            sliders[i].SetActive(true);
            activeSlider = i;
            sliders[i].GetComponent<GuitarSlider>().Resize();
        }
    }

    //Checks if there are any clickables left
    void CheckForPoints()
    {
        for(int i = 0; i < points.Length; i++)
        {
            if(points[i].activeInHierarchy)
            {
                pointsOnScreen = true;
                return;
            }
        }
       
        for (int i = 0; i < sliders.Length; i++)
        {
            if (sliders[i].activeInHierarchy)
            {
                pointsOnScreen = true;
                return;
            }
            pointsOnScreen = false;
        }
    }
}
