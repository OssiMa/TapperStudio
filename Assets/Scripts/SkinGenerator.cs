using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinGenerator : MonoBehaviour {

    Skin skin;

    Sprite drums;
    Sprite guitar;
    Sprite piano;

    SkinInventory skinInventory;

    //vintage levels taken from wherever they will be

    // Use this for initialization
    void Start ()
    {
        //The important, colour-changing sprites could have their own folder where they can be taken from
        skinInventory = new SkinInventory();
	}

    public void NewSkin()
    {
        skin = new Skin();
        IconChooser();

        //if skinslot = x, pistä sille kohdalle inventaariossa
        //if instrument on = x, pistä sille instrumentille
        //jos jokin on samassa skinslotissa, täytä tyhjä paikka
        //jos skiniin kuuluu trinketti, pistä ne jotain kautta aktiiviseksi pelissä
    }

    void IconChooser()
    {
        if (skin.instrument == 1)
        {
            skin.instrumentIcon = drums;
        }
        else if (skin.instrument == 2)
        {
            skin.instrumentIcon = guitar;
        }
        if (skin.instrument == 3)
        {
            skin.instrumentIcon = piano;
        }
    }

    void VintageCheck()
    {
        if (skin.instrument == 1)
        {
            /*if (skin.vintageLock > MISSINGSCRIPT.drum.vintageLevel)
            {
                
            }
            else if (skin.vintageLock <= MISSINGSCRIPT.drum.vintageLevel)
            {
                
            }*/
        }
        
        else if (skin.instrument == 2)
        {
            /*if (skin.vintageLock > MISSINGSCRIPT.guitar.vintageLevel)
            {
                  
            }
            
         else if (skin.vintageLock <= MISSINGSCRIPT.guitar.vintageLevel)
            {
                  
            }*/
        }
        else if (skin.instrument == 3)
        {
            /* if (skin.vintageLock <= MISSINGSCRIPT.piano.vintageLevel)
             {
                   
             }

          else if (skin.vintageLock <= MISSINGSCRIPT.piano.vintageLevel)
             {
                   
             }*/
        }
    }
}
