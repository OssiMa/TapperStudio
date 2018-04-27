using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : ScriptableObject {

    [HideInInspector]
    public Sprite instrumentIcon;

    public Color color;

    public int instrument;
    public int skinSlot;

    public int vintageLock;

    public bool trinket = false;

    [HideInInspector]
    public bool unlocked = false;

}
