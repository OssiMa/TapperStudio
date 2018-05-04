using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Skin/New Skin")]
public class Skin : ScriptableObject {

    [HideInInspector]
    public Sprite instrumentIcon;

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
