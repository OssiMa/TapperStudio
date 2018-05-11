using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    public Image background;
    public Text rarity;
    public Text equipped;
    public GameObject iconStuff;

    Button button; 

    Item item;


    public void AddItem (Item newItem)
    {
        button = GetComponent<Button>();
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        button.interactable = true;
        rarity.text = "" + item.rarity;
        RarityColor();
        equipped.enabled = false;
        iconStuff.SetActive(true);
    }

    public void ClearSlot()
    {
        button = GetComponent<Button>();
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
        rarity.text = "";
        background.color = new Color32(255,255,255,255);
        equipped.enabled = false;
        iconStuff.SetActive(false);
    }

    public void CraftingFilter()
    {
        button = GetComponent<Button>();
        button.interactable = false;
    }

    public Item GetItem()
    {
        return item;
    }

    public void RarityColor()
    {
        if (item.rarity == 1)
        {
            background.color = new Color32(255,255,255,255);
        }
        else if (item.rarity == 2)
        {
            background.color = new Color32(156,255,143,255);
        }
        else if (item.rarity == 3)
        {
            background.color = new Color32(143,181,255,255);
        }
        else if (item.rarity == 4)
        {
            background.color = new Color32(233,133,255,255);
        }
        else
        {
            background.color = new Color32(255,196,68,255);
        }

    }

    public void Equipped()
    {
        equipped.enabled = true;
    }

}
