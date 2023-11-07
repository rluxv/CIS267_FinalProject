using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Weight size or item count?
    public float inventorySize;

    // Array list of items in the player possesion.
    public List<InventoryItem> items = new List<InventoryItem>();

    // Get the size of the inventory.
    public float GetSize()
    {
        return inventorySize;
    }

    // Get all of the items in the inventory.
    public List<InventoryItem> GetItems()
    {
        return items;
    }

    // Add an item to the players inventory.
    public void AddItem(string itemId)
    {
        if (itemId == ItemDictionary.Knife)
        {
            InventoryItem existingItem = DoesPlayerHaveItem(itemId);
            // If we have this item already && is stackable, increment the amount.
            if (existingItem != null && existingItem.IsStackable())
            {
                existingItem.SetItemAmount(existingItem.GetItemAmount() + 1);
            }
            // In the case we don't have this item currently add it.
            //
            // TODO: Find a one-to-one map for item id's and item classes.
            else
            {
                items.Add(new Knife());
            }
        }
    }

    // Check if a player has X amount of a certain item.
    // amount is optional defaults to 1.
    public InventoryItem DoesPlayerHaveItem(string itemId, int amount = 1)
    {
        // Loop through each inventory and determine if they have the specified amount.
        foreach (InventoryItem item in items)
        {
            if (item.GetItemId() == itemId && item.GetItemAmount() >= amount)
            {
                return item;
            }
        }

        return null;
    }
}
