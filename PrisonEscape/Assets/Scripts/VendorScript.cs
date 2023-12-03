using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VendorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject buttonPrompt;

    [SerializeField] private GameObject buyMenu;
    private GameManager_v2 GameManager;

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
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager_v2>();
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
            BalanceText.SetText("Balance: " + GameManager.GetPlayer().getBalance());
        }
        if (menuOpen && Input.GetButtonDown("BButton") || Input.GetKeyDown(KeyCode.Escape))
        {
            menuOpen = false;
            Time.timeScale = 1f;
            buyMenu.SetActive(false);
            buttonPrompt.SetActive(true);
            
        }
        if (menuOpen && Input.GetButtonDown("AButton") || Input.GetKeyDown(KeyCode.Return))
        {
            if(selected == 0)
            {
                //buy water
                if(GameManager.GetPlayer().getBalance() >= 4)
                {
                    GameManager.GetPlayer().getInventory().AddItem(new Water());
                    GameManager.GetPlayer().setBalance(GameManager.GetPlayer().getBalance() - 4);
                    Debug.Log("Bought water");
                }
            }
            else if(selected == 1)
            {
                //buy brass knuckles
                if (GameManager.GetPlayer().getBalance() >= 8)
                {
                    GameManager.GetPlayer().getInventory().AddItem(new BrassKnuckles());
                    GameManager.GetPlayer().setBalance(GameManager.GetPlayer().getBalance() - 8);
                    Debug.Log("Bought brassknuckles");
                }
            }
            else if(selected == 2)
            {
                //buy baton
                if (GameManager.GetPlayer().getBalance() >= 8)
                {
                    GameManager.GetPlayer().getInventory().AddItem(new GuardBaton());
                    GameManager.GetPlayer().setBalance(GameManager.GetPlayer().getBalance() - 8);
                    Debug.Log("Bought baton");

                }
            }
            BalanceText.SetText("Balance: " + GameManager.GetPlayer().getBalance());

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
