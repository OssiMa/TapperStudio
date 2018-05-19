using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gametime : MonoBehaviour {
    public Achievements achievements;
    [HideInInspector]
    public float secondsCount;

    // Use this for initialization
    bool isAchieced = false;
    bool isAchieced2 = false;
    bool isAchieced3 = false;
    bool isAchieced4 = false;
    bool isAchieced5 = false;

    private void Update()
    {
        secondsCount += Time.deltaTime;
        if(secondsCount > 600 && !isAchieced)
        {
            isAchieced = true;
            achievements.AchievementDone(7);
        }
        else if (secondsCount > 3600 && !isAchieced2)
        {
            isAchieced2 = true;
            achievements.AchievementDone(7);
        }
        else if (secondsCount > 36000 && !isAchieced3)
        {
            isAchieced3 = true;
            achievements.AchievementDone(7);
        }
        else if (secondsCount > 360000 && !isAchieced4)
        {
            isAchieced4 = true;
            achievements.AchievementDone(7);
        }
        else if (secondsCount > 3600000 && !isAchieced5)
        {
            isAchieced5 = true;
            achievements.AchievementDone(7);
        }
    }

}
	


