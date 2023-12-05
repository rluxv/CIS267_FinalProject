using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
class BrassKnuckles : InventoryItem
{

    public BrassKnuckles()
    {
        itemId = Config.ITEM_BRASS_KNUCKLES;
        amount = 1;
        name = "Brass Knuckles";
        isStackable= false;
        maxUses = 2;
        numUses = 0;
    }

    public override void Use()
    {
        if (numUses < maxUses)
        {
            Debug.Log("Used Brass Knuckles");
            numUses = numUses + 1;

        }
        else
        {
            Debug.Log("Reached max uses");

        }
    }
}

