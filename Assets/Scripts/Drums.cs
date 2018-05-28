using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Drums : MonoBehaviour {

    float rotationTimer;
    float combo;
    float comboStep;
    float comboStepMax;

    GameObject[] plateCount;

    SongProgress sp;

	// Use this for initialization
	void Start () {
        plateCount = GameObject.FindGameObjectsWithTag("Drum plate");
        sp = GameObject.Find("SongProgression").GetComponent<SongProgress>();
        NewRotation();
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.menu == false && sp.endMenu == false)
        { 
            rotationTimer -= Time.deltaTime;
            if (rotationTimer <= 0)
            {
                DefaultTags();
                NewRotation();
            }
        }
	}
    void NewRotation()
    {
        rotationTimer = 5;
        int temp;
        for (int i = 0; i < plateCount.Length-2; i++)
        {
            temp = Random.Range(0, plateCount.Length);
            Transform t = plateCount[temp].transform;
            t.tag = "Active Plate";
            t.GetComponentsInChildren<Image>()[1].enabled = true;
            t.GetComponent<Button>().onClick.AddListener(GetComponent<InstrumentBase>().ComboTap);
        }
    }


    void DefaultTags()
    {
        for(int i = 0; i < plateCount.Length; i++)
        {
            plateCount[i].GetComponentsInChildren<Image>()[1].enabled = false;
            plateCount[i].tag = "Drum plate";
            plateCount[i].GetComponent<Button>().onClick.RemoveListener(GetComponent<InstrumentBase>().ComboTap);
        }
    }

}
