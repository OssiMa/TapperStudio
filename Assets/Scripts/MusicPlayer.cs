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
    float preFadeGuitar;
    float preFadePiano;
    float preFadeDrums;

    bool started = false;
    //[HideInInspector]
    public bool songEnd = false;    //Hide this from the inspector once debugging is done
    bool timing = false;
    bool albumEnd;
    bool guitarStarted;
    bool keyboardStarted;
    bool drumsStarted;
    bool menu;
    bool guitarMuted = true;
    bool keyboardMuted = true;
    bool drumsMuted = true;

    public string currentSong;      //Change this to private once debugging is done

    private IEnumerator coroutine;
    private IEnumerator fader;

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

        drums.mute = true;
        guitar.mute = true;
        keyboard.mute = true;
    }

    public void StartTheMusic()     //Piano should work now too, haven't been able to test it yet though
    {
        //A more reliable way to do this than a button event? (?)
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

            //drums.mute = false;

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

    void ChooseSong()
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

        clipGuitar = guitar.clip;
        clipPiano = keyboard.clip;
        clipDrums = drums.clip;
    }

    void Update()
    {
        //if (songEnd == false)
        //{
            if (guitarStarted == true)
            {
                if (menu == false)
                {
                    guitar.mute = false;
                }
                
                if (instrumentBaseGuitar.combo == 1)        //This could be made more fun (?). When starting, the volume would be what is currently told below; otherwise, when combo is 1, volume would go to 0 (?)
                {
                    guitar.volume = (instrumentBaseGuitar.combo / instrumentBaseGuitar.maxCombo) - .1f;
                }
                else if (instrumentBaseGuitar.combo > 1)
                {
                    guitar.volume = instrumentBaseGuitar.combo / instrumentBaseGuitar.maxCombo;
                }
            }

            if (drumsStarted == true)
            {
                if (menu == false)
                {
                    drums.mute = false;
                }
                
                if (instrumentBaseDrums.combo == 1)
                {
                    drums.volume = (instrumentBaseDrums.combo / instrumentBaseDrums.maxCombo) - .1f;
                }
                else if (instrumentBaseDrums.combo > 1)
                {
                    drums.volume = instrumentBaseDrums.combo / instrumentBaseDrums.maxCombo;
                }
            }

            if (keyboardStarted == true)
            {
                if (menu == false)
                {
                    keyboard.mute = false;
                }
                if (instrumentBasePiano.combo == 1)
                {
                    keyboard.volume = (instrumentBasePiano.combo / instrumentBasePiano.maxCombo) - .1f;
                }
                else if (instrumentBasePiano.combo > 1)
                {
                    keyboard.volume = instrumentBasePiano.combo / instrumentBasePiano.maxCombo;
                }
            }
        //}
        else if (songEnd == true)
        {
            coroutine = SoundOut(guitar, keyboard, drums);
            StartCoroutine(coroutine);
            if (!guitar.isPlaying && !keyboard.isPlaying)
            {
                prevVolumeGuitar = guitar.volume;
                prevVolumePiano = keyboard.volume;

                drumsMuted = drums.mute;
                guitarMuted = guitar.mute;
                keyboardMuted = keyboard.mute;

                ChooseSong();

                guitar.volume = prevVolumeGuitar;
                keyboard.volume = prevVolumePiano;

                drums.mute = drumsMuted;
                guitar.mute = guitarMuted;
                keyboard.mute = keyboardMuted;

                coroutine = SoundIn(guitar, keyboard, drums);
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

    public static IEnumerator SoundOut (AudioSource guitar, AudioSource piano, AudioSource drums)
    {
        yield return null;

        drums.loop = false;
        piano.loop = false;
        guitar.loop = false;
    }

    public static IEnumerator SoundIn(AudioSource guitar, AudioSource piano, AudioSource drums)
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

    public void DrumsStarted()
    {
        drumsStarted = true;
    }

    public void GuitarStarted()
    {
        guitarStarted = true;
    }

    public void KeyboardStarted()
    {
        keyboardStarted = true;
    }

    public void MenuVolume()
    {
        if (menu == false)
        {
            preFadeDrums = drums.volume;
            preFadeGuitar = guitar.volume;
            preFadePiano = keyboard.volume;

            fader = FadeOut(guitar, keyboard, drums, 4);
            StartCoroutine(fader);
            menu = true;

            print(guitar.mute);
        }
        else if (menu == true)
        {
            fader = FadeIn(guitar, keyboard, drums, 4, preFadeGuitar, preFadePiano, preFadeDrums);
            StartCoroutine(fader);
            menu = false;
        }
    }

    public static IEnumerator FadeOut(AudioSource guitar, AudioSource piano, AudioSource drums, float fadeTime)
    {
        float startGuitarVolume = guitar.volume;
        float startKeyboardVolume = piano.volume;
        float startDrumsVolume = drums.volume;

        while (guitar.volume > 0 && piano.volume > 0 && drums.volume > 0)
        {
            drums.volume -= startDrumsVolume * Time.deltaTime / fadeTime;
            guitar.volume -= startGuitarVolume * Time.deltaTime / fadeTime;
            piano.volume -= startKeyboardVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        guitar.mute = true;
        piano.mute = true;
        drums.mute = true;

        guitar.volume = startGuitarVolume;
        piano.volume = startKeyboardVolume;
        drums.volume = startDrumsVolume;
    }

    public static IEnumerator FadeIn(AudioSource guitar, AudioSource piano, AudioSource drums, float fadeTime, float preFadeGuitar, float preFadePiano, float preFadeDrums)
    {
        float startGuitarVolume = .2f;
        float startKeyboardVolume = .2f;
        float startDrumsVolume = .2f;

        guitar.volume = 0;
        piano.volume = 0;
        drums.volume = 0;

        guitar.mute = false;
        piano.mute = false;
        drums.mute = false;

        while (guitar.volume > preFadeGuitar && piano.volume > preFadePiano && drums.volume > preFadeDrums)
        {
            drums.volume += startDrumsVolume * Time.deltaTime / fadeTime;
            guitar.volume += startGuitarVolume * Time.deltaTime / fadeTime;
            piano.volume += startKeyboardVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        guitar.volume = preFadeGuitar;
        piano.volume = preFadePiano;
        drums.volume = preFadeDrums;
    }
}
