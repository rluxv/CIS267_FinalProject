using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
class GuardBaton : InventoryItem
{
    
    public GuardBaton()
    {

        itemId = Config.ITEM_GUARD_BATON;
        amount = 1;
        name = "Guard Baton";
        isStackable = false;
        maxUses = 2;
        numUses = 0;


    }


    public override void Use()
    {
        if(numUses < maxUses)
        {
            Debug.Log("Used Guard Baton");
            numUses++;

        }
        else
        {
            Debug.Log("Reached max uses");

        }
        //this.GetInventory().RemoveItem(this.index, 1);
    }



}
