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

        if (level == 3 && achievements.DrumNumber == 0 && instrumentNbr == 1)
        {
            achievements.AchievementDone(13);
        }
        else if (level == 6 && achievements.DrumNumber == 1 && instrumentNbr == 1)
        {
            achievements.AchievementDone(13);
        }
        else if (level == 10 && achievements.DrumNumber == 2 && instrumentNbr == 1)
        {
            achievements.AchievementDone(13);
        }
        else if (level == 15 && achievements.DrumNumber == 3 && instrumentNbr == 1)
        {
            achievements.AchievementDone(13);
        }
        else if (level == 20 && achievements.DrumNumber == 4 && instrumentNbr == 1)
        {
            achievements.AchievementDone(13);
        }

        if (level == 3 && achievements.GuitarNumber == 0 && instrumentNbr == 2)
        {
            achievements.AchievementDone(2);
        }
        else if (level == 6 && achievements.GuitarNumber == 1 && instrumentNbr == 2)
        {
            achievements.AchievementDone(2);
        }
        else if (level == 10 && achievements.GuitarNumber == 2 && instrumentNbr == 2)
        {
            achievements.AchievementDone(2);
        }
        else if (level == 15 && achievements.GuitarNumber == 3 && instrumentNbr == 2)
        {
            achievements.AchievementDone(2);
        }
        else if (level == 20 && achievements.GuitarNumber == 4 && instrumentNbr == 2)
        {
            achievements.AchievementDone(2);
        }


        if (level == 3 && achievements.PianoNumber == 0 && instrumentNbr == 3)
        {
            achievements.AchievementDone(5);
        }
        else if (level == 6 && achievements.PianoNumber == 1 && instrumentNbr == 3)
        {
            achievements.AchievementDone(5);
        }
        else if (level == 10 && achievements.PianoNumber == 2 && instrumentNbr == 3)
        {
            achievements.AchievementDone(5);
        }
        else if (level == 15 && achievements.PianoNumber == 3 && instrumentNbr == 3)
        {
            achievements.AchievementDone(5);
        }
        else if (level == 20 && achievements.PianoNumber == 4 && instrumentNbr == 3)
        {
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
                comboAchievement();
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
            comboStep += 5;
            if (comboStep >= comboStepMax)
            {
                combo += 1;
                comboStep = 0;
                comboAchievement();
            }
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
    void comboAchievement()
    {
        if (combo == 3 && achievements.DrumComboNumber == 0 && instrumentNbr == 1)
        {
            achievements.AchievementDone(8);
        }
        else if (combo == 6 && achievements.DrumComboNumber == 1 && instrumentNbr == 1)
        {
            achievements.AchievementDone(8);
        }
        else if (combo == 10 && achievements.DrumComboNumber == 2 && instrumentNbr == 1)
        {
            achievements.AchievementDone(8);
        }
        else if (combo == 15 && achievements.DrumComboNumber == 3 && instrumentNbr == 1)
        {
            achievements.AchievementDone(8);
        }
        else if (combo == 20 && achievements.DrumComboNumber == 4 && instrumentNbr == 1)
        {
            achievements.AchievementDone(8);
        }

        if (combo == 3 && achievements.GuitarComboNumber == 0 && instrumentNbr == 2)
        {
            achievements.AchievementDone(11);
        }
        else if (combo == 6 && achievements.GuitarComboNumber == 1 && instrumentNbr == 2)
        {
            achievements.AchievementDone(11);
        }
        else if (combo == 10 && achievements.GuitarComboNumber == 2 && instrumentNbr == 2)
        {
            achievements.AchievementDone(11);
        }
        else if (combo == 15 && achievements.GuitarComboNumber == 3 && instrumentNbr == 2)
        {
            achievements.AchievementDone(11);
        }
        else if (combo == 20 && achievements.GuitarComboNumber == 4 && instrumentNbr == 2)
        {
            achievements.AchievementDone(11);
        }


        if (combo == 3 && achievements.PianoComboNumber == 0 && instrumentNbr == 3)
        {
            achievements.AchievementDone(14);
        }
        else if (combo == 6 && achievements.PianoComboNumber == 1 && instrumentNbr == 3)
        {
            achievements.AchievementDone(14);
        }
        else if (combo == 10 && achievements.PianoComboNumber == 2 && instrumentNbr == 3)
        {
            achievements.AchievementDone(14);
        }
        else if (combo == 15 && achievements.PianoComboNumber == 3 && instrumentNbr == 3)
        {
            achievements.AchievementDone(14);
        }
        else if (combo == 20 && achievements.PianoComboNumber == 4 && instrumentNbr == 3)
        {
            achievements.AchievementDone(14);
        }
    }
}
