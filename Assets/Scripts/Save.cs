using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Save {

    public float currency;
    public float premiumCurrency;

    public int albumsCreated = 0;
    public float songsCompleted = 0;
    public float songXp = 0;
    public float songXpMax = 0;

    public string currentAlbum;
    public string currentSong;
    public List<string> usedNames;

    public float drumLevel = 1;
    public float nextDrumLevel = 0;
    public float drumCombo = 1;

    public float guitarLevel = 1;
    public float nextGuitarLevel = 0;
    public float guitarCombo = 1;

    public float pianoLevel = 1;
    public float nextPianoLevel = 0;
    public float pianoCombo = 1;

    public float drumXp = 0;
    public float guitarXp = 0;
    public float pianoXp = 0;

    public float drumStartXp = 0;
    public float guitarStartXp = 0;
    public float pianoStartXp = 0;

    public int SongNumber = 0;
    public int AlbumNumber = 0;
    public int TimeNumber = 0;
    public int CurrencyNumber = 0;
    public int DrumNumber = 0;
    public int GuitarNumber = 0;
    public int PianoNumber = 0;
    public int DrumComboNumber = 0;
    public int GuitarComboNumber = 0;
    public int PianoComboNumber = 0;

}
