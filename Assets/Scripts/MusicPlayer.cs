using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public GameObject currentAlbum;
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

    AudioSource prevGuitar;
    AudioSource prevKeyboard;
    AudioSource prevDrums;

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

    [HideInInspector]
    public bool started = false;
    public bool songEnd = false;    //Hide this from the inspector once debugging is done
    bool timing = false;
    public bool albumEnd;
    bool guitarStarted;
    bool keyboardStarted;
    bool drumsStarted;
    bool menu;
    bool guitarMuted = true;
    bool keyboardMuted = true;
    bool drumsMuted = true;
    public bool allMute;
    bool drumsPreMute;
    bool guitarPreMute;
    bool pianoPreMute;

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
        album2 = GameObject.Find("Album2");
        album3 = GameObject.Find("Album3");
        //album4 = GameObject.Find("Album4");

        ChooseAlbum();
        ChooseSong();

        drums.mute = true;
        guitar.mute = true;
        keyboard.mute = true;
    }

    public void StartTheMusic()
    {
        if (started == false)
        {
            started = true;
            GameObject thisObject = gameObject;
            List<GameObject> children = new List<GameObject>();

            for (int i = 0; i < transform.childCount; i++)
            {
                children.Add(transform.GetChild(i).gameObject);
            }

            if (allMute == false)
            {
                foreach (GameObject child in children)
                {
                    child.GetComponent<AudioSource>().mute = false;
                }
            }

            maxVolume = 1;

            guitar.Play();
            drums.Play();
            keyboard.Play();

            guitar.volume = 0f;
            drums.volume = 0f;
            keyboard.volume = 0f;
        }
    }

    public void ChooseAlbum()
    {
        int rundom = Random.Range(1, 4);

        if (rundom == 1)
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
        }
    }

    public void ChooseSong()
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
            }
            else if (currentSong == "song2")
            {
                guitar = album1.transform.GetChild(2).GetComponent<AudioSource>();
                keyboard = album1.transform.GetChild(3).GetComponent<AudioSource>();
            }
            else if (currentSong == "song3")
            {
                guitar = album1.transform.GetChild(4).GetComponent<AudioSource>();
                keyboard = album1.transform.GetChild(5).GetComponent<AudioSource>();
            }
            drums = album1.GetComponent<AudioSource>();
            drums.loop = true;
        }
        else if (currentAlbum == album2)
        {
            if (currentSong == "song1")
            {
                guitar = album2.transform.GetChild(0).GetComponent<AudioSource>();
                keyboard = album2.transform.GetChild(1).GetComponent<AudioSource>();
            }
            else if (currentSong == "song2")
            {
                guitar = album2.transform.GetChild(2).GetComponent<AudioSource>();
                keyboard = album2.transform.GetChild(3).GetComponent<AudioSource>();
            }
            else if (currentSong == "song3")
            {
                guitar = album2.transform.GetChild(4).GetComponent<AudioSource>();
                keyboard = album2.transform.GetChild(5).GetComponent<AudioSource>();
            }
            drums = album2.GetComponent<AudioSource>();
            drums.loop = true;
        }
        else if (currentAlbum == album3)
        {
            if (currentSong == "song1")
            {
                guitar = album3.transform.GetChild(0).GetComponent<AudioSource>();
                keyboard = album3.transform.GetChild(1).GetComponent<AudioSource>();
            }
            else if (currentSong == "song2")
            {
                guitar = album3.transform.GetChild(2).GetComponent<AudioSource>();
                keyboard = album3.transform.GetChild(3).GetComponent<AudioSource>();
            }
            else if (currentSong == "song3")
            {
                guitar = album3.transform.GetChild(4).GetComponent<AudioSource>();
                keyboard = album3.transform.GetChild(5).GetComponent<AudioSource>();
            }
            drums = album3.GetComponent<AudioSource>();
            drums.loop = true;
        }
    }

    void Update()
    {
        if (allMute == false)
        {
            if (guitarStarted == true)
            {
                if (instrumentBaseGuitar.combo == 1)
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
                if (instrumentBaseDrums.combo == 1)
                {
                    drums.volume = (instrumentBaseDrums.combo / instrumentBaseDrums.maxCombo) - .1f;
                }
                else if (instrumentBaseDrums.combo > 1)
                {
                    drums.volume = instrumentBaseDrums.combo / instrumentBaseDrums.maxCombo;
                }
                if (sp.endMenu == false)
                {
                    drums.loop = true;
                }
                else
                {
                    drums.loop = false;
                }
            }

            if (keyboardStarted == true)
            {
                if (instrumentBasePiano.combo == 1)
                {
                    keyboard.volume = (instrumentBasePiano.combo / instrumentBasePiano.maxCombo);
                }
                else if (instrumentBasePiano.combo > 1)
                {
                    keyboard.volume = (instrumentBasePiano.combo / instrumentBasePiano.maxCombo) + .1f;
                }
            }

            if (songEnd == true)
            {
                if (sp.endMenu == false)
                {
                    SongEnd();
                }
            }

            if (albumEnd == true)
            {
                //lower all volumes with Time.deltaTime / 5 or something
            }
        }
        else if (allMute == true)
        {
            guitar.mute = true;
            keyboard.mute = true;
            drums.mute = true;
        }

        if (sp.menu == true)
        {
            if (guitar.mute != true)
            {
                guitar.mute = true;
            }
            if (drums.mute != true)
            {
                drums.mute = true;
            }
            if (keyboard.mute != true)
            {
                keyboard.mute = true;
            }
        }
    }
    
    public void SongEnd()
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
                //drums.loop = true;
            }
        }
    }

    public void AlbumEnd()
    {
        drums.loop = false;
        guitar.loop = false;
        keyboard.loop = false;
    }

    public void ForceAlbumEnd()
    {
        drums.mute = true;
        guitar.mute = true;
        keyboard.mute = true;

        drums.Stop();
        guitar.Stop();
        keyboard.Stop();
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

    public void DrumsStarted()
    {
        drumsStarted = true;
    }

    public void GuitarStarted()
    {
        guitarStarted = true;
        guitar.mute = false;
    }

    public void KeyboardStarted()
    {
        keyboardStarted = true;
        keyboard.mute = false;
    }

    public void MenuVolume()
    {
        if (albumEnd == false)
        {
            if (menu == false)
            {
                preFadeDrums = drums.volume;
                preFadeGuitar = guitar.volume;
                preFadePiano = keyboard.volume;

                drumsPreMute = drums.mute;
                guitarPreMute = guitar.mute;
                pianoPreMute = keyboard.mute;

                //fader = FadeOut(guitar, keyboard, drums, 100);
                //StartCoroutine(fader);
                FadeOut(guitar, keyboard, drums);
                menu = true;
            }
            else if (menu == true)
            {
                //fader = FadeIn(guitar, keyboard, drums, 4, preFadeGuitar, preFadePiano, preFadeDrums);
                //StartCoroutine(fader);
                FadeIn(guitar, keyboard, drums, preFadeGuitar, preFadePiano, preFadeDrums);
                menu = false;
            }
        }
    }

    /*public static IEnumerator FadeOut(AudioSource guitar, AudioSource piano, AudioSource drums, float fadeTime)
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
    }*/

    public void FadeOut(AudioSource guitar, AudioSource piano, AudioSource drums)
    {
        float startGuitarVolume = guitar.volume;
        float startKeyboardVolume = piano.volume;
        float startDrumsVolume = drums.volume;

        guitar.mute = true;
        piano.mute = true;
        drums.mute = true;

        guitar.volume = startGuitarVolume;
        piano.volume = startKeyboardVolume;
        drums.volume = startDrumsVolume;
    }

    public void FadeIn(AudioSource guitar, AudioSource piano, AudioSource drums, float preFadeGuitar, float preFadePiano, float preFadeDrums)
    {
        guitar.volume = 0;
        piano.volume = 0;
        drums.volume = 0;

        guitar.mute = guitarPreMute;
        piano.mute = pianoPreMute;
        drums.mute = drumsPreMute;

        guitar.volume = preFadeGuitar;
        piano.volume = preFadePiano;
        drums.volume = preFadeDrums;
    }

    /*public static IEnumerator FadeIn(AudioSource guitar, AudioSource piano, AudioSource drums, float fadeTime, float preFadeGuitar, float preFadePiano, float preFadeDrums)
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
    }*/

    public void NewAlbumPlay()
    {
        guitar.volume = 0;
        keyboard.volume = 0;
        drums.volume = 0;

        drums.mute = false;
        guitar.mute = false;
        keyboard.mute = false;

        drums.loop = true;
        guitar.loop = true;
        keyboard.loop = true;

        guitarStarted = false;
        keyboardStarted = false;
        drumsStarted = false;

        guitar.Play();
        drums.Play();
        keyboard.Play();

        instrumentBaseDrums.combo = 1;
        instrumentBaseGuitar.combo = 1;
        instrumentBasePiano.combo = 1;

        instrumentBaseDrums.comboFade = instrumentBaseDrums.comboFadeMax;
        instrumentBaseGuitar.comboFade = instrumentBaseGuitar.comboFadeMax;
        instrumentBasePiano.comboFade = instrumentBasePiano.comboFadeMax;

        instrumentBaseDrums.UpdateComboCounter();
        instrumentBaseGuitar.UpdateComboCounter();
        instrumentBasePiano.UpdateComboCounter();

        OtherSongCheck();
    }

    public void OtherSongCheck()
    {
        if (currentAlbum == album1)
        {
            List<GameObject> children = new List<GameObject>();

            for (int i = 0; i < album2.transform.childCount; i++)
            {
                children.Add(album2.transform.GetChild(i).gameObject);
            }

            foreach (GameObject child in children)
            {
                child.GetComponent<AudioSource>().mute = true;
            }
        }
        else if (currentAlbum == album2)
        {
            List<GameObject> children = new List<GameObject>();

            for (int i = 0; i < album1.transform.childCount; i++)
            {
                children.Add(album1.transform.GetChild(i).gameObject);
            }

            foreach (GameObject child in children)
            {
                child.GetComponent<AudioSource>().mute = true;
            }
        }
    }

    public void MuteControl()
    {
        if (allMute == false)
        {
            allMute = true;
        }
        else if (allMute == true)
        {
            allMute = false;
        }
    }
}
