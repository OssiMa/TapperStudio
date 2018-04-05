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

    public float exp = 0;
    float startXp;
    float expToNext = 15;
    float level = 1;
    float nextLevel = 2;


	// Use this for initialization
	void Start () {
        LoadGame();
        xpBar.minValue = startXp;
        xpBar.maxValue = expToNext;
        currLvl.text = "" + level;
        nxtLvl.text = "" + nextLevel;
        nextLevel = level + 1.0f;


	}
	
	// Update is called once per frame
	void Update ()
    {
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
        exp += 1;
        progression.GainXP();
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

            Debug.Log("Game Loaded");

        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}
