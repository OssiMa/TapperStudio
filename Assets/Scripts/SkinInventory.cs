using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinInventory : MonoBehaviour {

    public List<Skin> skins = new List<Skin>();

    //SkinGenerator skinGenerator;

    public delegate void OnSkinsChange();
    public OnSkinsChange onSkinsChangedCallback;


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
}
