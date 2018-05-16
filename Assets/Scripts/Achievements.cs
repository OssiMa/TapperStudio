using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour {

    public List<string> AllAchievements;
    public List<string> DoneAchievements;

    public AchievementSlot AchievementSlot1;
    public AchievementSlot AchievementSlot2;
    public AchievementSlot AchievementSlot3;
    public AchievementSlot AchievementSlot4;
    public AchievementSlot AchievementSlot5;


    // Use this for initialization
    void Start ()
    {

    }

    public void AchievementDone(int caseSwitch)
    {
         
        switch (caseSwitch)
        {
            case 1:
                AchievementSlot1.achievement.unlocked = true;

                break;

            case 2:
                AchievementSlot1.achievement2.unlocked = true;

                break;

            case 3:
                AchievementSlot1.achievement3.unlocked = true;

                break;

            case 4:
                AchievementSlot2.achievement.unlocked = true;

                break;

            case 5:
                AchievementSlot2.achievement2.unlocked = true;

                break;

            case 6:
                AchievementSlot2.achievement3.unlocked = true;

                break;

            case 7:
                AchievementSlot3.achievement.unlocked = true;

                break;

            case 8:
                AchievementSlot3.achievement2.unlocked = true;

                break;

            case 9:
                AchievementSlot3.achievement3.unlocked = true;

                break;

            case 10:
                AchievementSlot4.achievement.unlocked = true;

                break;

            case 11:
                AchievementSlot4.achievement2.unlocked = true;

                break;

            case 12:
                AchievementSlot4.achievement3.unlocked = true;

                break;

            case 13:
                AchievementSlot5.achievement.unlocked = true;

                break;

            case 14:
                AchievementSlot5.achievement2.unlocked = true;

                break;

            case 15:
                AchievementSlot5.achievement3.unlocked = true;

                break;

            default:
                print("suatana");
                break;
        }
    }

}