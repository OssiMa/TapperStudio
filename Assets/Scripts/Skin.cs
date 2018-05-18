using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Skin/New Skin")]
public class Skin : ScriptableObject {

    [HideInInspector]
    public Sprite instrumentIcon;

    [HideInInspector]
    public Sprite specialIcon1;
    [HideInInspector]
    public Sprite specialIcon2;
    [HideInInspector]
    public Sprite specialIcon3;
    [HideInInspector]
    public Sprite specialIcon4;
    [HideInInspector]
    public Sprite specialIcon5;

    public Color32 color;

    public int instrument;
    //public int skinSlot;

    public int vintageLock;

    //public bool trinket = false;
    public int trinketType;

    [HideInInspector]
    public bool unlocked = false;

    public bool baseInstrument;

}
