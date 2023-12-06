using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
class AdrenalineShot : InventoryItem
{

    public AdrenalineShot()
    {
        itemId = Config.ITEM_ADRENALINE_SHOT;
        amount = 1;
        name = "Adrenaline Shot";
        isStackable= false;
        
    }

    public override void Use()
    {
        // Debug.Log(player.getBalance() + "balance");

        // Remove the item from the inventory.
        Debug.Log("used adrenaline shot");
        this.GetInventory().RemoveItem(this.index, 1);
    }
}

