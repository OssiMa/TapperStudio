using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gametime : MonoBehaviour {
    public Achievements achievements;
    [HideInInspector]
    public float secondsCount;

    // Use this for initialization
    bool isAchieved = false;
    bool isAchieved2 = false;
    bool isAchieved3 = false;
    bool isAchieved4 = false;
    bool isAchieved5 = false;

    private void Update()
    {
        secondsCount += Time.deltaTime;
        if(secondsCount > 600 && !isAchieved)
        {
            isAchieved = true;
            achievements.AchievementDone(7);
        }
        else if (secondsCount > 3600 && !isAchieved2)
        {
            isAchieved2 = true;
            achievements.AchievementDone(7);
        }
        else if (secondsCount > 36000 && !isAchieved3)
        {
            isAchieved3 = true;
            achievements.AchievementDone(7);
        }
        else if (secondsCount > 360000 && !isAchieved4)
        {
            isAchieved4 = true;
            achievements.AchievementDone(7);
        }
        else if (secondsCount > 3600000 && !isAchieved5)
        {
            isAchieved5 = true;
            achievements.AchievementDone(7);
        }
    }

}
	


