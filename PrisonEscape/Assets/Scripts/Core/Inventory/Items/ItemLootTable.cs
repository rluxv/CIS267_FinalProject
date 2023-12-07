using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemLootTable : MonoBehaviour
{
    //  this is the total ammount of items that can be looted from a bed
    //  it determines the number that the random range will check up to.
    private const int totalPossibleItems = 6;

    //  variables to alter loot pool
    private string currentSceneName;
    private string conditions;
    private string itemReturned;

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


    public string drawFromLootTable()
    {

        itemReturned = "";

        //  conditions will simply be extra checks
        //  for example -> conditions = "level3" thus the loot pool for each level can vary, better loot on level 3 than level 1


        if (conditions == "onlyGetWater")
        {

            gameManagerScriptReference.GetPlayer().getInventory().AddItem(new Water());
        }
        else
        {
            int i = Random.Range(0, totalPossibleItems + 6);
            Debug.Log("Range = " + i);
            if (i == 0)
            {
                gameManagerScriptReference.GetPlayer().getInventory().AddItem(new Water());
                itemReturned = "water";
            }
            else if (i == 1)
            {
                gameManagerScriptReference.GetPlayer().getInventory().AddItem(new BrassKnuckles());
                itemReturned = "brassKnuckles";
            }
            else if (i == 2)
            {
                gameManagerScriptReference.GetPlayer().getInventory().AddItem(new GuardBaton());
                itemReturned = "guardBaton";
            }
            else if (i == 3)
            {
                gameManagerScriptReference.GetPlayer().getInventory().AddItem(new FirstAidKit());
                itemReturned = "firstAidKit";
            }
            else if (i == 4)
            {
                gameManagerScriptReference.GetPlayer().getInventory().AddItem(new AdrenalineShot());
                itemReturned = "adrenalineShot";
            }
            else if (i >= 5)
            {
                gameManagerScriptReference.GetPlayer().increaseBalance(Random.Range(1,3));
                itemReturned = "currency";
            }

           
        }

        
       return itemReturned;


    }

    



}
