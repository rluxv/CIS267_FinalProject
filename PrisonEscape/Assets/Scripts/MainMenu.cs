using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject ArrowText;
    private TMP_Text ArrowTextTMP;
    private int selected;
    private bool ctrlrHold;

    private int textAnimPos;

    AudioSource audioData;
    public void Start()
    {
        selected = 0;
        ctrlrHold = false;
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
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || ctrlPress == true) 
        {
            Debug.Log("S or W key pressed");
            if(selected == 0)
            {
                selected = 1;
                Debug.Log("selected " + selected); 
                playAudio();
                ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            }
            else if (selected == 1)
            {
                selected = 0;
                Debug.Log("selected " + selected);
                playAudio();
                ArrowText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 100, 0);
                
            }
        }
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("AButton"))
        {
            if(selected == 0)
            {
                startGame();
            }
            else if(selected == 1)
            {
                quitGame();
            }
        }
    }

    private void playAudio()
    {
        audioData.Play(0);
    }
}
