using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : InventoryItem
{
    // Establish the knife class here.
    public Knife(int amount = 0) : base(ItemTypeDictionary.Weapon, ItemDictionary.Knife, amount)
    {
        // This item is not stackable.
        this.SetIsStackable(false);
    }

    // We will have to define what data we need passed here.
    //
    // e.x. Maybe the game manager or the player.
    public new void UseItem()
    {
        Debug.Log("INVENTORY: Using knife to stab.");
    }
}
