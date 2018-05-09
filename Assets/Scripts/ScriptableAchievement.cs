using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableAchievement", menuName = "Achievement/New Achievement")]
public class ScriptableAchievement : ScriptableObject
{

    public string AchievementText;
    public Sprite AchievementIcon;
    public bool unlocked = false;
    public int order;
    public int slot = 0;


}
