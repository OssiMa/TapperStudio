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
        inventory = Inventory.instance;
        inventory.onAchievementChangedCallback += PageUpdate;

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
        inventory.onAchievementChangedCallback.Invoke();
    }

    public void PageUpdate()
    {

        ClearSlot();

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

    public void AddAchievement(ScriptableAchievement newAchievement)
    {
        button = GetComponent<Button>();
        if (UIAchievementInventory.page == 1)
        {
            newAchievement = achievement;
            icon.sprite = achievement.AchievementIcon;
            Text.text = achievement.AchievementText;
            if (achievement.unlocked == true)
            {
                GetComponent<Image>().color = Color.green;
            }
            else
            {
                GetComponent<Image>().color = Color.gray;
            }
        }
        else if (UIAchievementInventory.page == 2)
        {
            newAchievement = achievement2;
            icon.sprite = achievement2.AchievementIcon;
            Text.text = achievement2.AchievementText;
            if (achievement2.unlocked == true)
            {
                GetComponent<Image>().color = Color.green;
            }
            else
            {
                GetComponent<Image>().color = Color.gray;
            }
        }
        else if (UIAchievementInventory.page == 3)
        {
            newAchievement = achievement3;
            icon.sprite = achievement3.AchievementIcon;
            Text.text = achievement3.AchievementText;
            if (achievement2.unlocked == true)
            {
                GetComponent<Image>().color = Color.green;
            }
            else
            {
                GetComponent<Image>().color = Color.gray;
            }
        }

        icon.enabled = true;
        Text.enabled = true;
        button.interactable = false;

        //GetComponent<Image>().color = Color.green;

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

}
