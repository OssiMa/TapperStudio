using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour {

    public Image icon;
    public Image background;
    public Text rarity;

    Item item;


    public void EquipItem(Item newItem)
    {
        item = newItem;

        if (item != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
            rarity.text = "" + item.rarity;
            RarityColor();
        }
        else CleanSlot();

    }

    public void CleanSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        rarity.text = "";
        background.color = new Color32(255, 255, 255, 255);
    }

    public void RarityColor()
    {
        if (item.rarity == 1)
        {
            background.color = new Color32(255, 255, 255, 255);
        }
        else if (item.rarity == 2)
        {
            background.color = new Color32(156, 255, 143, 255);
        }
        else if (item.rarity == 3)
        {
            background.color = new Color32(143, 181, 255, 255);
        }
        else if (item.rarity == 4)
        {
            background.color = new Color32(233, 133, 255, 255);
        }
        else
        {
            background.color = new Color32(255, 196, 68, 255);
        }

    }

}
