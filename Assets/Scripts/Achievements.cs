using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour {

    public List<ScriptableAchievement> CurrencyAchievements;
    public List<ScriptableAchievement> GameTimeAchievements;
    public List<ScriptableAchievement> DrumAchievements;
    public List<ScriptableAchievement> GiutarAchievements;
    public List<ScriptableAchievement> PianoAchievements;
    public List<ScriptableAchievement> SongAchievements;
    public List<ScriptableAchievement> AlbumAchievements;


    
    public AchievementSlot AchievementSlot1;
    public AchievementSlot AchievementSlot2;
    public AchievementSlot AchievementSlot3;
    public AchievementSlot AchievementSlot4;
    public AchievementSlot AchievementSlot5;

    int SongNumber = 0;
    int AlbumNumber = 0;
    int TimeNumber = 0;
    int CurrencyNumber = 0;
    int DrumNumber = 0;
    int GuitarNumber = 0;
    int PianoNumber = 0;


    // Use this for initialization
    void Start ()
    {
        AchievementDone(1);
        AchievementDone(4);
        AchievementDone(7);
        AchievementDone(10);
        AchievementDone(13);


    }

    public void AchievementDone(int caseSwitch)
    {
         
        switch (caseSwitch)
        {
            case 1:
                AchievementSlot1.achievement.unlocked = true;
                SongNumber += 1;
                if (SongNumber == 5)
                {

                }
                else
                {
                    AchievementSlot1.achievement = SongAchievements[SongNumber];
                }

                break;

            case 2:
                AchievementSlot1.achievement2.unlocked = true;

                break;

            case 3:
                AchievementSlot1.achievement3.unlocked = true;

                break;

            case 4:
                AchievementSlot2.achievement.unlocked = true;
                AlbumNumber += 1;
                if (AlbumNumber == 5)
                {

                }
                else
                {
                    AchievementSlot2.achievement = AlbumAchievements[AlbumNumber];
                }

                break;

            case 5:
                AchievementSlot2.achievement2.unlocked = true;

                break;

            case 6:
                AchievementSlot2.achievement3.unlocked = true;

                break;

            case 7:
                AchievementSlot3.achievement.unlocked = true;
                TimeNumber += 1;
                if (TimeNumber == 5)
                {

                }
                else
                {
                    AchievementSlot3.achievement = GameTimeAchievements[TimeNumber];
                }

                break;

            case 8:
                AchievementSlot3.achievement2.unlocked = true;

                break;

            case 9:
                AchievementSlot3.achievement3.unlocked = true;

                break;

            case 10:
                AchievementSlot4.achievement.unlocked = true;
                CurrencyNumber += 1;
                if (CurrencyNumber == 5)
                {

                }
                else
                {
                    AchievementSlot4.achievement = CurrencyAchievements[CurrencyNumber];
                }

                break;

            case 11:
                AchievementSlot4.achievement2.unlocked = true;

                break;

            case 12:
                AchievementSlot4.achievement3.unlocked = true;

                break;

            case 13:
                AchievementSlot5.achievement.unlocked = true;
                DrumNumber += 1;
                if (DrumNumber == 5)
                {

                }
                else
                {
                    AchievementSlot5.achievement = DrumAchievements[DrumNumber];
                }

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