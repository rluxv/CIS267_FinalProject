using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBoss : MonoBehaviour
{
    GameManager_v2 GameManager;
    [SerializeField] private int bossLevel;
    // Start is called before the first frame update
    void Start()
    {
        //Removes the boss if the player already has the key so they don't have to fight them again.
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager_v2>();
        if(bossLevel == 1)
        {
            if (GameManager.getKeys().hasLevelTwoKey)
            {
                Destroy(this.gameObject);
            }
        }
        if(bossLevel == 2)
        {
            if (GameManager.getKeys().hasLevelThreeKey)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("BossCombatScene");
    }

}
