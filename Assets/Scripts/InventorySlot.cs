using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;

    Button button; 

    Item item;


    public void AddItem (Item newItem)
    {
        button = GetComponent<Button>();
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        button.interactable = true;
    }

    public void ClearSlot()
    {
        button = GetComponent<Button>();
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
    }

    public Item GetItem()
    {
        return item;
    }
}
