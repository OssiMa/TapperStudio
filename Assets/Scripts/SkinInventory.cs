using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinInventory : MonoBehaviour {

    public List<Skin> skins = new List<Skin>();

    Sprite drumsIcon1, drumsIcon2, drumsIcon3, drumsIcon4, drumsIcon5, drumsIcon6;
    Sprite drumsIconSpecial1, drumsIconSpecial2, drumsIconSpecial3, drumsIconSpecial4, drumsIconSpecial5, drumsIconSpecial6;

    Sprite guitarIcon;
    Sprite guitarIconSpecial1, guitarIconSpecial2, guitarIconSpecial3, guitarIconSpecial4, guitarIconSpecial5;

    Sprite pianoIcon1, pianoIcon2, pianoIcon3;

    Sprite pianoIconSpecial1, pianoIconSpecial2, pianoIconSpecial3;

    InstrumentBase instrumentBaseDrums;
    InstrumentBase instrumentBaseGuitar;
    InstrumentBase instrumentBasePiano;

    public delegate void OnSkinsChange();
    public OnSkinsChange onSkinsChangedCallback;

    void Awake()
    {
        drumsIcon1 = GameObject.Find("drum_buttonImage_body").GetComponent<Image>().sprite;
        drumsIcon2 = GameObject.Find("drum_buttonImage (2)").GetComponent<Image>().sprite;
        drumsIcon3 = GameObject.Find("drum_buttonImage (4)").GetComponent<Image>().sprite;
        drumsIcon4 = GameObject.Find("drum_buttonImage (5)").GetComponent<Image>().sprite;
        drumsIcon5 = GameObject.Find("drum_buttonImage (3)").GetComponent<Image>().sprite;
        drumsIcon6 = GameObject.Find("drum_buttonImage (1)").GetComponent<Image>().sprite;

        //Special drum icons
        /*
        drumsIconSpecial1 = GameObject.Find("drum_buttonImage_body_special").GetComponent<Image>().sprite;
        drumsIconSpecial2 = GameObject.Find("drum_buttonImage (2)_special").GetComponent<Image>().sprite;
        drumsIconSpecial3 = GameObject.Find("drum_buttonImage (4)_special").GetComponent<Image>().sprite;
        drumsIconSpecial4 = GameObject.Find("drum_buttonImage (5)_special").GetComponent<Image>().sprite;
        drumsIconSpecial5 = GameObject.Find("drum_buttonImage (3)_special").GetComponent<Image>().sprite;
        drumsIconSpecial6 = GameObject.Find("drum_buttonImage (1)_special").GetComponent<Image>().sprite;
        */

        //Standard guitar icons
        /*
        guitarIcon1 = GameObject.Find("guitar_buttonImage_kakka_normal").GetComponent<Image>().sprite;
        guitarIcon2 = GameObject.Find("guitar_buttonImage_body (1)_normal").GetComponent<Image>().sprite;
        guitarIcon3 = GameObject.Find("guitar_buttonImage_neck (1)_normal").GetComponent<Image>().sprite;
        guitarIcon4 = GameObject.Find("guitar_buttonImage_head (1)_normal").GetComponent<Image>().sprite;
        guitarIcon5 = GameObject.Find("guitar_buttonImage (2)_normal").GetComponent<Image>().sprite; 
        */

        guitarIconSpecial1 = GameObject.Find("guitar_buttonImage_kakka").GetComponent<Image>().sprite;
        guitarIconSpecial2 = GameObject.Find("guitar_buttonImage_body (1)").GetComponent<Image>().sprite;
        guitarIconSpecial3 = GameObject.Find("guitar_buttonImage_neck (1)").GetComponent<Image>().sprite;
        guitarIconSpecial4 = GameObject.Find("guitar_buttonImage_head (1)").GetComponent<Image>().sprite;
        guitarIconSpecial5 = GameObject.Find("guitar_buttonImage (2)").GetComponent<Image>().sprite;

        pianoIcon1 = GameObject.Find("keyboard_buttonImage_head").GetComponent<Image>().sprite;
        pianoIcon2 = GameObject.Find("keyboard_buttonImage_bottom").GetComponent<Image>().sprite;
        pianoIcon3 = GameObject.Find("keyboard_buttonImage (2)").GetComponent<Image>().sprite;

        //Special piano icons
        /*
        pianoIconSpecial1 = GameObject.Find("keyboard_buttonImage_head_special").GetComponent<Image>().sprite;
        pianoIconSpecial2 = GameObject.Find("keyboard_buttonImage_bottom_special").GetComponent<Image>().sprite;
        pianoIconSpecial3 = GameObject.Find("keyboard_buttonImage (2)_special").GetComponent<Image>().sprite; 
        */

        instrumentBaseDrums = GameObject.Find("Drums").GetComponent<InstrumentBase>();
        instrumentBaseGuitar = GameObject.Find("Guitar").GetComponent<InstrumentBase>();
        instrumentBasePiano = GameObject.Find("Piano").GetComponent<InstrumentBase>();

        NewSkin();
    }

    public void NewSkin()
    {
        IconChooser();
        VintageCheck();
    }

    void IconChooser()
    {
        foreach (Skin skin in skins)
        {
            if (skin.instrument == 1)
            {
                if (skin.trinketType == 0)
                {
                    skin.specialIcon1 = drumsIcon1;
                    skin.specialIcon2 = drumsIcon2;
                    skin.specialIcon3 = drumsIcon3;
                    skin.specialIcon4 = drumsIcon4;
                    skin.specialIcon5 = drumsIcon5;
                    skin.specialIcon6 = drumsIcon6;
                }
                else
                {
                    skin.specialIcon1 = drumsIconSpecial1;
                    skin.specialIcon2 = drumsIconSpecial2;
                    skin.specialIcon3 = drumsIconSpecial3;
                    skin.specialIcon4 = drumsIconSpecial4;
                    skin.specialIcon5 = drumsIconSpecial5;
                    skin.specialIcon6 = drumsIconSpecial6;
                }
            }
            else if (skin.instrument == 2)
            {
                if (skin.trinketType == 0)
                {
                    skin.specialIcon1 = guitarIconSpecial1;
                    skin.specialIcon2 = guitarIconSpecial2;
                    skin.specialIcon3 = guitarIconSpecial3;
                    skin.specialIcon4 = guitarIconSpecial4;
                    skin.specialIcon5 = guitarIconSpecial5;
                }
                else
                {
                    skin.specialIcon1 = guitarIcon;
                }
            }
            if (skin.instrument == 3)
            {
                if (skin.trinketType == 0)
                {
                    skin.specialIcon1 = pianoIcon1;
                    skin.specialIcon2 = pianoIcon2;
                    skin.specialIcon3 = pianoIcon3;
                }
                else
                {
                    skin.specialIcon1 = pianoIconSpecial1;
                    skin.specialIcon2 = pianoIconSpecial2;
                    skin.specialIcon3 = pianoIconSpecial3;
                }
            }
        }
    }

    void VintageCheck()     //Works
    {
        instrumentBaseDrums = GameObject.Find("Drums").GetComponent<InstrumentBase>();
        instrumentBaseGuitar = GameObject.Find("Guitar").GetComponent<InstrumentBase>();
        instrumentBasePiano = GameObject.Find("Piano").GetComponent<InstrumentBase>();

        foreach (Skin skin in skins)
        {
            if (skin.instrument == 1)
            {
                if (skin.vintageLock > instrumentBaseDrums.vintageLevel)
                {
                    skin.unlocked = false;
                }
                else if (skin.vintageLock <= instrumentBaseDrums.vintageLevel)
                {
                    skin.unlocked = true;
                }
            }

            else if (skin.instrument == 2)
            {
                if (skin.vintageLock > instrumentBaseGuitar.vintageLevel)
                {
                    skin.unlocked = false;
                }

                else if (skin.vintageLock <= instrumentBaseGuitar.vintageLevel)
                {
                    skin.unlocked = true;
                }
            }
            else if (skin.instrument == 3)
            {
                if (skin.vintageLock > instrumentBasePiano.vintageLevel)
                {
                    skin.unlocked = false;
                }

                else if (skin.vintageLock <= instrumentBasePiano.vintageLevel)
                {
                    skin.unlocked = true;
                }
            }
        }
    }

    public void AddSkin(Skin skin)
    {
        skins.Add(skin);

        if (onSkinsChangedCallback != null)
        {
            onSkinsChangedCallback.Invoke();
        }
    }

    public void RemoveItem(Skin skin)
    {
        skins.Remove(skin);

        if (onSkinsChangedCallback != null)
        {
            onSkinsChangedCallback.Invoke();
        }
    }

    public void UnlockSkinNormal()
    {
        int randomInstrument = Random.Range(1, 3);

        if (randomInstrument == 1)
        {
            List<Skin> skinsOfInstrument = new List<Skin>();

            foreach (Skin skin in skins)
            {
                if (skin.instrument == 1)
                {
                    skinsOfInstrument.Add(skin);
                }
            }

            for (int i = 0; i < skinsOfInstrument.Count; i++)
            {
                if (skinsOfInstrument[i].vintageLock > (instrumentBaseDrums.vintageLevel + 1))
                {
                    skinsOfInstrument[i].unlocked = true;
                    print("If this message is shown multiple times, something ain't working quite right");
                    break;
                }
            }
        }
        else if (randomInstrument == 2)
        {
            List<Skin> skinsOfInstrument = new List<Skin>();

            foreach (Skin skin in skins)
            {
                if (skin.instrument == 2)
                {
                    skinsOfInstrument.Add(skin);
                }
            }

            for (int i = 0; i < skinsOfInstrument.Count; i++)
            {
                if (skinsOfInstrument[i].vintageLock < (instrumentBaseDrums.vintageLevel + 1))
                {
                    skinsOfInstrument[i].unlocked = true;
                    print("If this message is shown multiple times, something ain't working quite right");
                    break;
                }
            }
        }
        else if (randomInstrument == 3)
        {
            List<Skin> skinsOfInstrument = new List<Skin>();

            foreach (Skin skin in skins)
            {
                if (skin.instrument == 3)
                {
                    skinsOfInstrument.Add(skin);
                }
            }

            for (int i = 0; i < skinsOfInstrument.Count; i++)
            {
                if (skinsOfInstrument[i].vintageLock < (instrumentBaseDrums.vintageLevel + 1))
                {
                    skinsOfInstrument[i].unlocked = true;
                    print("If this message is shown multiple times, something ain't working quite right");
                    break;
                }
            }
        }
    }

    public void UnlockSkinPremium()
    {
        int randomInstrument = Random.Range(1, 3);

        if (randomInstrument == 1)
        {
            List<Skin> skinsOfInstrument = new List<Skin>();

            foreach (Skin skin in skins)
            {
                if (skin.instrument == 1)
                {
                    skinsOfInstrument.Add(skin);
                }
            }

            for (int i = 0; i < skinsOfInstrument.Count; i++)
            {
                if (skinsOfInstrument[i].vintageLock >= (instrumentBaseDrums.vintageLevel))
                {
                    skinsOfInstrument[i].unlocked = true;
                    print("If this message is shown multiple times, something ain't working quite right");
                    break;
                }
            }
        }
        else if (randomInstrument == 2)
        {
            List<Skin> skinsOfInstrument = new List<Skin>();

            foreach (Skin skin in skins)
            {
                if (skin.instrument == 2)
                {
                    skinsOfInstrument.Add(skin);
                }
            }

            for (int i = 0; i < skinsOfInstrument.Count; i++)
            {
                if (skinsOfInstrument[i].vintageLock >= (instrumentBaseDrums.vintageLevel))
                {
                    skinsOfInstrument[i].unlocked = true;
                    print("If this message is shown multiple times, something ain't working quite right");
                    break;
                }
            }
        }
        else if (randomInstrument == 3)
        {
            List<Skin> skinsOfInstrument = new List<Skin>();

            foreach (Skin skin in skins)
            {
                if (skin.instrument == 3)
                {
                    skinsOfInstrument.Add(skin);
                }
            }

            for (int i = 0; i < skinsOfInstrument.Count; i++)
            {
                if (skinsOfInstrument[i].vintageLock >= (instrumentBaseDrums.vintageLevel))
                {
                    skinsOfInstrument[i].unlocked = true;
                    print("If this message is shown multiple times, something ain't working quite right");
                    break;
                }
            }
        }
    }
}
