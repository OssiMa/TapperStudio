using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableAchievement", menuName = "Achievement/New Achievement")]
public class ScriptableAchievement : ScriptableObject
{

    [HideInInspector]
    public Sprite AchievementIcon;

    public Color32 color;

    public bool trinket = false;

    [HideInInspector]
    public bool unlocked = false;

}
