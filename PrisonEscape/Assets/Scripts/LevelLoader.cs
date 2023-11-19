using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(transform.gameObject.tag + " Collided with: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.gameObject.name == "SpawnPoint1" || transform.gameObject.name == "SpawnPoint2")
            collision.GetComponent<PlayerManager>().getGameManagerObject().GetComponent<GameManager_v2>().setLevelLoaderTag(transform.gameObject.name);
            switch (transform.gameObject.tag)
            {
                case "Level1Loader":
                    switchScenes("Level1");
                    break;
                case "Level2Loader":
                    switchScenes("Level2");
                    break;
                case "Level3Loader":
                    switchScenes("Level3");
                    break;
                case "CombatLoader":
                    if(GameManager_v2.PreviousScene != "CombatScene")
                    {
                        switchScenes("CombatScene");
                    }
                    break;
            }
        }
    }

    private void switchScenes(string levelName)
    {
        // do other stuff that may need to be done before loading scene

        //load the scene
        SceneManager.LoadScene(levelName);
    }
}
