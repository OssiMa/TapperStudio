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
       
    }

    public void AddAchievement(ScriptableAchievement newAchievement)
    {
        icon = GetComponent<Image>();

        achievement = newAchievement;

        button = GetComponent<Button>();

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
        icon = GetComponent<Image>();

        button = GetComponent<Button>();

        //cb = button.colors;
        //cb.normalColor = skin.color;
        //button.colors = cb;

        //icon.sprite = Resources.Load<Sprite>("tab_menubackground");
        //print(icon.sprite);
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

}
