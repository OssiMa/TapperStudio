using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Save {

    public int currency;
    public int premiumCurrency;
    public int curInGamePlay;

    public int albumsCreated;
    public float songsCompleted;
    public float songXp;
    public float songXpMax;
    public float songCount;
    public float songCountMax;

    public string currentAlbum;
    public string currentSong;
    public List<string> usedNames;


    public float drumLevel;
    public float nextDrumLevel;
    public float drumCombo;

    public float guitarLevel;
    public float nextGuitarLevel;
    public float guitarCombo;

    public float pianoLevel;
    public float nextPianoLevel;
    public float pianoCombo;

    public float drumXp;
    public float guitarXp;
    public float pianoXp;

    public float drumStartXp;
    public float guitarStartXp;
    public float pianoStartXp;

    public int SongNumber;
    public int AlbumNumber;
    public int TimeNumber;
    public int CurrencyNumber;
    public int DrumNumber;
    public int GuitarNumber;
    public int PianoNumber;
    public int DrumComboNumber;
    public int GuitarComboNumber;
    public int PianoComboNumber;

}
