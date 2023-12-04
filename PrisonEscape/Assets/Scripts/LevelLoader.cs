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
            //if (transform.gameObject.name == "SpawnPoint1" || transform.gameObject.name == "SpawnPoint2")
            GameManager_v2 gameManager = collision.GetComponent<PlayerManager>().getGameManagerObject().GetComponent<GameManager_v2>();
            KeyManager keys = gameManager.getKeys();

            gameManager.setLevelLoaderTag(transform.gameObject.name);

            if (transform.gameObject.tag.Equals("Level1Loader"))
            {
                if (!keys.hasLevelOneKey) return;
                switchScenes("Level1");
            }

            if (transform.gameObject.tag.Equals("Level2Loader"))
            {
                if (!keys.hasLevelTwoKey) return;
                switchScenes("Level2");
            }

            if (transform.gameObject.tag.Equals("Level3Loader"))
            {
                if (!keys.hasLevelThreeKey) return;
                switchScenes("Level3");
            }

            if (transform.gameObject.tag.Equals("CombatLoader"))
            {
                switchScenes("CombatScene");
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
