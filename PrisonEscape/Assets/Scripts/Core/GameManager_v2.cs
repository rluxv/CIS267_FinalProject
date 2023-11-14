using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_v2 : MonoBehaviour
{
    GameSave_Template gameSave;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * This function will be called when the users wants
     * to start playing the game. When this is invoked would be determined by
     * our flow.
     */
    public void onGameLoad()
    {
        if (gameSave != null)
        {
            // Setup from game save

            /* Example */
            if (gameSave.level == 1)
            {
                SceneManager.LoadScene("Level1");
            }
        }
        else
        {
            // Setup like fresh game
            SceneManager.LoadScene("Level1");
        }
    }

    /**
     * When the user wants to create a new game save
     * simply call this and it will create a new
     * save template.
     */
    public void onCreateNewSave()
    {
        gameSave = new GameSave_Template();
    }
}
