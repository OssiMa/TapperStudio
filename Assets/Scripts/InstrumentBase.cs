using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InstrumentBase : MonoBehaviour {

    InventoryUI invUI;


    public SongProgress progression;


    public Slider xpBar;
    public Slider fadeSlider;
    public Text currLvl;
    public Text nxtLvl;
    public Text comboText;

    public float exp = 0;       //instrument experience, don't confuse with song progress
    float startXp;
    public float expToNext = 25;
    public float level = 1;
    float nextLevel = 2;
    [HideInInspector]
    public int vintageLevel = 0;
    public int instrumentNbr;
    public int availableSlots = 1;

    public float combo = 1;                 //current combo
    public float comboStep;                 //when at combostemax, combo increases
    public float comboStepMax = 20;         //combo up when reached
    public float comboUpkeep = 5;           //mistakes player can make before losing combo
    public float comboFade = 1000;          //how long the instrument needs to be inactive to lose combo

    float ogMaxCombo;
    [HideInInspector]
    public float maxCombo;

    float geneBoost;
    float comboBoost;
    public float xpBoost;

    public Achievements achievements;

    public bool isAchievedD = false;
    public bool isAchievedD2 = false;
    public bool isAchievedD3 = false;
    public bool isAchievedD4 = false;
    public bool isAchievedD5 = false;

    public bool isAchievedG = false;
    public bool isAchievedG2 = false;
    public bool isAchievedG3 = false;
    public bool isAchievedG4 = false;
    public bool isAchievedG5 = false;

    public bool isAchievedP = false;
    public bool isAchievedP2 = false;
    public bool isAchievedP3 = false;
    public bool isAchievedP4 = false;
    public bool isAchievedP5 = false;


    // Use this for initialization
    void Start ()
    {
        invUI = InventoryUI.instance;
        //LoadGame();
        xpBar.minValue = startXp;
        xpBar.maxValue = expToNext;
        fadeSlider.maxValue = comboFade;
        currLvl.text = "" + level;
        nxtLvl.text = "" + nextLevel;
        nextLevel = level + 1.0f;
        BoostUpdate();
        ogMaxCombo = 4;
        achievements = GameObject.Find("GameManager").GetComponent<Achievements>();
    }

    // Update is called once per frame
    void Update()
    {
        if (progression.menu == false)
        { 
            fadeSlider.value = comboFade;
            comboText.text = "Combo: " + combo;
            xpBar.value = exp;
            nxtLvl.text = "" + nextLevel;
            currLvl.text = "" + level;
            LvlUp();
            SaveGame();
            BoostUpdate();
            maxCombo = ogMaxCombo + comboBoost;
        }
    }

    void LvlUp()
    {
        if (exp >= expToNext && level < 19)
        {
            level += 1;
            nextLevel += 1;
            startXp = expToNext;
            expToNext = expToNext * 1.1f;
            xpBar.minValue = startXp;
            xpBar.maxValue = expToNext;

        }
        else if (level == 19 && exp >= expToNext)
        {
            level = 20;
        }
        if (level == 3 && !isAchievedD && instrumentNbr == 1)
        {
            isAchievedD = true;
            achievements.AchievementDone(13);
        }
        else if (level == 6 && !isAchievedD2 && instrumentNbr == 1)
        {
            isAchievedD2 = true;
            achievements.AchievementDone(13);
        }
        else if (level == 10 && !isAchievedD3 && instrumentNbr == 1)
        {
            isAchievedD3 = true;
            achievements.AchievementDone(13);
        }
        else if (level == 15 && !isAchievedD4 && instrumentNbr == 1)
        {
            isAchievedD4 = true;
            achievements.AchievementDone(13);
        }
        else if (level == 20 && !isAchievedD5 && instrumentNbr == 1)
        {
            isAchievedD5 = true;
            achievements.AchievementDone(13);
        }

        if (level == 3 && !isAchievedG && instrumentNbr == 2)
        {
            isAchievedG = true;
            achievements.AchievementDone(2);
        }
        else if (level == 6 && !isAchievedG2 && instrumentNbr == 2)
        {
            isAchievedG2 = true;
            achievements.AchievementDone(2);
        }
        else if (level == 10 && !isAchievedG3 && instrumentNbr == 2)
        {
            isAchievedG3 = true;
            achievements.AchievementDone(2);
        }
        else if (level == 15 && !isAchievedG4 && instrumentNbr == 2)
        {
            isAchievedG4 = true;
            achievements.AchievementDone(2);
        }
        else if (level == 20 && !isAchievedG5 && instrumentNbr == 2)
        {
            isAchievedG5 = true;
            achievements.AchievementDone(2);
        }


        if (level == 3 && !isAchievedP && instrumentNbr == 3)
        {
            isAchievedP = true;
            achievements.AchievementDone(5);
        }
        else if (level == 6 && !isAchievedP2 && instrumentNbr == 3)
        {
            isAchievedP2 = true;
            achievements.AchievementDone(5);
        }
        else if (level == 10 && !isAchievedP3 && instrumentNbr == 3)
        {
            isAchievedP3 = true;
            achievements.AchievementDone(5);
        }
        else if (level == 15 && !isAchievedP4 && instrumentNbr == 3)
        {
            isAchievedP4 = true;
            achievements.AchievementDone(5);
        }
        else if (level == 20 && !isAchievedP5 && instrumentNbr == 3)
        {
            isAchievedP5 = true;
            achievements.AchievementDone(5);
        }
    }

    public void VintageLvlUp()
    {
        vintageLevel += 1;
        exp = 0;
        expToNext = 25;
        level = 1;
        nextLevel = 2;
        if(availableSlots<3)
        {
            availableSlots += 1;
            InventoryUI.instance.GainEquipSlot(this);
            Inventory.instance.onItemChangedCallback.Invoke();
        }
    }

    public void Tap()
    {
        if (comboUpkeep > 0)
        {
            comboUpkeep -= 2;
        }
        else if (comboUpkeep <= 0 && combo >1)
        {
            combo -= 1;
            comboStep = 0;
            comboUpkeep = 4;
        }
    }

    public void ComboTap()
    {
        exp += 0.5f * combo + xpBoost;
        progression.GainXP();
        if (combo < maxCombo)     //4 + comboBoost
        {
            comboStep += 1;
            if (comboStep >= comboStepMax)
            {
                combo += 1;
                comboStep = 0;
            }
        }
        if (comboUpkeep <11)
        {
            comboUpkeep += 3;
        }
        ComboFadeUp();
    }

    public void ComboFading()
    {
        if (combo > 1)
        {
            combo -= 1;
            comboFade = 500;
        }
    }

    void ComboFadeUp()
    {
        if (comboFade < 1000)
        {
            comboFade += 50;
        }
    }

    public void BigExpReward()
    {
        exp += 2 * combo + xpBoost * 4;
        progression.GainXP();
        progression.GainXP();
        progression.GainXP();
        if(combo < maxCombo)        // 4 + comboBoost
        {
            combo += 1;
            comboStep = 0;
        }
        ComboFadeUp();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tap();
        }
    }
    
    public float GetBoosts(int i)
    {
        invUI = InventoryUI.instance;
        if (invUI.EquipBoosts(instrumentNbr, i) != null)
        {
            Item booster = invUI.EquipBoosts(instrumentNbr, i);
            float boostValue = booster.boostPower + (booster.level / 4);
            return booster.boostPower;
        }
        else
        {
            return 0;
        }
        
    }

    public void BoostUpdate()
    {
        geneBoost = GetBoosts(1);
        comboBoost = GetBoosts(2);
        xpBoost = GetBoosts(3);
    }

    public void SaveGame()
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.drumLevel = level;
        save.drumXp = exp;
        save.nextDrumLevel = expToNext;
        save.startXp = startXp;

        save.songProgress = progression.songXP;
        save.songsCompleted = progression.songCount;
        save.currentAlbum = progression.currentAlbum;
        save.currentSong = progression.currentSong;
        save.albumsCreated = progression.AlbumsCreated;
        save.usedAlbums = progression.UsedNames;
        save.combo = combo;

        save.currency = progression.currency;

        return save;
    }

    public void LoadGame()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {


            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();



            // 4
            level = save.drumLevel;
            exp = save.drumXp;
            expToNext = save.nextDrumLevel;
            startXp = save.startXp;
            combo = save.combo;

            progression.songXP = save.songProgress;
            progression.songCount = save.songsCompleted;
            progression.currentAlbum = save.currentAlbum;
            progression.currentSong = save.currentSong;
            progression.AlbumsCreated = save.albumsCreated;
            progression.UsedNames = save.usedAlbums;
            progression.currency = save.currency;

            Debug.Log("Game Loaded");

        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}
