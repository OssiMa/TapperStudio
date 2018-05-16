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
    float expToNext = 25;
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
            print("vintagee");
        }
    }

    public void VintageLvlUp()
    {
        vintageLevel += 1;
        exp = 0;
        expToNext = 25;
        level = 1;
        nextLevel = 2;
        if(vintageLevel<3)
        {
            availableSlots += 1;
            InventoryUI.instance.GainEquipSlot(this);
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
