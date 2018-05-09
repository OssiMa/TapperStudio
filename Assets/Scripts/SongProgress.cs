using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;




public class SongProgress : MonoBehaviour {

    public InstrumentBase drumBase;
    public InstrumentBase guitarBase;
    public InstrumentBase pianoBase;
    InstrumentBase activeBase;

    GameObject activeInstrument;
    [HideInInspector]
    public GameObject[] instruments;

    public List<GameObject> inactives;

    public Slider Progress;
    public Text SongText;
    public Text AlbumName;
    public Text SongName;
    public Text currencyText;


    public List<string> AlbumFirstNamesOf;          //A list that contains all To possible name starts To of structure album names. To example: "_Bliss_ of Dreams"
    public List<string> AlbumLastNamesOf;           //A list that contains all To possible name ends To of structure album names. To example: "Bliss of _Dreams_"
    public List<string> AlbumFirstNamesDual;
    public List<string> AlbumLastNamesDual;
    public List<string> AlbumFirstNamesTo;
    public List<string> AlbumLastNamesTo;
    public List<string> AlbumWholeNames;
    public List<string> UsedNames;

    public string currentAlbum;
    string currentAlbumFirstOf;
    string currentAlbumLastOf;
    string currentAlbumFirstDual;
    string currentAlbumLastDual;
    string currentAlbumFirstTo;
    string currentAlbumLastTo;
    string albumWholeName;    

    public string currentSong;
    string currentSongFirstOf;
    string currentSongLastOf;
    string currentSongFirstDual;
    string currentSongLastDual;
    string currentSongFirstTo;
    string currentSongLastTo;

    public float songXP;
    [HideInInspector]
    public float songXPMax = 20;
    public float songCount = 1;
    public float currency = 0;
    [HideInInspector]
    public float songCountMax = 3;
    public float AlbumsCreated;

    MusicPlayer mp;




    // Use this To initialization
    void Start () {
        PossibleAlbums();
        Progress.maxValue = songXPMax;
        instruments = GameObject.FindGameObjectsWithTag("Instrument").OrderBy(instruments => instruments.name).ToArray();
        foreach(GameObject ins in instruments)
        {
            ins.SetActive(false);
        }
        instruments[0].SetActive(true);
        CheckActive();

        mp = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        Progress.value = songXP;
        SongText.text = songCount + "/" + songCountMax;
        AlbumName.text = currentAlbum;
        SongName.text = currentSong;
        currencyText.text = currency + "£";
        PassiveGene();

        if (songXP >= songXPMax)
        {
            mp.songEnd = true;
            songCount += 1;
            songXP = 0;
            UsedNames.Add(currentSong);

            if (UsedNames.Count > 50)
            {
                UsedNames.RemoveAt(1);
            }
            currency += 10;
            NewSong();
        }
        if (songCount > songCountMax)
        {
            activeBase.exp += activeBase.level*10;                  //XP given to the instrument, needs scaling value
            songCount = 1;
            AlbumsCreated += 1;
            UsedNames.Add(currentAlbum);
            NewItemGenerator.instance.NewItem(1);

            if(UsedNames.Count > 20)
            {
                UsedNames.RemoveAt(1);
            }
            currency += 40;
            NewAlbum();

        }
	}

    //Grants XP to songs
    public void GainXP()
    {
        songXP += 0.1f;
    }

    void PassiveGene()
    {
        float geneLvl = 0;
        float geneCombo = 0;
        float geneBoost = 0;
        foreach (GameObject ins in inactives)
        {
            geneLvl += ins.GetComponent<InstrumentBase>().level;
            geneCombo += ins.GetComponent<InstrumentBase>().combo;
            geneBoost += ins.GetComponent<InstrumentBase>().xpBoost;
            if (ins.GetComponent<InstrumentBase>().comboFade > 0 && ins.GetComponent<InstrumentBase>().combo > 1)
            {
                ins.GetComponent<InstrumentBase>().comboFade -= 1;
                ins.GetComponent<InstrumentBase>().fadeSlider.value -= 1;
            }
            else if (ins.GetComponent<InstrumentBase>().comboFade <= 0)
            {
                ins.GetComponent<InstrumentBase>().ComboFading();
                ins.GetComponent<InstrumentBase>().fadeSlider.value = 500;
            }
        }
        songXP += 0.01f + (geneLvl * geneCombo + geneBoost) * 0.0005f;              //WIP, feel free to play with and test for optimal values
    }

    public void CheckActive()
    {
        inactives.Clear();
        foreach (GameObject ins in instruments)
        {
            if (ins.activeInHierarchy)
            {
                activeBase = ins.GetComponent<InstrumentBase>();
            }
            else
            {
                inactives.Add(ins);
            }
        }
    }

    //Adds possible names to albums with different namestructures
    public void PossibleAlbums()
    {
        AlbumFirstNamesOf.Add("Chaos");
        AlbumFirstNamesOf.Add("Hold");
        AlbumFirstNamesOf.Add("Highest");
        AlbumFirstNamesOf.Add("Genocide");
        AlbumFirstNamesOf.Add("Ascencion");
        AlbumFirstNamesOf.Add("Melody");
        AlbumFirstNamesOf.Add("Sound");
        AlbumFirstNamesOf.Add("Cycle");
        AlbumFirstNamesOf.Add("Bliss");
        AlbumFirstNamesOf.Add("Muse");
        AlbumFirstNamesOf.Add("Sorrow");
        AlbumFirstNamesOf.Add("Killer");
        AlbumFirstNamesOf.Add("Consumer");
        AlbumFirstNamesOf.Add("Rules");
        AlbumFirstNamesOf.Add("Beauty");
        AlbumFirstNamesOf.Add("Signs");
        AlbumFirstNamesOf.Add("Call");
        AlbumFirstNamesOf.Add("Fall");
        AlbumFirstNamesOf.Add("God");
        AlbumFirstNamesOf.Add("Toll");
        AlbumFirstNamesOf.Add("Story");
        AlbumFirstNamesOf.Add("Entropy");
        AlbumFirstNamesOf.Add("Hunter");


        AlbumLastNamesOf.Add("Love");
        AlbumLastNamesOf.Add("The Mighty");
        AlbumLastNamesOf.Add("Life");
        AlbumLastNamesOf.Add("Death");
        AlbumLastNamesOf.Add("The Brave");
        AlbumLastNamesOf.Add("Summer");
        AlbumLastNamesOf.Add("Nature");
        AlbumLastNamesOf.Add("Music");
        AlbumLastNamesOf.Add("Dreams");
        AlbumLastNamesOf.Add("Souls");
        AlbumLastNamesOf.Add("Men");
        AlbumLastNamesOf.Add("Gods");
        AlbumLastNamesOf.Add("the Storm");
        AlbumLastNamesOf.Add("War");
        AlbumLastNamesOf.Add("Tradition");
        AlbumLastNamesOf.Add("Time");


        AlbumFirstNamesDual.Add("Winter ");
        AlbumFirstNamesDual.Add("Summer ");
        AlbumFirstNamesDual.Add("Spring ");
        AlbumFirstNamesDual.Add("Autumn ");
        AlbumFirstNamesDual.Add("Beautiful ");
        AlbumFirstNamesDual.Add("Glorious ");
        AlbumFirstNamesDual.Add("Mad ");
        AlbumFirstNamesDual.Add("Odd ");
        AlbumFirstNamesDual.Add("Without ");
        AlbumFirstNamesDual.Add("Warm ");
        AlbumFirstNamesDual.Add("Sad ");
        AlbumFirstNamesDual.Add("Slave's ");
        AlbumFirstNamesDual.Add("Your ");
        AlbumFirstNamesDual.Add("My ");
        AlbumFirstNamesDual.Add("Lonely ");
        AlbumFirstNamesDual.Add("Final ");
        AlbumFirstNamesDual.Add("Devil's ");
        AlbumFirstNamesDual.Add("Artificial ");
        AlbumFirstNamesDual.Add("First ");
        AlbumFirstNamesDual.Add("Burning ");


        AlbumLastNamesDual.Add("Days");
        AlbumLastNamesDual.Add("Evolution");
        AlbumLastNamesDual.Add("Life");
        AlbumLastNamesDual.Add("Voyage");
        AlbumLastNamesDual.Add("Freedom");
        AlbumLastNamesDual.Add("Jazz");
        AlbumLastNamesDual.Add("Nature");
        AlbumLastNamesDual.Add("Hymn");
        AlbumLastNamesDual.Add("Dreams");
        AlbumLastNamesDual.Add("Sound");
        AlbumLastNamesDual.Add("Conclusion");
        AlbumLastNamesDual.Add("Light");
        AlbumLastNamesDual.Add("Gravity");
        AlbumLastNamesDual.Add("Roses");
        AlbumLastNamesDual.Add("Flame");
        AlbumLastNamesDual.Add("Mercy");
        AlbumLastNamesDual.Add("Tears");
        AlbumLastNamesDual.Add("Alchemist");
        AlbumLastNamesDual.Add("Love");
        AlbumLastNamesDual.Add("Pain");
        AlbumLastNamesDual.Add("Angel");
        AlbumLastNamesDual.Add("Blues");
        AlbumLastNamesDual.Add("Perseverance");


        AlbumFirstNamesTo.Add("Ode");
        AlbumFirstNamesTo.Add("A Toast");
        AlbumFirstNamesTo.Add("Road");
        AlbumFirstNamesTo.Add("Path");
        AlbumFirstNamesTo.Add("Back");
        AlbumFirstNamesTo.Add("Right");
        AlbumFirstNamesTo.Add("Ashes");


        AlbumLastNamesTo.Add("Joy");
        AlbumLastNamesTo.Add("Love");
        AlbumLastNamesTo.Add("Light");
        AlbumLastNamesTo.Add("You");
        AlbumLastNamesTo.Add("Rome");
        AlbumLastNamesTo.Add("Ashes");


        AlbumWholeNames.Add("Afterlife");
        AlbumWholeNames.Add("Reborn");
        AlbumWholeNames.Add("Immortals");
        AlbumWholeNames.Add("Calamity");
        AlbumWholeNames.Add("Hummingbird");
        AlbumWholeNames.Add("Thunderclouds");
        AlbumWholeNames.Add("The Lies");
        AlbumWholeNames.Add("Instinct");
        AlbumWholeNames.Add("Burialground");
        AlbumWholeNames.Add("Positive");
        AlbumWholeNames.Add("Fly");
        AlbumWholeNames.Add("FYI");
        AlbumWholeNames.Add("Storyteller");
        AlbumWholeNames.Add("Altruistic");
        AlbumWholeNames.Add("Eager");
        AlbumWholeNames.Add("Spaghetti");
        AlbumWholeNames.Add("Fanatic");
        AlbumWholeNames.Add("Letting go");
        AlbumWholeNames.Add("Cyberbeats");


        currentAlbum = "SpaghettiSolution";
        UsedNames.Add(currentAlbum);
        currentSong = "OdeToSpaghetti";
        UsedNames.Add(currentSong);

        NewAlbum();
        NewSong();


    }

    //Randomizes the namestructure and name of a new album
    public void NewAlbum()
    {


        while (UsedNames.Contains(currentAlbum))
        {
            System.Random nameStructure = new System.Random();
            int whichStructure = nameStructure.Next(1, 5);

            if (whichStructure == 1)
            {
                System.Random firstNamePickerOf = new System.Random();
                int fOf = firstNamePickerOf.Next(AlbumFirstNamesOf.Count);
                currentAlbumFirstOf = AlbumFirstNamesOf[fOf];

                System.Random lastNamePickerOf = new System.Random();
                int lOf = lastNamePickerOf.Next(AlbumLastNamesOf.Count);
                currentAlbumLastOf = AlbumLastNamesOf[lOf];

                AlbumName.text = currentAlbumFirstOf + " of " + currentAlbumLastOf;
            }

            if (whichStructure == 2)
            {
                System.Random firstNamePicker = new System.Random();
                int fDual = firstNamePicker.Next(AlbumFirstNamesDual.Count);
                currentAlbumFirstDual = AlbumFirstNamesDual[fDual];

                System.Random lastNamePicker = new System.Random();
                int lDual = lastNamePicker.Next(AlbumLastNamesDual.Count);
                currentAlbumLastDual = AlbumLastNamesDual[lDual];

                AlbumName.text = currentAlbumFirstDual + currentAlbumLastDual;
            }

            if (whichStructure == 3)
            {
                System.Random namePicker = new System.Random();
                int name = namePicker.Next(AlbumWholeNames.Count);
                albumWholeName = AlbumWholeNames[name];

                AlbumName.text = albumWholeName;
            }

            if (whichStructure == 4)
            {
                System.Random firstNamePicker = new System.Random();
                int fTo = firstNamePicker.Next(AlbumFirstNamesTo.Count);
                currentAlbumFirstTo = AlbumFirstNamesTo[fTo];

                System.Random lastNamePicker = new System.Random();
                int lTo = lastNamePicker.Next(AlbumLastNamesTo.Count);
                currentAlbumLastTo = AlbumLastNamesTo[lTo];

                AlbumName.text = currentAlbumFirstTo + " to " + currentAlbumLastTo;
            }

            currentAlbum = AlbumName.text.ToString();
        }


    }

    //Randomizes the namestructure and name of a new song
    public void NewSong()
    {


        while (UsedNames.Contains(currentSong))
        {
            System.Random nameStructure = new System.Random();
            int whichStructure = nameStructure.Next(1, 5);

            if (whichStructure == 3)
            {
                System.Random firstNamePickerOf = new System.Random();
                int fOf = firstNamePickerOf.Next(AlbumFirstNamesOf.Count);
                currentSongFirstOf = AlbumFirstNamesOf[fOf];

                System.Random lastNamePickerOf = new System.Random();
                int lOf = lastNamePickerOf.Next(AlbumLastNamesOf.Count);
                currentSongLastOf = AlbumLastNamesOf[lOf];

                SongName.text = currentSongFirstOf + " of " + currentSongLastOf;
            }

            if (whichStructure == 4)
            {
                System.Random firstNamePicker = new System.Random();
                int fDual = firstNamePicker.Next(AlbumFirstNamesDual.Count);
                currentSongFirstDual = AlbumFirstNamesDual[fDual];

                System.Random lastNamePicker = new System.Random();
                int lDual = lastNamePicker.Next(AlbumLastNamesDual.Count);
                currentSongLastDual = AlbumLastNamesDual[lDual];

                SongName.text = currentSongFirstDual + currentSongLastDual;
            }

            if (whichStructure == 2)
            {
                System.Random namePicker = new System.Random();
                int name = namePicker.Next(AlbumWholeNames.Count);
                albumWholeName = AlbumWholeNames[name];
                SongName.text = albumWholeName;

            }
            if (whichStructure == 1)
            {
                System.Random firstNamePicker = new System.Random();
                int fTo = firstNamePicker.Next(AlbumFirstNamesTo.Count);
                currentSongFirstTo = AlbumFirstNamesTo[fTo];

                System.Random lastNamePicker = new System.Random();
                int lTo = lastNamePicker.Next(AlbumLastNamesTo.Count);
                currentSongLastTo = AlbumLastNamesTo[lTo];

                SongName.text = currentSongFirstTo + " To " + currentSongLastTo;
            }

            currentSong = SongName.text.ToString();
        }

    }



}
