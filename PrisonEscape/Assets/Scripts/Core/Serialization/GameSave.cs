using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave
{
    public void saveGame(GameSave_Template save)
    {
        // Generate a GUID for the each save.
        System.Guid saveId = System.Guid.NewGuid();

        // The save is a new save without an id.
        if (save.saveId == null)
        {
            // Add the new save id into the class before it is serialized
            save.saveId = saveId.ToString();
        }

        // Convert the game save template to a json string.
        string json = JsonUtility.ToJson(save);

        /**
         * Save the game here with the file name being the GUID.
         * Override any files with a guid or create new file.
         */
    }

    /**
     * Will return a list of all games saves for the player to 
     * select from.
     */
    public List<GameSave_Template> getGameSaves()
    {
        return new List<GameSave_Template>();
    }

    public GameSave_Template getGameSave(string guid)
    {
        return new GameSave_Template();
    }
}
