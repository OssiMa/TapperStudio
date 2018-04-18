using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Item : ScriptableObject {

    public string rarity = "";
    public string itemName = "";
    public string instrument = "";
    public int slot = 0;
    public float generationBoost = 0;
    public float maxcombo = 0;
    public float level = 0;
}
