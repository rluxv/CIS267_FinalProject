using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VendorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject buttonPrompt;

    [SerializeField] private GameObject buyMenu;
    private bool playerInRange;
    public static bool menuOpen;

    [SerializeField] private TMP_Text Item1Text, Item2Text, Item3Text, BalanceText;
    [SerializeField] private GameObject ArrowText;

    private int selected;
    private bool ctrlrHold;
    void Start()
    {
        playerInRange = false;
        menuOpen = false;
        selected = 0;
        ctrlrHold = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            getInput(false);
            controllerInput();
        }
    }

    private void controllerInput()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            buttonPrompt.SetActive(true);
            playerInRange = true;
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            buttonPrompt.SetActive(false);
            playerInRange = false;
        }
    }

    private void getInput(bool ctrlPress)
    {
        if(!menuOpen && Input.GetButtonDown("AButton") || Input.GetKeyDown(KeyCode.Return))
        {
            menuOpen = true;
            buyMenu.SetActive(true);
            Time.timeScale = 0f;
            buttonPrompt.SetActive(false);
        }
        if (menuOpen && Input.GetButtonDown("BButton") || Input.GetKeyDown(KeyCode.Escape))
        {
            menuOpen = false;
            Time.timeScale = 1f;
            buyMenu.SetActive(false);
            buttonPrompt.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.S) || (ctrlPress && Input.GetAxis("Vertical") == -1) && menuOpen)
        {
            if(selected == 0)
            {
                selected = 1;
                ArrowText.GetComponent<RectTransform>().anchoredPosition = Item2Text.GetComponent<RectTransform>().anchoredPosition;
            }
            else if(selected == 1)
            {
                selected = 2;
                ArrowText.GetComponent<RectTransform>().anchoredPosition = Item3Text.GetComponent<RectTransform>().anchoredPosition;
            }
            else if(selected == 2)
            {
                selected = 0;
                ArrowText.GetComponent<RectTransform>().anchoredPosition = Item1Text.GetComponent<RectTransform>().anchoredPosition;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || (ctrlPress && Input.GetAxis("Vertical") == 1) && menuOpen)
        {
            if (selected == 0)
            {
                selected = 2;
                ArrowText.GetComponent<RectTransform>().anchoredPosition = Item3Text.GetComponent<RectTransform>().anchoredPosition;
            }
            else if(selected == 1)
            {
                selected = 0;
                ArrowText.GetComponent<RectTransform>().anchoredPosition = Item1Text.GetComponent<RectTransform>().anchoredPosition;
            }
            else if (selected == 2)
            {
                selected = 1;
                ArrowText.GetComponent<RectTransform>().anchoredPosition = Item2Text.GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }
}
