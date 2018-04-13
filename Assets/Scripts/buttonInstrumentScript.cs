using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonInstrumentScript : MonoBehaviour
{
    public Button drum;
    public Button guitar;
    public Button keyboard;



    void Start()
    {
        Button btn = drum.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClickDrum);

        Button btn2 = guitar.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickGuitar);

        Button btn3 = keyboard.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClickKeyboard);

        
    }

    void TaskOnClickDrum()
    {

        for (int i = 0; i < 5; i++)
        {
            GameObject.FindGameObjectWithTag("drum_image (" + i + ")").GetComponent<Image>().enabled = true;
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject.FindGameObjectWithTag("guitar_image (" + i + ")").GetComponent<Image>().enabled = false;
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject.FindGameObjectWithTag("keyboard_image (" + i + ")").GetComponent<Image>().enabled = false;
        }


    }

    void TaskOnClickGuitar()
    {

        for (int i = 0; i < 5; i++)
        {
            GameObject.FindGameObjectWithTag("drum_image (" + i + ")").GetComponent<Image>().enabled = false;
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject.FindGameObjectWithTag("guitar_image (" + i + ")").GetComponent<Image>().enabled = true;
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject.FindGameObjectWithTag("keyboard_image (" + i + ")").GetComponent<Image>().enabled = false;
        }
    }

    void TaskOnClickKeyboard()
    {

        for (int i = 0; i < 5; i++)
        {
            GameObject.FindGameObjectWithTag("drum_image (" + i + ")").GetComponent<Image>().enabled = false;
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject.FindGameObjectWithTag("guitar_image (" + i + ")").GetComponent<Image>().enabled = false;
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject.FindGameObjectWithTag("keyboard_image (" + i + ")").GetComponent<Image>().enabled = true;
        }
    }
}
