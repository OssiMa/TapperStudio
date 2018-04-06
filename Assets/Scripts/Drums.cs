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


	// Use this for initialization
	void Start () {
        plateCount = GameObject.FindGameObjectsWithTag("Drum plate");
        NewRotation();
    }
	
	// Update is called once per frame
	void Update () {
        rotationTimer -= Time.deltaTime;
        if (rotationTimer <= 0)
        {
            DefaultTags();
            NewRotation();
        }
	}
    void NewRotation()
    {
        rotationTimer = 5;
        int temp;
        for (int i = 0; i < plateCount.Length-2; i++)
        {
            temp = Random.Range(0, plateCount.Length);
            Transform t = transform.GetChild(temp);
            t.tag = "Active Plate";
            t.GetComponent<Image>().color = Color.green;
            t.GetComponent<Button>().onClick.AddListener(GetComponent<InstrumentBase>().ComboTap);
        }
    }


    void DefaultTags()
    {
        for(int i = 0; i < plateCount.Length; i++)
        {
            transform.GetChild(i).GetComponent<Image>().color = Color.white;
            transform.GetChild(i).tag = "Drum plate";
            transform.GetChild(i).GetComponent<Button>().onClick.RemoveListener(GetComponent<InstrumentBase>().ComboTap);
        }
    }

}
