using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour {

    public List<ScriptableAchievement> CurrencyAchievements;
    public List<ScriptableAchievement> GameTimeAchievements;
    public List<ScriptableAchievement> DrumAchievements;
    public List<ScriptableAchievement> GuitarAchievements;
    public List<ScriptableAchievement> PianoAchievements;
    public List<ScriptableAchievement> DrumComboAchievements;
    public List<ScriptableAchievement> GuitarComboAchievements;
    public List<ScriptableAchievement> PianoComboAchievements;
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
    int DrumComboNumber = 0;
    int GuitarComboNumber = 0;
    int PianoComboNumber = 0;

    bool isAchievedD = false;
    bool isAchievedD2 = false;
    bool isAchievedD3 = false;
    bool isAchievedD4 = false;
    bool isAchievedD5 = false;

    bool isAchievedG = false;
    bool isAchievedG2 = false;
    bool isAchievedG3 = false;
    bool isAchievedG4 = false;
    bool isAchievedG5 = false;

    bool isAchievedP = false;
    bool isAchievedP2 = false;
    bool isAchievedP3 = false;
    bool isAchievedP4 = false;
    bool isAchievedP5 = false;


    [HideInInspector]
    public InstrumentBase drumBase;
    public InstrumentBase guitarBase;
    public InstrumentBase pianoBase;

    // Use this for initialization
    void Start ()
    {
        guitarBase = GameObject.Find("Guitar").GetComponent<InstrumentBase>();
        drumBase = GameObject.Find("Drums").GetComponent<InstrumentBase>();
        pianoBase = GameObject.Find("Piano").GetComponent<InstrumentBase>();

    }

    private void Update()
    {
        if (drumBase.level == 3 && !isAchievedD)
        {
            isAchievedD = true;
            AchievementDone(13);
        }
        else if (drumBase.level == 6 && !isAchievedD2)
        {
            isAchievedD2 = true;
            AchievementDone(13);
        }
        else if (drumBase.level == 10 && !isAchievedD3)
        {
            isAchievedD3 = true;
            AchievementDone(13);
        }
        else if (drumBase.level == 15 && !isAchievedD4)
        {
            isAchievedD4 = true;
            AchievementDone(13);
        }
        else if (drumBase.level == 20 && !isAchievedD5)
        {
            isAchievedD5 = true;
            AchievementDone(13);
        }

        if (guitarBase.level == 3 && !isAchievedG)
        {
            isAchievedG = true;
            AchievementDone(2);
        }
        else if (guitarBase.level == 6 && !isAchievedG2)
        {
            isAchievedG2 = true;
            AchievementDone(2);
        }
        else if (guitarBase.level == 10 && !isAchievedG3)
        {
            isAchievedG3 = true;
            AchievementDone(2);
        }
        else if (guitarBase.level == 15 && !isAchievedG4)
        {
            isAchievedG4 = true;
            AchievementDone(2);
        }
        else if (guitarBase.level == 20 && !isAchievedG5)
        {
            isAchievedG5 = true;
            AchievementDone(2);
        }


        if (pianoBase.level == 3 && !isAchievedP)
        {
            isAchievedP = true;
            AchievementDone(5);
        }
        else if (pianoBase.level == 6 && !isAchievedP2)
        {
            isAchievedP2 = true;
            AchievementDone(5);
        }
        else if (pianoBase.level == 10 && !isAchievedP3)
        {
            isAchievedP3 = true;
            AchievementDone(5);
        }
        else if (pianoBase.level == 15 && !isAchievedP4)
        {
            isAchievedP4 = true;
            AchievementDone(5);
        }
        else if (pianoBase.level == 20 && !isAchievedP5)
        {
            isAchievedP5 = true;
            AchievementDone(5);
        }
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
                AchievementSlot1.PageUpdate();
                break;

            case 2:
                AchievementSlot1.achievement2.unlocked = true;
                GuitarNumber += 1;
                if (GuitarNumber == 5)
                {

                }
                else
                {
                    AchievementSlot1.achievement2 = GuitarAchievements[GuitarNumber];
                }
                AchievementSlot1.PageUpdate();
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
                AchievementSlot2.PageUpdate();
                break;

            case 5:
                AchievementSlot2.achievement2.unlocked = true;
                PianoNumber += 1;
                if (PianoNumber == 5)
                {

                }
                else
                {
                    AchievementSlot2.achievement2 = PianoAchievements[PianoNumber];
                }
                AchievementSlot2.PageUpdate();
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
                AchievementSlot3.PageUpdate();
                break;

            case 8:
                AchievementSlot3.achievement2.unlocked = true;
                DrumComboNumber += 1;
                if (DrumComboNumber == 5)
                {

                }
                else
                {
                    AchievementSlot3.achievement2 = DrumComboAchievements[DrumComboNumber];
                }
                AchievementSlot3.PageUpdate();
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
                AchievementSlot4.PageUpdate();
                break;

            case 11:
                AchievementSlot4.achievement2.unlocked = true;
                GuitarComboNumber += 1;
                if (GuitarComboNumber == 5)
                {

                }
                else
                {
                    AchievementSlot4.achievement2 = GuitarComboAchievements[GuitarComboNumber];
                }
                AchievementSlot4.PageUpdate();
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
                AchievementSlot5.PageUpdate();
                break;

            case 14:
                AchievementSlot5.achievement2.unlocked = true;
                PianoComboNumber += 1;
                if (PianoComboNumber == 5)
                {

                }
                else
                {
                    AchievementSlot5.achievement2 = PianoComboAchievements[PianoComboNumber];
                }
                AchievementSlot5.PageUpdate();
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