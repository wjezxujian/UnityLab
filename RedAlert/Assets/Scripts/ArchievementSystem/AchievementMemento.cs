using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AchievementMemento
{
    public int enemyKilledCount { get; set; }
    public int soldierKilledCount { get; set; }
    public int maxStageLv { get; set; }


    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyKilledCount", enemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", soldierKilledCount);
        PlayerPrefs.SetInt("MaxStageLv", maxStageLv);
    }

    public void LoadData()
    {
        enemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount", 0);
        soldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount", 0);
        maxStageLv = PlayerPrefs.GetInt("MaxStageLv", 1);
    }
}