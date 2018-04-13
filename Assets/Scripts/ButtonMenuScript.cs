using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenuScript : MonoBehaviour
{
    public Animator menuAmin;
    public Animator AminButton;
    public Button yourButton;
    
    private bool isMenuActivated = false;

    public void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);


        
    }

    void TaskOnClick()
    {
        menuAmin.SetBool("atStart", true);
        AminButton.SetBool("atStart_toggle", true);
        if(!isMenuActivated)
        {
            Debug.Log("opening");
            isMenuActivated = true;
            menuAmin.SetBool("reverse", false);
            AminButton.SetBool("reverse_toggle", false);
            menuAmin.SetBool("extendMenu", false);
            menuAmin.SetBool("stopExtend", false);



        }
        else if(isMenuActivated)
        {
            Debug.Log("closing");
            isMenuActivated = false;
            menuAmin.SetBool("reverse", true);
            AminButton.SetBool("reverse_toggle", true);
            menuAmin.SetBool("extendMenu", true);
            menuAmin.SetBool("stopExtend", true);
        }
        
    }


    public void Update()
    {
        
    }
}
