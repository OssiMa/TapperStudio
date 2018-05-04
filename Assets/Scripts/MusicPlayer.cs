using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    GameObject currentAlbum;
    GameObject album1;
    GameObject album2;
    GameObject album3;
    GameObject album4;

    InstrumentBase instrumentBaseDrums;
    InstrumentBase instrumentBaseGuitar;
    InstrumentBase instrumentBasePiano;

    AudioSource guitar;
    AudioSource keyboard;
    AudioSource drums;
    SongProgress sp;

    float maxVolume;

    bool started = false;
    bool songEnd;
    bool albumEnd;

    string currentSong;

    void Awake()
    {
        instrumentBaseDrums = GameObject.Find("Drums").GetComponent<InstrumentBase>();
        instrumentBaseGuitar = GameObject.Find("Guitar").GetComponent<InstrumentBase>();
        instrumentBasePiano = GameObject.Find("Piano").GetComponent<InstrumentBase>();
        sp = GameObject.Find("GameManager").GetComponent<SongProgress>();
    }

    public void StartTheMusic()
    {
        //A more reliable way to do this than a button event
        print("do it");
        if (started == false)
        {
            started = true;
            GameObject thisObject = gameObject;
            List<GameObject> children = new List<GameObject>();

            for (int i = 0; i < transform.childCount; i++)
            {
                children.Add(transform.GetChild(i).gameObject);
            }

            foreach (GameObject child in children)
            {
                child.SetActive(true);
            }

            album1 = GameObject.Find("Album1");
            //album2 = GameObject.Find("Album2");
            //album3 = GameObject.Find("Album3");
            //album4 = GameObject.Find("Album4");

            maxVolume = 1;

            SetMusic();
        }
    }

    void SetMusic()
    {
        ChooseAlbum();
        ChooseSong();

        guitar.volume = 0;
        drums.volume = 0;
        keyboard.volume = 0;
    }

    void ChooseAlbum()
    {
        int rundom = Random.Range(1, 3);

        /*if (rundom == 1)
        {
            if (currentAlbum == album1)
            {
                ChooseAlbum();
            }
            else
            {
                currentAlbum = album1;
                albumEnd = false;
            }
        }
        else if (rundom == 2)
        {
            if (currentAlbum == album2)
            {
                ChooseAlbum();
            }
            else
            {
                currentAlbum = album2;
                albumEnd = false;
            }
        }
        if (rundom == 3)
        {
            if (currentAlbum == album3)
            {
                ChooseAlbum();
            }
            else
            {
                currentAlbum = album3;
                albumEnd = false;
            }
        }*/

        currentAlbum = album1;      //Delete this later
    }

    void ChooseSong()
    {
        int rundom = Random.Range(1, 3);

        if (rundom == 1)
        {
            if (currentSong == "song1")
            {
                ChooseSong();
            }
            else
            {
                currentSong = "song1";
                songEnd = false;        //Might not need this at all
            }
        }
        else if (rundom == 2)
        {
            if (currentSong == "song2")
            {
                ChooseSong();
            }
            else
            {
                currentSong = "song2";
                songEnd = false;
            }
        }
        else if (rundom == 3)
        {
            if (currentSong == "song3")
            {
                ChooseSong();
            }
            else
            {
                currentSong = "song3";
                songEnd = false;
            }
        }

        if (currentAlbum == album1)
        {
            if (currentSong == "song1")
            {
                    guitar = album1.transform.GetChild(0).GetComponent<AudioSource>();
                    keyboard = album1.transform.GetChild(1).GetComponent<AudioSource>();
                    drums = album1.GetComponent<AudioSource>();
            }
            else if (currentSong == "song2")
            {
                    guitar = album1.transform.GetChild(2).GetComponent<AudioSource>();
                    keyboard = album1.transform.GetChild(3).GetComponent<AudioSource>();
                    drums = album1.GetComponent<AudioSource>();
            }
            else if (currentSong == "song3")
            {
                    guitar = album1.transform.GetChild(4).GetComponent<AudioSource>();
                    keyboard = album1.transform.GetChild(5).GetComponent<AudioSource>();
                    drums = album1.GetComponent<AudioSource>();
            }
            else if (currentAlbum == album2)
            {
                if (currentSong == "song1")
                {
                        guitar = album2.transform.GetChild(0).GetComponent<AudioSource>();
                        keyboard = album2.transform.GetChild(1).GetComponent<AudioSource>();
                        drums = album2.GetComponent<AudioSource>();
                }
                else if (currentSong == "song2")
                {
                        guitar = album2.transform.GetChild(2).GetComponent<AudioSource>();
                        keyboard = album2.transform.GetChild(3).GetComponent<AudioSource>();
                        drums = album2.GetComponent<AudioSource>();
                }
                else if (currentSong == "song3")
                {
                        guitar = album2.transform.GetChild(4).GetComponent<AudioSource>();
                        keyboard = album2.transform.GetChild(5).GetComponent<AudioSource>();
                        drums = album2.GetComponent<AudioSource>();
                }
            }
            else if (currentAlbum == album3)
            {
                if (currentSong == "song1")
                {
                        guitar = album3.transform.GetChild(0).GetComponent<AudioSource>();
                        keyboard = album3.transform.GetChild(1).GetComponent<AudioSource>();
                        drums = album3.GetComponent<AudioSource>();
                }
                else if (currentSong == "song2")
                {
                        guitar = album3.transform.GetChild(2).GetComponent<AudioSource>();
                        keyboard = album3.transform.GetChild(3).GetComponent<AudioSource>();
                        drums = album3.GetComponent<AudioSource>();
                }
                else if (currentSong == "song3")
                {
                        guitar = album3.transform.GetChild(4).GetComponent<AudioSource>();
                        keyboard = album3.transform.GetChild(5).GetComponent<AudioSource>();
                        drums = album3.GetComponent<AudioSource>();
                }
            }
        }
    }

    void Update()
    {
        if (instrumentBaseGuitar.combo == 1)
        {
            guitar.volume = (instrumentBaseGuitar.combo / instrumentBaseGuitar.maxCombo) - .1f;
        }
        else
        {
            guitar.volume = instrumentBaseGuitar.combo / instrumentBaseGuitar.maxCombo;
        }

        if (instrumentBaseDrums.combo == 1)
        {
            drums.volume = (instrumentBaseDrums.combo / instrumentBaseDrums.maxCombo) -.1f;
        }
        else
        {
            drums.volume = instrumentBaseDrums.combo / instrumentBaseDrums.maxCombo;
        }

        if (instrumentBasePiano.combo == 1)
        {
            keyboard.volume = (instrumentBasePiano.combo / instrumentBasePiano.maxCombo) -.1f;
        }
        else
        {
            keyboard.volume = instrumentBasePiano.combo / instrumentBasePiano.maxCombo;
        }

        if (sp.songXP >= sp.songXPMax)
        {
            songEnd = true;
            ChooseSong();
        }

        if (sp.songCount >= sp.songCountMax)
        {
            albumEnd = true;    //Might not need this at all
            ChooseAlbum();
        }

        //Once the current song is done, fade in to the next one 

        //Once album is done, move to the next (WILL BE DONE ONCE WE GET AT LEAST ONE NEW ALBUM)
    }
}
