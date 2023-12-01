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
        
    }

    public override void Use()
    {
        // Debug.Log(player.getBalance() + "balance");

        // Remove the item from the inventory.
        Debug.Log("used brass knuckles");
        this.GetInventory().RemoveItem(this.index, 1);
    }
}

