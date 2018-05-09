using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour {

    public List<string> AllAchievements;
    public List<string> DoneAchievements;


    public ScriptableAchievement DrumLevel3;
    public ScriptableAchievement GuitarLevel3;
    public ScriptableAchievement PianoLevel3;
    public ScriptableAchievement AllLevel3;
    public ScriptableAchievement DrumCombo;
    public ScriptableAchievement CompleteASong;
    public ScriptableAchievement CompleteAnAlbum;

    ScriptableAchievement achievement;

    // Use this for initialization
    void Start () {
        for (int i = 1; i < 7; i++)
        {
            NewAchievement(i);
        }
    }

    public void NewAchievement(int order)
    {
        achievement = new ScriptableAchievement();
        achievement.order = order;
        achievement.slot = Random.Range(1, 4);
        Inventory.instance.AddAchievement(achievement);
    }

    }