using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataInfo
{
    public static int money;
    public static int highscore;
    public static int speedUpgradeLevel;

    public static bool[] isArrowColorBought;
    public static bool[] isTrailColorBought;

    public static int equippedArrowColor;
    public static int equippedTrailColor;

    public static void Save()
    {
        SaveSystem.Save();
    }

    public static void Load()
    {
        PlayerData_Storage data = SaveSystem.Load();
        if (data == null)
            return;

        money = data.money;
        highscore = data.highscore;
        speedUpgradeLevel = data.speedUpgradeLevel;
        isArrowColorBought = new bool[12];
        if (data.isArrowColorBought != null)
        {
            isArrowColorBought = data.isArrowColorBought;
        } else
        {
            for (int i = 0; i < 12; i++)
            {
                isArrowColorBought[i] = false;
            }
            isArrowColorBought[0] = true;
        }

        isTrailColorBought = new bool[12];
        if (data.isTrailColorBought != null)
        {
            isTrailColorBought = data.isTrailColorBought;
        }
        else
        {
            for (int i = 0; i < 12; i++)
            {
                isTrailColorBought[i] = false;
            }
            isTrailColorBought[0] = true;
        }

        equippedArrowColor = data.equippedArrowColor;
        equippedTrailColor = data.equippedTrailColor;
      //  test[0] = data.test[0];
    }

    public static void ResetSave()
    {
        money = 0;
        highscore = 0;
        speedUpgradeLevel = 0;

        for(int i = 0; i < 12; i++)
        {
            isArrowColorBought[i] = false;
            isTrailColorBought[i] = false;
        }
        isArrowColorBought[0] = true;
        isTrailColorBought[0] = true;

        SaveSystem.Save();
    }

}
