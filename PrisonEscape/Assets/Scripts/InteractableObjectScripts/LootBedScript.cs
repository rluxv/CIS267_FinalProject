using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LootBedScript : MonoBehaviour
{
    //  player in range
    private bool canPlayerInteract;
    private GameObject buttonPrompt;
    private GameObject collectItemAnimationObject;
    private bool isLooted;
    private SpriteRenderer bedSpriteRenderer;
    public Sprite postLootSprite;
    private string itemReturnedSpriteName;

    // Start is called before the first frame update
    void Start()
    {
        bedSpriteRenderer = GetComponent<SpriteRenderer>();
        buttonPrompt = transform.GetChild(0).gameObject;
        collectItemAnimationObject = transform.GetChild(1).gameObject;
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


            //  Probably make an object that has every posible item in an array
            //  find it once
            //  draw a weighted random number, and return the respective item here
            //  then pass it where Water() is

            itemReturnedSpriteName = GameObject.FindGameObjectsWithTag("ItemLootTable")[0].GetComponent<ItemLootTable>().drawFromLootTable();

            collectItemAnimationObject.GetComponent<CollectItemAnimationControler>().startItemAnimation(itemReturnedSpriteName);

            //  all these on each bed is unessesary
            //int i = Random.Range(0, 3);
            //if (i == 0)
            //{
            //    GameObject.FindGameObjectsWithTag("gameManager")[0].GetComponent<GameManager_v2>().GetPlayer().getInventory().AddItem(new Water());
            //}
            //else if (i == 1)
            //{
            //    GameObject.FindGameObjectsWithTag("gameManager")[0].GetComponent<GameManager_v2>().GetPlayer().getInventory().AddItem(new BrassKnuckles());
            //}
            //else if (i == 2)
            //{
            //    GameObject.FindGameObjectsWithTag("gameManager")[0].GetComponent<GameManager_v2>().GetPlayer().getInventory().AddItem(new GuardBaton());
            //}


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
