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
    float prevVolumeGuitar;
    float prevVolumePiano;
    float prevVolumeDrums;

    bool started = false;
    //[HideInInspector]
    public bool songEnd = false;    //Hide this from the inspector once debugging is done
    bool timing = false;
    bool albumEnd;
    bool guitarStarted;
    bool keyboardStarted;

    public string currentSong;      //Change this to private once debugging is done

    private IEnumerator coroutine;

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
        int rundom = Random.Range(1, 4);

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
        /*if (started == true)
        {
            keyboard.Play();
            guitar.Play();
            drums.Play();
        }*/

        clipGuitar = guitar.clip;
        clipPiano = keyboard.clip;
        clipDrums = drums.clip;
    }

    void Update()       //Needs something to make sure volume is changed
    {
        if (songEnd == false)
        {
            if (guitarStarted == true)
            {
                guitar.mute = false;
                if (instrumentBaseGuitar.combo == 1)        //This could be made more fun (?). When starting, the volume would be what is currently told below; otherwise, when combo is 1, volume would go to 0 (?)
                {
                    guitar.volume = (instrumentBaseGuitar.combo / instrumentBaseGuitar.maxCombo) - .1f;
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
            coroutine = FadeOut(guitar, keyboard, drums);
            StartCoroutine(coroutine);
            if (!guitar.isPlaying && !keyboard.isPlaying)
            {
                prevVolumeGuitar = guitar.volume;
                prevVolumePiano = keyboard.volume;

                ChooseSong();

                guitar.volume = prevVolumeGuitar;
                keyboard.volume = prevVolumePiano;

                coroutine = FadeIn(guitar, keyboard, drums);
                StartCoroutine(coroutine);

                if (guitar.loop == true && keyboard.loop == true)
                {
                    songEnd = false;
                }
            }
        }

        if (sp.songCount >= sp.songCountMax)    
        {
            albumEnd = true;    //Might not need this at all
            ChooseAlbum();
        }

        //Once album is done, move to the next (WILL BE DONE ONCE WE GET AT LEAST ONE NEW ALBUM) (just fade song volume for x amount of time until 0 and start the new one)
    }

    public static IEnumerator FadeOut (AudioSource guitar, AudioSource piano, AudioSource drums)
    {
        yield return null;

        drums.loop = false;
        piano.loop = false;
        guitar.loop = false;
    }

    public static IEnumerator FadeIn(AudioSource guitar, AudioSource piano, AudioSource drums)
    {
        drums.loop = true;
        guitar.loop = true;
        piano.loop = true;

        drums.Play();
        guitar.Play();
        piano.Play();

        yield return null;
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
