using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuExtendScript : MonoBehaviour
{
    public Animator menuAmin;
    public Toggle toggler;
    public Toggle toggler1;

    public void Start()
    {

        Toggle toggle = toggler.GetComponent<Toggle>();
        Toggle toggle1 = toggler1.GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate 
        {
            ToggleValueGhanged(toggler);
        }
            );

        toggle1.onValueChanged.AddListener(delegate
        {
            ToggleValueGhanged(toggler1);
        }
           );

    }


    void ToggleValueGhanged(Toggle change)
    {
        if (toggler.isOn || toggler1.isOn)
        {
            menuAmin.SetBool("extendMenu", true);
        }
        else if (!toggler.isOn && !toggler1.isOn)
        {
            menuAmin.SetBool("extendMenu", false);
        }

    }  
}
