using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinInventory : MonoBehaviour {

    public List<Skin> skins = new List<Skin>();

    Sprite drumsIcon;
    Sprite guitarIcon;
    Sprite pianoIcon;

    Sprite drumsIcon1;
    Sprite drumsIcon2;
    Sprite drumsIcon3;
    Sprite drumsIcon4;
    Sprite drumsIcon5;
    Sprite drumsIcon6;

    Sprite guitarIconSpecial1;
    Sprite guitarIconSpecial2;
    Sprite guitarIconSpecial3;
    Sprite guitarIconSpecial4;
    Sprite guitarIconSpecial5;

    Sprite pianoIcon1;
    Sprite pianoIcon2;
    Sprite pianoIcon3;

    Sprite pianoIconSpecial;

    //SkinInventory skinInventory;
    InstrumentBase instrumentBaseDrums;
    InstrumentBase instrumentBaseGuitar;
    InstrumentBase instrumentBasePiano;

    //Skin oneSkin = new Skin();

    //SkinGenerator skinGenerator;

    //QUESTION IS, should Skin Generator be used to to some stuff over here??

    //string dataPath;

    public delegate void OnSkinsChange();
    public OnSkinsChange onSkinsChangedCallback;

    void Awake()
    {
        drumsIcon = GameObject.Find("drum_buttonImage").GetComponent<Image>().sprite;
        guitarIcon = GameObject.Find("guitar_buttonImage").GetComponent<Image>().sprite;
        pianoIcon = GameObject.Find("keyboard_buttonImage").GetComponent<Image>().sprite;

        drumsIcon1 = GameObject.Find("drum_buttonImage_body").GetComponent<Image>().sprite;
        drumsIcon2 = GameObject.Find("drum_buttonImage (2)").GetComponent<Image>().sprite;
        drumsIcon3 = GameObject.Find("drum_buttonImage (4)").GetComponent<Image>().sprite;
        drumsIcon4 = GameObject.Find("drum_buttonImage (5)").GetComponent<Image>().sprite;
        drumsIcon5 = GameObject.Find("drum_buttonImage (3)").GetComponent<Image>().sprite;
        drumsIcon6 = GameObject.Find("drum_buttonImage (1)").GetComponent<Image>().sprite;

        guitarIconSpecial1 = GameObject.Find("guitar_buttonImage_kakka").GetComponent<Image>().sprite;
        guitarIconSpecial2 = GameObject.Find("guitar_buttonImage_body (1)").GetComponent<Image>().sprite;
        guitarIconSpecial3 = GameObject.Find("guitar_buttonImage_neck (1)").GetComponent<Image>().sprite;
        guitarIconSpecial4 = GameObject.Find("guitar_buttonImage_head (1)").GetComponent<Image>().sprite;
        guitarIconSpecial5 = GameObject.Find("guitar_buttonImage (2)").GetComponent<Image>().sprite;

        pianoIcon1 = GameObject.Find("keyboard_buttonImage_head").GetComponent<Image>().sprite;
        pianoIcon2 = GameObject.Find("keyboard_buttonImage_bottom").GetComponent<Image>().sprite;
        pianoIcon3 = GameObject.Find("keyboard_buttonImage (2)").GetComponent<Image>().sprite;

        //pianoIconSpecial = GameObject.Find("keyboard_buttonImageSpecial").GetComponent<Image>().sprite;

        instrumentBaseDrums = GameObject.Find("Drums").GetComponent<InstrumentBase>();
        instrumentBaseGuitar = GameObject.Find("Guitar").GetComponent<InstrumentBase>();
        instrumentBasePiano = GameObject.Find("Piano").GetComponent<InstrumentBase>();

        //FindAssets();
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
            print("Skin instrument is" + skin.instrument);
            if (skin.instrument == 1)
            {   
                if (skin.trinketType != 0)
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
                    skin.instrumentIcon = drumsIcon;
                }
            }
            else if (skin.instrument == 2)
            {
                if (skin.trinketType != 0)
                {
                    skin.specialIcon1 = guitarIconSpecial1;
                    skin.specialIcon2 = guitarIconSpecial2;
                    skin.specialIcon3 = guitarIconSpecial3;
                    skin.specialIcon4 = guitarIconSpecial4;
                    skin.specialIcon5 = guitarIconSpecial5;
                }
                else
                {
                    skin.instrumentIcon = guitarIcon;
                }
            }
            if (skin.instrument == 3)
            {
                if (skin.trinketType != 0)
                {
                    skin.specialIcon1 = pianoIcon1;
                    skin.specialIcon2 = pianoIcon2;
                    skin.specialIcon3 = pianoIcon3;
                }
                else
                {
                    skin.instrumentIcon = pianoIcon;
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

    void FindAssets()
    {
        //All this can be figured out if there's time


        //Some way to get all the skins to the list automatique without manual input?
        //First gather the existing skin scriptables to a list, THEN declare that they are part of the skins list
        //dataPath = "Assets/ScriptableObjects/Skins/";
        //AssetDatabase.CreateAsset(Skin, dataPath);

        /*for (int i = 0; i < 10; i++)
        {
            skins.Add(AssetDatabase.FindAssets("Skin" + i));
            //skins[i] = 
        }*/

        /*foreach (Skin singleSkin in skins)
         {
             for (int i = 0; i < 10; i++)
             {
                 singleSkin = AssetDatabase.FindAssets("Skin" + i);
                 skins.Add(singleSkin);
                 //singleSkin[i] = (ScriptableObject)AssetDatabase.LoadAssetAtPath();
             }
         }*/

        /*for (int i = 0; i < 10; i++)      //THIS ONE IS THE BEST RN
        {
            oneSkin = AssetDatabase.FindAssets("Skin" + i);
            skins.Add(oneSkin);
        }*/
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
