using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject buttonPrompt;

    [SerializeField] private GameObject buyMenu;
    private bool playerInRange;
    private bool menuOpen;
    void Start()
    {
        playerInRange = false;
        menuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            getInput();
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

    private void getInput()
    {
        if(!menuOpen && Input.GetButtonDown("AButton"))
        {
            menuOpen = true;
            buyMenu.SetActive(true);
            Time.timeScale = 0f;
            buttonPrompt.SetActive(false);
        }
        if (menuOpen && Input.GetButtonDown("BButton"))
        {
            menuOpen = false;
            Time.timeScale = 1f;
            buyMenu.SetActive(false);
            buttonPrompt.SetActive(true);
        }
    }
}
