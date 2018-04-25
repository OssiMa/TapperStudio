using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumChangeAnimationScript : MonoBehaviour
{
    public Animator albumAnimator;
    public Button albumButton;

    void Start()
    {
        Button btn = albumButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        if (!albumAnimator.GetBool("atStart"))
        {
            albumAnimator.SetBool("atStart", true);
        }

    }

}

