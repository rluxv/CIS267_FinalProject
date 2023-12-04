using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_v2 : MonoBehaviour
{
    private GameSave_Template gameSave;

    //  Level Loader
    private GameObject sceneSpawnPoint;
    private string levelLoaderTag;
    private ItemLootTable itemLootTableScript;


    // Player Varibles
    [SerializeField]
    private GameObject o_player;

    private PlayerManager player;

    public static string PreviousScene { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        // Get the player manager from the player object.
        player = o_player.GetComponent<PlayerManager>();
        itemLootTableScript = this.gameObject.transform.GetChild(0).GetComponent<ItemLootTable>();
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
        foreach (GameSave_Template save in GameSave.GetGameSaves())
        {
            Debug.Log(JsonUtility.ToJson(save));
        }

        if (player == null)
        {
            return;
        }

        if (gameSave != null)
        {
            // Setup from game save
            SceneManager.LoadScene(gameSave.level);
            // Set player position.
            player.obj.transform.position = gameSave.position;

            // Set the players health.
            player.SetHealth(gameSave.playerHealth);
            player.setBalance(gameSave.coins);
            player.setInventory(gameSave.playerInventory);
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
     * OnCreateNewSave is invoked when a player
     * requests a new game. Creates a default
     * save and saves the file.
     */
    public void OnCreateNewSave()
    {
        gameSave = new GameSave_Template();

        gameSave.level = Config.DEFAULT_SAVE_LEVEL;
        gameSave.position = Config.DEFAULT_POSITION;
        gameSave.playerHealth = Config.DEFAULT_ENTITY_HEALTH;
        gameSave.playerInventory = new Inventory();
        gameSave.coins = Config.STARTING_BALANCE;

        // Save the game and generate a new save id.
        string saveId = GameSave.SaveGame(gameSave);

        // Set the new saveId.
        gameSave.saveId = saveId;

        //  start at the first spawn point
        levelLoaderTag = "SpawnPoint1";
    }

    /**
     * Get the current player manager
     * instance that we have. Gives full access
     * to the player.
     */
    public PlayerManager GetPlayer()
    {
        return player;
    }

    /**
     * Returns the current game save.
     */
    public GameSave_Template GetSave()
    {
        return gameSave;
    }

    /**
     * Set the current game save
     * via it's id.
     */
    public void SetSave(string guid)
    {
        gameSave = GameSave.getGameSave(guid);
    }

    /**
     * Mount a listener for scene changes,
     * any scene change dependant should happen here.
     */
    private void OnEnable()
    {
        //Debug.Log("OnEnable Called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /**
     * Unmounts the listener for scene changes,
     * on game termination.
     */
    private void OnDisable()
    {
        //Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    //  Lets the Loader set our levelLoaderTag
    public void setLevelLoaderTag(string tag)
    {
        levelLoaderTag = tag;
    }

    /**
     * OnSceneLoaded is invoked when a scene is
     * fully loaded.
     */
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        
        //  Check if this is the first scene load
        if (levelLoaderTag == null)
        {
            levelLoaderTag = "SpawnPoint1";
            
        }
        //Debug.Log("levelLoaderTag");


        if (levelLoaderTag != "")
        {
            //  find spawn point based on "levelLoaderTag" from the level loader that sent you
            sceneSpawnPoint = GameObject.FindGameObjectWithTag(levelLoaderTag);
            //  move player to the designated spawn point
            o_player.transform.position = sceneSpawnPoint.transform.position;
        }
       

        //  reset for next time
        levelLoaderTag = "";



        //  Update PlayerPosition
        PlayerPos.setPlayerPosX(transform.position.x);
        PlayerPos.setPlayerPosY(transform.position.y);

        //  update loot table to new level's loot
        if (itemLootTableScript != null)
        {
            itemLootTableScript.updateCurrentLevelForLoot();
        }


    }

    /**
     * Used to save the current game state
     * so it can be loaded in at a different time.
     */
    public void SaveGame()
    {
        // Save the players current position.
        gameSave.position = o_player.transform.position;

        // Save the players current health.
        gameSave.playerHealth = player.GetHealth();

        // Save the players coins.
        gameSave.coins = player.getBalance();

        // Save player inventory.
        gameSave.playerInventory = player.getInventory();

        Debug.Log("Saving Game....");
        Debug.Log(JsonUtility.ToJson(gameSave));

        // Save the game file.
        GameSave.SaveGame(gameSave);
    }




}
