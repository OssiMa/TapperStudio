using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumChange : MonoBehaviour {

    public Animator albumAnimator;

    public void MoveBarEndsong()
    {
        if (!albumAnimator.GetBool("atStart"))
        {
            albumAnimator.SetBool("atStart", true);
        }
    }

    public void MoveBarNewsong()
    {
        if (albumAnimator.GetBool("atStart"))
        {
            albumAnimator.SetBool("atStart", false);
        }
    }
}
