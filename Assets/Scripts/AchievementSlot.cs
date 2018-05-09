using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSlot : MonoBehaviour
{

    public Image icon;

    public Button button;
    public Text Text;
    ColorBlock cb;
    Color32 buttonColor;
    [HideInInspector]
    public ScriptableAchievement achievement;

    private void Start()
    {
        AddAchievement(achievement);
    }

    public void AddAchievement(ScriptableAchievement newAchievement)
    {
        button = GetComponent<Button>();

        achievement = newAchievement;
        //cb = button.colors;
        //Color32 newColor = skin.color;
        //newColor.a = 255;
        //cb.normalColor = newColor;
        //button.colors = cb;

        icon.sprite = achievement.AchievementIcon;
        icon.enabled = true;
        Text.text = achievement.AchievementText;
        button.interactable = false;

    }

    public void ClearSlot()
    {
        button = GetComponent<Button>();
        achievement = null;

        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
    }

    public void LockSlot()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        //If we want to add an extra sprite here, just add a child with the sprite to all slot objects. 
        //When a slot is locked, set the child (or the child's sprite) to true.
    }

    public ScriptableAchievement GetAchievement()
    {
        return achievement;
    }

    public void Equipped()
    {
        Text.enabled = true;
    }

}
