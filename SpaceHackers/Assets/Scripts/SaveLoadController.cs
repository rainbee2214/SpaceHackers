using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadController
{
    public static void Create(int slot)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SpaceHackersSaveSlot" + slot + ".dat");
        
        SaveGame data = new SaveGame();
        bf.Serialize(file, data);

        file.Close();
    }

    public static void Save(int slot, SaveGame theData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/SpaceHackersSaveSlot" + slot + ".dat", FileMode.Open);

        bf.Serialize(file, theData);

        file.Close();
    }

    public static SaveGame Load(int slot)
    {
        if (File.Exists(Application.persistentDataPath + "/SpaceHackersSaveSlot" + slot + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SpaceHackersSaveSlot" + slot + ".dat", FileMode.Open);
            SaveGame data = (SaveGame)bf.Deserialize(file);
            file.Close();
            return data;
        }
        else return null;
    }

    public static bool CheckForSaves()
    {
        for (int i=1; i<=4; i++)
        {
            if (File.Exists(Application.persistentDataPath + "/SpaceHackersSaveSlot" + i + ".dat")) return true;
        }
        return false;
    }
}

[Serializable]
public class SaveGame
{
    public string name = "";
    public int playerRace = 0;
    public int playerClass = 0;
    public int playerShip = 0;

    public int health = 0;
    public int experience = 0;
}
