using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> items = new List<Item>();


    void AddItem(Item item)
    {
        items.Add(item);
    }

    void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
