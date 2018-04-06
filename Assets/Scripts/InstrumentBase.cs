using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InstrumentBase : MonoBehaviour {


    public SongProgress progression;


    public Slider xpBar;
    public Text currLvl;
    public Text nxtLvl;
    public Text comboText;

    public float exp = 0;
    float startXp;
    float expToNext = 15;
    float level = 1;
    float nextLevel = 2;

    float combo = 1;
    float comboStep;
    float comboStepMax = 20;
    float comboUpkeep = 5;


	// Use this for initialization
	void Start ()
    {
        //LoadGame();
        xpBar.minValue = startXp;
        xpBar.maxValue = expToNext;
        currLvl.text = "" + level;
        nxtLvl.text = "" + nextLevel;
        nextLevel = level + 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        comboText.text = "Combo: " + combo;
        xpBar.value = exp;
        nxtLvl.text = "" + nextLevel;
        currLvl.text = "" + level;

        if (exp >= expToNext)
        {
            level += 1;
            nextLevel += 1;
            startXp = expToNext;
            expToNext = expToNext*2.5f;
            xpBar.minValue = startXp;
            xpBar.maxValue = expToNext;

        }


        SaveGame();
	}

    public void Tap()
    {
        exp += 1*combo;
        progression.GainXP();
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
        if (combo < 4)
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
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tap();
        }
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


        Debug.Log("Game Saved");
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.DrumLevel = level;
        save.DrumXp = exp;
        save.NextDrumLevel = expToNext;
        save.StartXp = startXp;

        save.SongProgress = progression.songXP;
        save.SongsCompleted = progression.songCount;
        save.CurrentAlbum = progression.currentAlbum;
        save.AlbumsCreated = progression.AlbumsCreated;
        save.combo = combo;

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
            level = save.DrumLevel;
            exp = save.DrumXp;
            expToNext = save.NextDrumLevel;
            startXp = save.StartXp;
            combo = save.combo;

            progression.songXP = save.SongProgress;
            progression.songCount = save.SongsCompleted;
            progression.currentAlbum = save.CurrentAlbum;
            progression.AlbumsCreated = save.AlbumsCreated;

            Debug.Log("Game Loaded");

        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}
