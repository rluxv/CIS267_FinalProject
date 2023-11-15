using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnLoad : MonoBehaviour
{
    public GameObject o_gameManager;
    private GameManager_v2 gameManager;

    // Start is called before the first frame update
    private static KeepOnLoad keepOnLoad;
    void Start()
    {
        // We can reference the game manager from the keep on load script.
        gameManager = o_gameManager.GetComponent<GameManager_v2>();

        DontDestroyOnLoad(this.gameObject);

        if (keepOnLoad == null)
        {
            keepOnLoad = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    /**
     * Get the game manager from the KeepOnLoad
     * object since it will always be there.
     */
    public GameManager_v2 getGameManager()
    {
        return o_gameManager.GetComponent<GameManager_v2>();
    }
}
