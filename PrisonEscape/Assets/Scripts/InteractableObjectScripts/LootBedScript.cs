using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBedScript : MonoBehaviour
{
    //  player in range
    private bool canPlayerInteract;
    private GameObject buttonPrompt;
    private bool isLooted;
    private SpriteRenderer bedSpriteRenderer;
    public Sprite postLootSprite;
    // Start is called before the first frame update
    void Start()
    {
        bedSpriteRenderer = GetComponent<SpriteRenderer>();
        buttonPrompt = transform.GetChild(0).gameObject;
        canPlayerInteract = false;
        buttonPrompt.SetActive(false);
        isLooted = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (canPlayerInteract && !isLooted)
        {
            //  something
            CheckForLooting();
        }


    }
    private void CheckForLooting()
    {
        if (Input.GetButtonDown("AButton") || Input.GetKeyDown(KeyCode.Return))
        {
            //  bed is looted, Change its sprite, give the player some item, and disable the button Prompt
            isLooted = true;
            buttonPrompt.SetActive(false);
            bedSpriteRenderer.sprite = postLootSprite;
            GameObject.FindGameObjectsWithTag("gameManager")[0].GetComponent<GameManager_v2>().GetPlayer().getInventory().AddItem(new Water());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isLooted)
            {
                buttonPrompt.SetActive(true);
                canPlayerInteract = true;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isLooted)
            {
                buttonPrompt.SetActive(false);
                canPlayerInteract = false;
            }
        }
    }
}
