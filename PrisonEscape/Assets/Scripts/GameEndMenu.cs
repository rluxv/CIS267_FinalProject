using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("DontDestroyOnLoad"));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("BButton") || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetButtonDown("AButton") || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("CreditsMenu");
        }
        if (Input.GetButtonDown("XButton") || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.B))
        {
            Application.Quit();
        }
    }
}
