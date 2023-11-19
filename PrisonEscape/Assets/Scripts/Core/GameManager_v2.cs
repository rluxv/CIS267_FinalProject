using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_v2 : MonoBehaviour
{
    private GameSave_Template gameSave;

    //  Level Loader
    private GameObject sceneSpawnPoint;
    private string levelLoaderTag;

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

    public PlayerManager GetPlayer()
    {
        return player;
    }

    public GameSave_Template GetSave()
    {
        return gameSave;
    }

    public void SetSave(string guid)
    {
        gameSave = GameSave.getGameSave(guid);
    }

    //  Adds a listener for when the scene changes
    private void OnEnable()
    {
        //Debug.Log("OnEnable Called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //  removes the listener for when the scene changes (on game termination)
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

    //  When a scene changes, This function is called
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        
        //  Check if this is the first scene load
        if (levelLoaderTag == null)
        {
            levelLoaderTag = "SpawnPoint1";
            
        }
        Debug.Log("levelLoaderTag");


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

    }






}
