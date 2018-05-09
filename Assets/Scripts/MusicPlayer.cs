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

    AudioClip clipGuitar;
    AudioClip clipPiano;
    AudioClip clipDrums;

    float maxVolume;

    bool started = false;
    //[HideInInspector]
    public bool songEnd = false;
    bool timing = false;
    bool albumEnd;
    bool guitarStarted;
    bool keyboardStarted;

    string currentSong;

    float time = 1;

    private void Awake()
    {
        instrumentBaseDrums = GameObject.Find("Drums").GetComponent<InstrumentBase>();
        instrumentBaseGuitar = GameObject.Find("Guitar").GetComponent<InstrumentBase>();
        instrumentBasePiano = GameObject.Find("Piano").GetComponent<InstrumentBase>();

        sp = GameObject.Find("SongProgression").GetComponent<SongProgress>();

        album1 = GameObject.Find("Album1");
        //album2 = GameObject.Find("Album2");
        //album3 = GameObject.Find("Album3");
        //album4 = GameObject.Find("Album4");

        ChooseAlbum();
        ChooseSong();

        guitar.mute = true;
        keyboard.mute = true;
    }

    public void StartTheMusic()     //Guitar and Piano don't start the music yet, they should at some point
    {
        //A more reliable way to do this than a button event?
        if (started == false)
        {
            print("NAM");
            started = true;
            GameObject thisObject = gameObject;
            List<GameObject> children = new List<GameObject>();

            for (int i = 0; i < transform.childCount; i++)
            {
                children.Add(transform.GetChild(i).gameObject);
            }

            foreach (GameObject child in children)
            {
                child.GetComponent<AudioSource>().mute = false;
            }

            maxVolume = 1;

            SetMusic();
        }
    }

    void SetMusic()   
    {
        guitar.Play();
        drums.Play();
        keyboard.Play();

        guitar.volume = 0f;
        drums.volume = 0f;
        keyboard.volume = 0f;
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

    void ChooseSong()       //For some reason everything breaks when trying to change the song
    {
        int rundom = Random.Range(1, 3);
        print("GUIH");
        if (rundom == 1)
        {
            if (currentSong == "song1")
            {
                ChooseSong();
            }
            else
            {
                currentSong = "song1";
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
        if (started == true)
        {
            keyboard.Play();
            guitar.Play();
            drums.Play();
        }

        clipGuitar = guitar.clip;
        clipPiano = keyboard.clip;
        clipDrums = drums.clip;
    }

    void Update()
    {
        if (songEnd == false)
        {
            if (guitarStarted == true)
            {
                guitar.mute = false;
                if (instrumentBaseGuitar.combo == 1)        //This could be made more fun (?). When starting, the volume would be what is currently told below; otherwise, when combo is 1, volume would go to 0 (?)
                {
                    guitar.volume = (instrumentBaseGuitar.combo / instrumentBaseGuitar.maxCombo) - .1f;
                    print("why u no work");
                }
                else if (instrumentBaseGuitar.combo > 1)
                {
                    guitar.volume = instrumentBaseGuitar.combo / instrumentBaseGuitar.maxCombo;
                }
            }

            if (instrumentBaseDrums.combo == 1)
            {
                drums.volume = (instrumentBaseDrums.combo / instrumentBaseDrums.maxCombo) - .1f;
            }
            else if (instrumentBaseDrums.combo > 1)
            {
                drums.volume = instrumentBaseDrums.combo / instrumentBaseDrums.maxCombo;
            }

            if (keyboardStarted == true)
            {
                keyboard.mute = false;
                if (instrumentBasePiano.combo == 1)
                {
                    keyboard.volume = (instrumentBasePiano.combo / instrumentBasePiano.maxCombo) - .1f;
                }
                else if (instrumentBasePiano.combo > 1)
                {
                    keyboard.volume = instrumentBasePiano.combo / instrumentBasePiano.maxCombo;
                }
            }
        }
        else if (songEnd == true)
        {
            guitar.Stop();
            keyboard.Stop();
            EndSong();
        }

        if (sp.songCount >= sp.songCountMax)
        {
            albumEnd = true;    //Might not need this at all
            ChooseAlbum();
        }

        //Once album is done, move to the next (WILL BE DONE ONCE WE GET AT LEAST ONE NEW ALBUM) (just fade song volume for x amount of time until 0 and start the new one)
    }

    void EndSong()
    {
        time -= Time.deltaTime;

        if (time >= 0)
        {
            guitar.volume = time;
            keyboard.volume = time;
        }

        if (time <= 0)
        {
            //timing = true;
            if (timing == false)
            {
                timing = true;
                ChooseSong();
            }

            guitar.volume += Time.deltaTime;
            keyboard.volume += Time.deltaTime;

            print(guitar.volume);

            if ((guitar.volume == (instrumentBaseGuitar.combo / instrumentBaseGuitar.maxCombo) && keyboard.volume == (instrumentBasePiano.combo / instrumentBasePiano.maxCombo)) || guitar.volume == 1 && keyboard.volume == 1)
            {
                songEnd = false;
            }
        }
    }

    void AlbumEnd()
    {

    }

    public void GuitarStarted()
    {
        guitarStarted = true;
    }

    public void KeyboardStarted()
    {
        keyboardStarted = true;
    }
}
