﻿using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour {

    public Image icon;
    public Image background;
    public Text rarity;
    public GameObject iconStuff;

    Item item;
    ScriptableAchievement achievement;


    public void EquipItem(Item newItem)
    {
        item = newItem;

        if (item != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
            rarity.text = "" + item.rarity;
            RarityColor();
            iconStuff.SetActive(true);
        }
        else CleanSlot();

    }

    public void EquipAchievement(ScriptableAchievement newAchievement)
    {
        achievement = newAchievement;

        icon.sprite = achievement.AchievementIcon;
        icon.enabled = true;
        rarity.text = achievement.AchievementText;
        rarity.enabled = true;

       
    }

    public void CleanSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        rarity.text = "";
        background.color = new Color32(255, 255, 255, 255);
        iconStuff.SetActive(false);
    }

    public void RarityColor()
    {
        if (item.rarity == 1)
        {
            background.color = new Color32(255, 255, 255, 255);
        }
        else if (item.rarity == 2)
        {
            background.color = new Color32(156, 255, 143, 255);
        }
        else if (item.rarity == 3)
        {
            background.color = new Color32(143, 181, 255, 255);
        }
        else if (item.rarity == 4)
        {
            background.color = new Color32(233, 133, 255, 255);
        }
        else
        {
            background.color = new Color32(255, 196, 68, 255);
        }

    }

}
