using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSlot : MonoBehaviour
{
    Inventory inventory;

    public Image icon;

    public Button button;
    public Text Text;
    ColorBlock cb;
    Color32 buttonColor;
    //[HideInInspector]
    public ScriptableAchievement achievement;
    public ScriptableAchievement achievement2;
    public ScriptableAchievement achievement3;

    public UIAchievementInventory UIAchievementInventory;

    private void Start()
    {
        print(UIAchievementInventory.page);
        if (UIAchievementInventory.page == 1)
        {
            AddAchievement(achievement);
        }
        else if (UIAchievementInventory.page == 2)
        {
            AddAchievement(achievement2);
        }
        else if (UIAchievementInventory.page == 3)
        {
            AddAchievement(achievement3);
        }

    }

    public void PageUpdate()
    {
        print(UIAchievementInventory.page);
        ClearSlot();

        //if (UIAchievementInventory.page == 1)
        //{
        //    AddAchievement(achievement);
        //}
        //else if (UIAchievementInventory.page == 2)
        //{
        //    AddAchievement(achievement2);
        //}
        //else if (UIAchievementInventory.page == 3)
        //{
        //    AddAchievement(achievement3);
        //}
    }

    public void AddAchievement(ScriptableAchievement newAchievement)
    {
        button = GetComponent<Button>();
        if (UIAchievementInventory.page == 1)
        {
            newAchievement = achievement;
        }
        else if (UIAchievementInventory.page == 2)
        {
            newAchievement = achievement2;
        }
        else if (UIAchievementInventory.page == 3)
        {
            newAchievement = achievement3;
        }


        //cb = button.colors;
        //Color32 newColor = skin.color;
        //newColor.a = 255;
        //cb.normalColor = newColor;
        //button.colors = cb;

        icon.sprite = achievement.AchievementIcon;
        icon.enabled = true;
        Text.text = achievement.AchievementText;
        Text.enabled = true;
        button.interactable = false;

    }

    public void ClearSlot()
    {

        button = GetComponent<Button>();

        icon.sprite = null;
        icon.enabled = false;
        Text.text = null;
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
