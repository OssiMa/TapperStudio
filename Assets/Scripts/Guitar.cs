using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Guitar : MonoBehaviour {

    bool pointsOnScreen = false;
    int activeSlider;

    GameObject[] points;
    GameObject[] sliders;

    SongProgress sp;

    bool endOfSong;

    private void OnEnable()
    {
        if (points != null)
        {
            CheckForPoints();
        }

    }

    // Use this for initialization
    void Start () {
        points = GameObject.FindGameObjectsWithTag("Guitar button").OrderBy(points => points.name).ToArray();
        sliders = GameObject.FindGameObjectsWithTag("Guitar slider").OrderBy(sliders => sliders.name).ToArray();
        sp = GameObject.Find("SongProgression").GetComponent<SongProgress>();
        Hide();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (sp.songEnder == true && (sp.menu == true || sp.endMenu == true))
        {
            Hide();
        }
        //CheckForPoints() at the start of a new album is done in SongProgress
        else if (pointsOnScreen == false && (sp.menu == false || sp.endMenu == false))
        //If no clickables left, spawn more
        {
            activeSlider = 5;
            StartCoroutine(BigReveal());
            pointsOnScreen = true;
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
        yield return new WaitForSeconds(0.2f);
        SliderReveal();
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.2f);
            Reveal();
        }
        
    }

    //Randomizes the balls and reveals them
    void Reveal()
    {
            int temp = Random.Range(0, points.Length);

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
                while (points[temp].activeInHierarchy || temp >= 12)
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
    public void CheckForPoints()
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
