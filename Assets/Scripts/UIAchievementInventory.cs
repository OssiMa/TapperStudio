using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIAchievementInventory : MonoBehaviour {
    Inventory inventory;

    public Button pgUp;
    public Button pgDown;
    public Text currPage;

    public int page = 1;
    public int maxPages = 3;


    // Use this for initialization
    void Start () {
        inventory = Inventory.instance;
        inventory.onAchievementChangedCallback += PageUpdate;
        inventory.onAchievementChangedCallback.Invoke();
    }

    void PageUpdate()
    {
        maxPages = 3;
        if (page > maxPages)
        {
            page = maxPages;
            print("nope");
        }
        if (page == 1)
        {
            pgDown.interactable = false;
        }
        else
        {
            pgDown.interactable = true;
        }
        if (maxPages > 1 && page != maxPages)
        {
            pgUp.interactable = true;
        }
        else
        {
            pgUp.interactable = false;
        }
        currPage.text = "Page " + page + "/" + maxPages;
    }



    public void PageUp()
    {
        page += 1;
        inventory.onAchievementChangedCallback.Invoke();
    }

    public void PageDown()
    {
        page -= 1;
        inventory.onAchievementChangedCallback.Invoke();
    }
}
