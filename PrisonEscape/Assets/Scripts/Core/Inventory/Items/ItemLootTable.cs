using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemLootTable : MonoBehaviour
{
    //  this is the total ammount of items that can be looted from a bed
    //  it determines the number that the random range will check up to.
    private const int totalPossibleItems = 3;

    //  variables to alter loot pool
    private string currentSceneName;
    private string conditions;

    private GameManager_v2 gameManagerScriptReference;

    private void Start()
    {
        gameManagerScriptReference = GameObject.FindGameObjectsWithTag("gameManager")[0].GetComponent<GameManager_v2>();
        conditions = "None";
        //updateCurrentLevelForLoot();
            
    }
    // LootBedScript call this
    //  then it decides the proper loot and at what % rates
    //  then adds it directly

    //  ***  any new items will need to be inserted.


    public void updateCurrentLevelForLoot()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

    }

    public void testing()
    {

        Debug.Log("Worked");
    }


    public void drawFromLootTable()
    {



        //  conditions will simply be extra checks
        //  for example -> conditions = "level3" thus the loot pool for each level can vary, better loot on level 3 than level 1


        if (conditions == "onlyGetWater")
        {

            gameManagerScriptReference.GetPlayer().getInventory().AddItem(new Water());
        }
        else
        {
            int i = Random.Range(0, totalPossibleItems);
            if (i == 0)
            {
                gameManagerScriptReference.GetPlayer().getInventory().AddItem(new Water());
            }
            else if (i == 1)
            {
                gameManagerScriptReference.GetPlayer().getInventory().AddItem(new BrassKnuckles());
            }
            else if (i == 2)
            {
                gameManagerScriptReference.GetPlayer().getInventory().AddItem(new GuardBaton());
            }
        }

        



    }

    



}
