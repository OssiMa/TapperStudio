using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour {

    public Image icon;
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
        }
        else ClearSlot();

    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        rarity.text = "";
    }

}
