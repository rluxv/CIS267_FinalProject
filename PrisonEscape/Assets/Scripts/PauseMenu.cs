using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject PauseMenuObject;
    [SerializeField] private TMP_Text[] OptionsText;
    [SerializeField] private TMP_Text SelectorText;
    [SerializeField] private GameObject GameManagerObj;
    private bool pauseMenuOpen;
    private bool ctrlrHold;
    int selected;
    void Start()
    {
        //gameObject.scene.name;
        pauseMenuOpen = false;
        PauseMenuObject.SetActive(false);
        ctrlrHold = false;
        selected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        getInput(false);
        if(pauseMenuOpen)
        {
            getControllerInput();
        }
    }

    private void getControllerInput()
    {
        if (Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
        {
            if (ctrlrHold == true)
            {
                // do nothing
            }
            else
            {
                getInput(true);
                ctrlrHold = true;
            }
        }
        else
        {
            ctrlrHold = false;
        }
    }
    private void getInput(bool ctrlPress)
    {
        if(Input.GetButtonDown("StartButton"))
        {
            if(pauseMenuOpen)
            {
                pauseMenuOpen = false;
                PauseMenuObject.SetActive(false);
                Time.timeScale = 1f;
            }   
            else
            {
                pauseMenuOpen = true;
                PauseMenuObject.SetActive(true);
                Time.timeScale = 0f;
                PauseMenuObject.transform.position = new Vector3(PlayerPos.getPlayerPosX(), PlayerPos.getPlayerPosY(), 0);
                selected = 0;
                SelectorText.GetComponent<RectTransform>().anchoredPosition = OptionsText[selected].GetComponent<RectTransform>().anchoredPosition;
            }
        }
        else if(pauseMenuOpen)
        {
            if(Input.GetButtonDown("BButton"))
            {
                pauseMenuOpen = false;
                PauseMenuObject.SetActive(false);
                Time.timeScale = 1f;
            }
            else if (Input.GetButtonDown("AButton"))
            {
                if(selected == 0) // resume game
                {
                    pauseMenuOpen = false;
                    PauseMenuObject.SetActive(false);
                    Time.timeScale = 1f;
                }
                else if(selected == 1)
                {
                    // save game


                    //close pause menu
                    pauseMenuOpen = false;
                    PauseMenuObject.SetActive(false);
                    Time.timeScale = 1f;
                }
                else if(selected == 2)
                {
                    // hide pause menu
                    pauseMenuOpen = false;
                    PauseMenuObject.SetActive(false);
                    Time.timeScale = 1f;
                    // quit to menu
                    SceneManager.LoadScene("MainMenu");
                    GameManagerObj.SetActive(false);

                }
            }
            else if (Input.GetKeyDown(KeyCode.S) || (ctrlPress && Input.GetAxis("Vertical") == -1))
            {
                if (selected < 2)
                {
                    selected++;
                    SelectorText.GetComponent<RectTransform>().anchoredPosition = OptionsText[selected].GetComponent<RectTransform>().anchoredPosition;
                }
                else if (selected == 2)
                {
                    selected = 0;
                    SelectorText.GetComponent<RectTransform>().anchoredPosition = OptionsText[selected].GetComponent<RectTransform>().anchoredPosition;
                }

            }
            else if (Input.GetKeyDown(KeyCode.W) || (ctrlPress && Input.GetAxis("Vertical") == 1))
            {
                if (selected > 0)
                {
                    selected--;
                    SelectorText.GetComponent<RectTransform>().anchoredPosition = OptionsText[selected].GetComponent<RectTransform>().anchoredPosition;
                }
                else if (selected == 0)
                {
                    selected = 2;
                    SelectorText.GetComponent<RectTransform>().anchoredPosition = OptionsText[selected].GetComponent<RectTransform>().anchoredPosition;
                }
            }
        }
    }
}
