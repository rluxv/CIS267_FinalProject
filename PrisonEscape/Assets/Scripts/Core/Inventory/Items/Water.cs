﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
class Water : InventoryItem
{

    public Water()
    {
        itemId = Config.ITEM_WATER;
        amount = 1;
        name = "Water";
        isStackable= false;
        
    }

    public override void Use()
    {
        // Debug.Log(player.getBalance() + "balance");

        // Remove the item from the inventory.
        Debug.Log("used water");
        this.GetInventory().RemoveItem(this.index, 1);
    }
}

