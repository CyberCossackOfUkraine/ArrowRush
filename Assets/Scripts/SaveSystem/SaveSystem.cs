using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveData.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData_Storage data = new PlayerData_Storage();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData_Storage Load()
    {
        string path = Application.persistentDataPath + "/SaveData.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.Open(path, FileMode.Open);
            PlayerData_Storage data = formatter.Deserialize(stream) as PlayerData_Storage;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}

[Serializable]
public class PlayerData_Storage
{
    public int money;
    public int highscore;
    public int speedUpgradeLevel;

    public bool[] isArrowColorBought;
    public bool[] isTrailColorBought;

    public int equippedArrowColor;
    public int equippedTrailColor;


    public PlayerData_Storage()
    {
        money = DataInfo.money;
        highscore = DataInfo.highscore;
        speedUpgradeLevel = DataInfo.speedUpgradeLevel;
        isArrowColorBought = DataInfo.isArrowColorBought;
        isTrailColorBought = DataInfo.isTrailColorBought;
        equippedArrowColor = DataInfo.equippedArrowColor;
        equippedTrailColor = DataInfo.equippedTrailColor;
    }

}
