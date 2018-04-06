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


    public List<string> AlbumFirstNamesOf;          //A list that contains all the possible name starts for of structure album names. For example: "_Bliss_ of Dreams"
    public List<string> AlbumLastNamesOf;           //A list that contains all the possible name ends for of structure album names. For example: "Bliss of _Dreams_"
    public List<string> AlbumFirstNamesDual;
    public List<string> AlbumLastNamesDual;
    public List<string> UsedNames;

    public string currentAlbum;
    public string currentAlbumFirstOf;
    public string currentAlbumLastOf;
    public string currentAlbumFirstDual;
    public string currentAlbumLastDual;

    public float songXP;
    public float songXPMax = 20;
    public float songCount = 1;
    float songCountMax = 3;
    public float AlbumsCreated;





    // Use this for initialization
    void Start () {
        PossibleAlbums();
        Progress.maxValue = songXPMax;

	}
	
	// Update is called once per frame
	void Update () {
        Progress.value = songXP;
        SongText.text = songCount + "/" + songCountMax;
        AlbumName.text = currentAlbum;
        if (songXP >= songXPMax)
        {
            songCount += 1;
            songXP = 0;
        }
        if (songCount > songCountMax)
        {
            drumBase.exp += 505;
            songCount = 1;
            AlbumsCreated += 1;
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
        AlbumFirstNamesOf.Add("The Intoxication");
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


        NewAlbum();

    }
    public void NewAlbum()
    {
        System.Random nameStructure = new System.Random();
        int whichStructure = nameStructure.Next(1,3);


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

        

        currentAlbum = AlbumName.text.ToString();



    }
 


}
