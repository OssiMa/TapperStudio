using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstrumentBase : MonoBehaviour {

    InventoryUI invUI;


    public SongProgress progression;

    public GameObject comboTextObject;

    public Slider xpBar;
    public Image fadeCounter;
    public Text currLvl;
    public Text nxtLvl;
    public Text comboNumber;

    public float exp = 0;       //instrument experience, don't confuse with song progress
    public float startXp;
    public float expToNext = 25;
    public float level = 1;
    public float nextLevel = 2;
    [HideInInspector]
    public int vintageLevel = 0;
    public int instrumentNbr;
    public int availableSlots = 1;

    public float combo = 1;                 //current combo
    public float comboStep;                 //when at combostemax, combo increases
    public float comboStepMax = 20;         //combo up when reached
    public float comboUpkeep = 5;           //mistakes player can make before losing combo
    public float comboFade = 2000;          //how long the instrument needs to be inactive to lose combo
    public float comboFadeMax = 2000;       //maximum wait for combo lose

    float ogMaxCombo;
    [HideInInspector]
    public float maxCombo;

    float geneBoost;
    float comboBoost;
    public float xpBoost;

    Achievements achievements;

    private void Awake()
    {
        comboNumber.text = combo + "";
    }

    // Use this for initialization
    void Start ()
    {
        invUI = InventoryUI.instance;
        xpBar.minValue = startXp;
        xpBar.maxValue = expToNext;
        currLvl.text = "" + level;
        nxtLvl.text = "" + nextLevel;
        nextLevel = level + 1.0f;
        BoostUpdate();
        ogMaxCombo = 4;
        achievements = GameObject.Find("GameManager").GetComponent<Achievements>();
    }

    // Update is called once per frame
    void Update()
    {
        if (progression.menu == false && progression.endMenu == false)
        { 
            xpBar.value = exp;
            nxtLvl.text = "" + nextLevel;
            currLvl.text = "" + level;
            LvlUp();
            BoostUpdate();
            maxCombo = ogMaxCombo + comboBoost;
            fadeCounter.fillAmount = (comboFade / comboFadeMax);
        }

    }

    void LvlUp()
    {
        if (exp >= expToNext && level < 19)
        {
            level += 1;
            nextLevel += 1;
            startXp = expToNext;
            expToNext = startXp + 40 + 10*level;
            xpBar.minValue = startXp;
            xpBar.maxValue = expToNext;

        }
        else if (level == 19 && exp >= expToNext)
        {
            level = 20;
        }

        if (level == 3 && achievements.DrumNumber == 0 && instrumentNbr == 1)
        {
            achievements.AchievementDone(13);
        }
        else if (level == 6 && achievements.DrumNumber == 1 && instrumentNbr == 1)
        {
            achievements.AchievementDone(13);
        }
        else if (level == 10 && achievements.DrumNumber == 2 && instrumentNbr == 1)
        {
            achievements.AchievementDone(13);
        }
        else if (level == 15 && achievements.DrumNumber == 3 && instrumentNbr == 1)
        {
            achievements.AchievementDone(13);
        }
        else if (level == 20 && achievements.DrumNumber == 4 && instrumentNbr == 1)
        {
            achievements.AchievementDone(13);
        }

        if (level == 3 && achievements.GuitarNumber == 0 && instrumentNbr == 2)
        {
            achievements.AchievementDone(2);
        }
        else if (level == 6 && achievements.GuitarNumber == 1 && instrumentNbr == 2)
        {
            achievements.AchievementDone(2);
        }
        else if (level == 10 && achievements.GuitarNumber == 2 && instrumentNbr == 2)
        {
            achievements.AchievementDone(2);
        }
        else if (level == 15 && achievements.GuitarNumber == 3 && instrumentNbr == 2)
        {
            achievements.AchievementDone(2);
        }
        else if (level == 20 && achievements.GuitarNumber == 4 && instrumentNbr == 2)
        {
            achievements.AchievementDone(2);
        }


        if (level == 3 && achievements.PianoNumber == 0 && instrumentNbr == 3)
        {
            achievements.AchievementDone(5);
        }
        else if (level == 6 && achievements.PianoNumber == 1 && instrumentNbr == 3)
        {
            achievements.AchievementDone(5);
        }
        else if (level == 10 && achievements.PianoNumber == 2 && instrumentNbr == 3)
        {
            achievements.AchievementDone(5);
        }
        else if (level == 15 && achievements.PianoNumber == 3 && instrumentNbr == 3)
        {
            achievements.AchievementDone(5);
        }
        else if (level == 20 && achievements.PianoNumber == 4 && instrumentNbr == 3)
        {
            achievements.AchievementDone(5);
        }
    }

    public void VintageLvlUp()
    {
        vintageLevel += 1;
        exp = 0;
        expToNext = 25;
        level = 1;
        nextLevel = 2;
        xpBar.minValue = 0;
        xpBar.maxValue = expToNext;
        if (availableSlots<3)
        {
            availableSlots += 1;
            InventoryUI.instance.GainEquipSlot(this);
            Inventory.instance.onItemChangedCallback.Invoke();
        }
    }

    public void Tap()
    {
        if (comboUpkeep > 0)
        {
            comboUpkeep -= 2;
        }
        else if (comboUpkeep <= 0 && combo >1)
        {
            combo -= 1;
            comboNumber.text = combo + "";
            comboStep = 0;
            comboUpkeep = 4;
        }
    }

    public void ComboTap()
    {
        exp += 1 + 0.1f * combo + xpBoost*0.25f;
        progression.GainXP(this);
        if (combo < maxCombo)     //4 + comboBoost
        {
            comboStep += 1;
            if (comboStep >= comboStepMax)
            {
                combo += 1;
                comboNumber.text = combo + "";
                comboStep = 0;
                comboAchievement();
                /*GameObject spawnedText;
                Instantiate(comboTextObject);
                spawnedText = GameObject.Find("ComboUpText(Clone)");
                spawnedText.transform.SetParent(gameObject.transform);
                spawnedText.GetComponent<Text>().enabled = true;
                spawnedText.GetComponent<ComboText>().MyInstrument(combo);*/
            }

        }
        if (comboUpkeep <11)
        {
            comboUpkeep += 3;
        }

        ComboFadeUp();

    }

    public void ComboFading()
    {
        if (combo > 1)
        {
            combo -= 1;
            comboFade = comboFadeMax;
            fadeCounter.fillAmount = 1;
            comboNumber.text = combo + "";
        }
    }

    void ComboFadeUp()
    {
        if (comboFade < comboFadeMax)
        {
            comboFade += 75;
        }
    }

    public void UpdateComboCounter()
    {
        fadeCounter.fillAmount = (comboFade / comboFadeMax);
        comboNumber.text = combo + "";
    }

    public void BigExpReward()
    {
        exp += 2 * combo + xpBoost * 4;
        progression.GainXP(this);
        progression.GainXP(this);
        progression.GainXP(this);
        if(combo < maxCombo)        // 4 + comboBoost
        {
            comboStep += 5;
            if (comboStep >= comboStepMax)
            {
                combo += 1;
                comboNumber.text = combo + "";
                comboStep = 0;
                comboAchievement();
            }
        }
        ComboFadeUp();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tap();
        }
    }
    
    public float GetBoosts(int i)
    {
        invUI = InventoryUI.instance;
        if (invUI.EquipBoosts(instrumentNbr, i) != null)
        {
            Item booster = invUI.EquipBoosts(instrumentNbr, i);
            float boostValue = booster.boostPower + (booster.level / 4);
            return booster.boostPower;
        }
        else
        {
            return 0;
        }
        
    }

    public void BoostUpdate()
    {
        geneBoost = GetBoosts(1);
        comboBoost = GetBoosts(2);
        xpBoost = GetBoosts(3);
    }

   
    void comboAchievement()
    {
        if (combo == 3 && achievements.DrumComboNumber == 0 && instrumentNbr == 1)
        {
            achievements.AchievementDone(8);
        }
        else if (combo == 6 && achievements.DrumComboNumber == 1 && instrumentNbr == 1)
        {
            achievements.AchievementDone(8);
        }
        else if (combo == 10 && achievements.DrumComboNumber == 2 && instrumentNbr == 1)
        {
            achievements.AchievementDone(8);
        }
        else if (combo == 15 && achievements.DrumComboNumber == 3 && instrumentNbr == 1)
        {
            achievements.AchievementDone(8);
        }
        else if (combo == 20 && achievements.DrumComboNumber == 4 && instrumentNbr == 1)
        {
            achievements.AchievementDone(8);
        }

        if (combo == 3 && achievements.GuitarComboNumber == 0 && instrumentNbr == 2)
        {
            achievements.AchievementDone(11);
        }
        else if (combo == 6 && achievements.GuitarComboNumber == 1 && instrumentNbr == 2)
        {
            achievements.AchievementDone(11);
        }
        else if (combo == 10 && achievements.GuitarComboNumber == 2 && instrumentNbr == 2)
        {
            achievements.AchievementDone(11);
        }
        else if (combo == 15 && achievements.GuitarComboNumber == 3 && instrumentNbr == 2)
        {
            achievements.AchievementDone(11);
        }
        else if (combo == 20 && achievements.GuitarComboNumber == 4 && instrumentNbr == 2)
        {
            achievements.AchievementDone(11);
        }


        if (combo == 3 && achievements.PianoComboNumber == 0 && instrumentNbr == 3)
        {
            achievements.AchievementDone(14);
        }
        else if (combo == 6 && achievements.PianoComboNumber == 1 && instrumentNbr == 3)
        {
            achievements.AchievementDone(14);
        }
        else if (combo == 10 && achievements.PianoComboNumber == 2 && instrumentNbr == 3)
        {
            achievements.AchievementDone(14);
        }
        else if (combo == 15 && achievements.PianoComboNumber == 3 && instrumentNbr == 3)
        {
            achievements.AchievementDone(14);
        }
        else if (combo == 20 && achievements.PianoComboNumber == 4 && instrumentNbr == 3)
        {
            achievements.AchievementDone(14);
        }
    }
}
