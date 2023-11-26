using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
class Water : InventoryItem
{
  

    public Water()
    {
        itemId = Config.ITEM_WATER;
        amount = 1;
        name = "Water";
        isStackable= true;
        
    }

    public void Use(PlayerManager player)
    {
        Debug.Log(player.getBalance());

        // Remove the item from the inventory.
        this.inventory.RemoveItem(this.index, 1);
    }
}

