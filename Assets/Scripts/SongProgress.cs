using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class SongProgress : MonoBehaviour {

    public InstrumentBase drumBase;

    public Slider Progress;
    public Text SongText;
    public Text AlbumName;


    public List<string> AlbumFirstNamesOf;
    public List<string> AlbumLastNamesOf;
    public List<string> UsedNames;

    public string currentAlbum;
    public string currentAlbumFirstOf;
    public string currentAlbumLastOf;

    float songXP;
    float songXPMax = 20;
    float songCount = 1;
    float songCountMax = 3;





    // Use this for initialization
    void Start () {
        PossibleAlbums();
        Progress.maxValue = songXPMax;

	}
	
	// Update is called once per frame
	void Update () {
        Progress.value = songXP;
        SongText.text = songCount + "/" + songCountMax;

        if (songXP >= songXPMax)
        {
            songCount += 1;
            songXP = 0;
        }
        if (songCount > songCountMax)
        {
            drumBase.exp += 505;
            songCount = 1;
            NewAlbum();
        }
	}

    public void GainXP()
    {
        songXP += 1;
    }

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
        AlbumFirstNamesOf.Add("Sadness");
        AlbumFirstNamesOf.Add("Killer");
        AlbumFirstNamesOf.Add("Harbringer");
        AlbumFirstNamesOf.Add("Consumer");
        AlbumFirstNamesOf.Add("The intoxication");
        AlbumFirstNamesOf.Add("Rules");

        AlbumLastNamesOf.Add("Love");
        AlbumLastNamesOf.Add("the Mighty");
        AlbumLastNamesOf.Add("Life");
        AlbumLastNamesOf.Add("Death");
        AlbumLastNamesOf.Add("the Brave");
        AlbumLastNamesOf.Add("Summer");
        AlbumLastNamesOf.Add("Nature");
        AlbumLastNamesOf.Add("Music");
        AlbumLastNamesOf.Add("Dreams");
        AlbumLastNamesOf.Add("Souls");
        AlbumLastNamesOf.Add("Humans");
        AlbumLastNamesOf.Add("Puppies");
        AlbumLastNamesOf.Add("Kittens");
        AlbumLastNamesOf.Add("Bunnies");




        NewAlbum();

    }
    public void NewAlbum()
    {
        System.Random firstNamePicker = new System.Random();
        int f = firstNamePicker.Next(AlbumFirstNamesOf.Count);
        currentAlbumFirstOf = AlbumFirstNamesOf[f];

        System.Random lastNamePicker = new System.Random();
        int l = lastNamePicker.Next(AlbumLastNamesOf.Count);
        currentAlbumLastOf = AlbumLastNamesOf[l];

        AlbumName.text = currentAlbumFirstOf + " of " + currentAlbumLastOf;
        currentAlbum = AlbumName.text.ToString();
        Debug.Log(currentAlbum);
        Debug.Log(currentAlbumFirstOf);
        Debug.Log(currentAlbumLastOf);

    }
 


}
