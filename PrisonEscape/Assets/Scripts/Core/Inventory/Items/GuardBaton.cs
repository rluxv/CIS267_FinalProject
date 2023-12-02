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



    }


    public override void Use()
    {
        Debug.Log("Used Guard Baton");
        this.GetInventory().RemoveItem(this.index, 1);
    }



}
