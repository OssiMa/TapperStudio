using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Paska koodaaja nyt on 2 inventoryy");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public delegate void OnAchievementChange();
    public OnAchievementChange onAchievementChangedCallback;

    public List<ScriptableAchievement> Achievements = new List<ScriptableAchievement>();

    public void AddItem(Item item)
    {
        items.Add(item);

        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void AddAchievement(ScriptableAchievement achievement)
    {
        Achievements.Add(achievement);

        if (onAchievementChangedCallback != null)
        {
            onAchievementChangedCallback.Invoke();
        }
    }

    public void RemoveAchievement(ScriptableAchievement achievement)
    {
        Achievements.Remove(achievement);

        if (onAchievementChangedCallback != null)
        {
            onAchievementChangedCallback.Invoke();
        }
    }

}
