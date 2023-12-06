using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
class FirstAidKit : InventoryItem
{

    public FirstAidKit()
    {
        itemId = Config.ITEM_FIRST_AID_KIT;
        amount = 1;
        name = "First Aid Kit";
        isStackable= false;
        
    }

    public override void Use()
    {
        // Debug.Log(player.getBalance() + "balance");

        // Remove the item from the inventory.
        Debug.Log("used first aid kit");
        this.GetInventory().RemoveItem(this.index, 1);
    }
}

