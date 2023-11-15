using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class GameSave
{
    private static string SAVE_DIRECTORY = Application.persistentDataPath + "/";

    public static string SaveGame(GameSave_Template save)
    {
        // Generate a GUID for the each save.
        System.Guid saveId = System.Guid.NewGuid();

        // The save is a new save without an id.
        if (save.saveId == null)
        {
            // Add the new save id into the class before it is serialized
            save.saveId = saveId.ToString();
        }

        // Utility for helping save the filer.
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(SAVE_DIRECTORY + save.saveId + ".db", FileMode.Create);

        // Convert the game save template to a json string.
        string json = JsonUtility.ToJson(save);

        // "Encrypt" the game save.
        formatter.Serialize(stream, json);

        stream.Close();

        return saveId.ToString();
    }

    /**
     * Will return a list of all games saves for the player to 
     * select from.
     */
    public static List<GameSave_Template> GetGameSaves()
    {
        List<GameSave_Template> saves = new List<GameSave_Template>();

        // File steam helpers
        DirectoryInfo ds = new DirectoryInfo(SAVE_DIRECTORY);
        BinaryFormatter formatter = new BinaryFormatter();

        // Get all the files in the given directory.
        FileInfo[] files = ds.GetFiles();

        // Loop thru each file and parse it.
        foreach (FileInfo file in files)
        {
            FileStream fs = new FileStream(SAVE_DIRECTORY + file.Name, FileMode.Open);

            string decryptedFile = formatter.Deserialize(fs).ToString();

            saves.Add(JsonUtility.FromJson<GameSave_Template>(decryptedFile));

            fs.Close();
        }

        return saves;
    }

    public static GameSave_Template getGameSave(string guid)
    {
        return new GameSave_Template();
    }
}
