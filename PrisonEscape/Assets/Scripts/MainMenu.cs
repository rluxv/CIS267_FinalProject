using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject ArrowText;
    [SerializeField] private GameObject MainMenuButtons;
    [SerializeField] private GameObject LoadMenuButtons;
    private TMP_Text ArrowTextTMP;
    private int selected;
    private bool ctrlrHold;
    private int textAnimPos;

    private bool saveMenuOpen;

    AudioSource audioData;
    public void Start()
    {
        selected = 0;
        ctrlrHold = false;
        saveMenuOpen = false;
        audioData = GetComponent<AudioSource>();
        ArrowTextTMP = ArrowText.GetComponent<TMP_Text>();
    }
    public void startGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        controllerInput();
        input(false);
    }

    public void openLoadSaveMenu()
    {
        MainMenuButtons.SetActive(false);
        LoadMenuButtons.SetActive(true);
        saveMenuOpen = true;
        selected = 0;
        ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 100, 0);
    }

    public void openMainMenu()
    {
        LoadMenuButtons.SetActive(false);
        MainMenuButtons.SetActive(true);
        saveMenuOpen = false;
        selected = 0;
        ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 100, 0);
    }

    private void controllerInput()
    {
        if(Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
        {
            if(ctrlrHold == true)
            {
                // do nothing
            }   
            else
            {
                input(true);
                ctrlrHold = true;
            }
        }
        else
        {
            ctrlrHold = false;
        }
    }

    private void input(bool ctrlPress)
    {
        if (Input.GetKeyDown(KeyCode.S) || (ctrlPress && Input.GetAxis("Vertical") == -1))
        {
            if (selected == 0)
            {
                selected = 1;
                playAudio();
                ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            }
            else if (selected == 1)
            {
                selected = 2;
                playAudio();
                ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -100, 0);
            }
            else if (selected == 2)
            {
                if (saveMenuOpen)
                {
                    selected = 3;
                    playAudio();
                    ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -200, 0);
                }
                else
                {
                    selected = 0;
                    playAudio();
                    ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 100, 0);
                }
            }
            else if (selected == 3)
            {
                selected = 0;
                playAudio();
                ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 100, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || (ctrlPress && Input.GetAxis("Vertical") == 1))
        {
            if (selected == 0)
            {
                if (saveMenuOpen == true)
                {
                    selected = 3;
                    playAudio();
                    ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -200, 0);
                }
                else
                {
                    selected = 2;
                    playAudio();
                    ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -100, 0);
                }
            }
            else if (selected == 1)
            {
                selected = 0;
                playAudio();
                ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 100, 0);
            }
            else if (selected == 2)
            {
                selected = 1;
                playAudio();
                ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            }
            else if (selected == 3)
            {
                selected = 2;
                playAudio();
                ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -100, 0);
            }
        }

        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("AButton")) && saveMenuOpen == false)
        {
            playAudio();
            // 0 = start game 1 = show save menu 2 = quit
            if (selected == 0)
            {
                startGame();
            }
            else if (selected == 1)
            {
                openLoadSaveMenu();
            }
            else if (selected == 2)
            {
                quitGame();
            }
        }

        if (saveMenuOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("BButton"))
            {
                openMainMenu();
                playAudio();
            }
        }
    }

    private void playAudio()
    {
        audioData.Play(0);
    }
}
