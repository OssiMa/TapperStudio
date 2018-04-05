using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Drums : MonoBehaviour {

    float RotationTimer= 5;

    Color defaultcolor = new Color32(208, 210, 102, 255);
    public string searchTag;
    public List<GameObject> actors = new List<GameObject>();

	// Use this for initialization
	void Start () {
        NewRotation();
    }
	
	// Update is called once per frame
	void Update () {
        RotationTimer -= Time.deltaTime;
        if (RotationTimer <= 0)
        {
            DefaultTags();
            NewRotation();
        }
	}
    void NewRotation()
    {
        RotationTimer = 5;
        int temp;
        for (int i = 0; i < 3; i++)
        {
            temp = Random.Range(0, 5);
            Transform t = transform.GetChild(temp);
                t.tag = "Active Plate";
            t.GetComponent<Image>().color = Color.green;
        }
    }
    void DefaultTags()
    {
        for(int i = 0; i < 5; i++)
        {
            transform.GetChild(i).GetComponent<Image>().color = defaultcolor;
            transform.GetChild(i).tag = "Drum plate";
        }
    }

}
