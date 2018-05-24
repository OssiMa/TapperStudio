using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour {

    private float time;
    private float saveTime;

    [HideInInspector]
    public SongProgress progression;
    [HideInInspector]
    public InstrumentBase drumBase;
    [HideInInspector]
    public InstrumentBase guitarBase;
    [HideInInspector]
    public InstrumentBase pianoBase;
    [HideInInspector]
    public CurrencyManager currencyManager;
    [HideInInspector]
    public Achievements achievements;

    // Use this for initialization
    void Start () {
        guitarBase = GameObject.Find("Guitar").GetComponent<InstrumentBase>();
        drumBase = GameObject.Find("Drums").GetComponent<InstrumentBase>();
        pianoBase = GameObject.Find("Piano").GetComponent<InstrumentBase>();
        currencyManager = GameObject.Find("GameManager").GetComponent<CurrencyManager>();
        progression = GameObject.Find("SongProgression").GetComponent<SongProgress>();
        achievements = GameObject.Find("GameManager").GetComponent<Achievements>();
        //LoadGame();
        saveTime = 5;
        time = 0;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= saveTime)
        {
            SaveGame();
            time = 0;
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

    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        //Drum
        save.drumLevel = drumBase.level;
        save.drumXp = drumBase.exp;
        save.nextDrumLevel = drumBase.expToNext;
        save.drumStartXp = drumBase.startXp;
        save.drumCombo = drumBase.combo;

        //Guitar
        save.guitarLevel = guitarBase.level;
        save.guitarXp = guitarBase.exp;
        save.nextGuitarLevel = guitarBase.expToNext;
        save.guitarStartXp = guitarBase.startXp;

        //Piano
        save.pianoLevel = pianoBase.level;
        save.pianoXp = pianoBase.exp;
        save.nextPianoLevel = pianoBase.expToNext;
        save.pianoStartXp = pianoBase.startXp;

        //Songprogress
        save.songXp = progression.songXP;
        save.songsCompleted = progression.songCount;
        save.currentAlbum = progression.currentAlbum;
        save.currentSong = progression.currentSong;
        save.albumsCreated = progression.AlbumsCreated;
        save.usedNames = progression.UsedNames;


        //Currencymanager
        save.currency = currencyManager.currency;
        save.premiumCurrency = currencyManager.premiumCurrency;
        save.curInGamePlay = currencyManager.curInGameplay;

        //Achievements
        save.SongNumber = achievements.SongNumber;
        save.AlbumNumber = achievements.AlbumNumber;
        save.TimeNumber = achievements.TimeNumber;
        save.CurrencyNumber = achievements.CurrencyNumber;
        save.DrumNumber = achievements.DrumNumber;
        save.GuitarNumber = achievements.GuitarNumber;
        save.PianoNumber = achievements.PianoNumber;
        save.DrumComboNumber = achievements.DrumComboNumber;
        save.GuitarComboNumber = achievements.GuitarComboNumber;
        save.PianoComboNumber = achievements.PianoComboNumber;

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


            //Drum
            drumBase.level = save.drumLevel;
            drumBase.exp = save.drumXp;
            drumBase.expToNext = save.nextDrumLevel;
            drumBase.startXp = save.drumStartXp;
            drumBase.combo = save.drumCombo;

            //Guitar
            guitarBase.level = save.guitarLevel;
            guitarBase.exp = save.guitarXp;
            guitarBase.expToNext = save.nextGuitarLevel;
            guitarBase.startXp = save.guitarStartXp;

            //Piano
            pianoBase.level = save.pianoLevel;
            pianoBase.exp = save.pianoXp;
            pianoBase.expToNext = save.nextPianoLevel;
            pianoBase.startXp = save.pianoStartXp;

            //Songprogress
            progression.songXP = save.songXp;
            progression.songCount = save.songsCompleted;
            progression.currentAlbum = save.currentAlbum;
            progression.currentSong = save.currentSong;
            progression.AlbumsCreated = save.albumsCreated;
            progression.UsedNames = save.usedNames;


            //Currencymanager
            currencyManager.currency = save.currency;
            currencyManager.premiumCurrency = save.premiumCurrency;
            currencyManager.curInGameplay = save.curInGamePlay;

            //Achievements
            achievements.SongNumber = save.SongNumber;
            achievements.AlbumNumber = save.AlbumNumber;
            achievements.TimeNumber = save.TimeNumber;
            achievements.CurrencyNumber = save.CurrencyNumber;
            achievements.DrumNumber = save.DrumNumber;
            achievements.GuitarNumber = save.GuitarNumber;
            achievements.PianoNumber = save.PianoNumber;
            achievements.DrumComboNumber = save.DrumComboNumber;
            achievements.GuitarComboNumber = save.GuitarComboNumber;
            achievements.PianoComboNumber = save.PianoComboNumber;


            progression.Progress.value = progression.songXP;
            progression.SongText.text = progression.songCount + "/" + progression.songCountMax;
            progression.AlbumName.text = progression.currentAlbum;
            progression.SongName.text = progression.currentSong;
            progression.currencyText.text = currencyManager.curInGameplay + "";

        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}
