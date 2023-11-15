using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_v2 : MonoBehaviour
{
    private GameSave_Template gameSave;

    // Player Varibles
    [SerializeField]
    private GameObject o_player;
    private PlayerManager player;

    // Start is called before the first frame update
    void Start()
    {
        // Get the player manager from the player object.
        player = o_player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    /**
     * This function will be called when the users wants
     * to start playing the game. Mounts the player from the selected game
     * save.
     * 
     * Invoked By: Main_Menu.newGame()
     */
    public void OnGameLoad()
    {
        if (gameSave != null)
        {
            // Setup from game save
            SceneManager.LoadScene(gameSave.level);
            // Set player position.
            player.obj.transform.position = gameSave.position;
            // Set the players health.
            player.SetHealth(gameSave.playerHealth);
        }
        else
        {
            // Create new game save.
            this.OnCreateNewSave();
            // Recall this function
            OnGameLoad();
        }
    }

    /**
     * When the user wants to create a new game save
     * simply call this and it will create a new
     * save template.
     */
    public void OnCreateNewSave()
    {
        gameSave = new GameSave_Template
        {
            // Set default game save information.
            level = Config.DEFAULT_SAVE_LEVEL,
            position = Config.DEFAULT_POSITION,
            playerHealth = Config.DEFAULT_ENTITY_HEALTH
        };

        // Save the game and generate a new save id.
        string saveId = GameSave.SaveGame(gameSave);

        // Set the new saveId.
        gameSave.saveId = saveId;
    }

    public PlayerManager GetPlayer()
    {
        return player;
    }

    public GameSave_Template GetSave()
    {
        return gameSave;
    }
}
