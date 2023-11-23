using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    // Inventory size is number of items they can hold. Default = 10 items.
    public int inventorySize;

    // Inventory Items
    private List<InventoryItem> items;

    public Inventory()
    {
        inventorySize = Config.DEFAULT_INVENTORY_SIZE;
        items = new List<InventoryItem>();
    }

    public void AddItem(InventoryItem item)
    {
        // Check if we have the item.
        if (HasItem(item))
        {
            int? itemIndex = GetItemIndex(item);

            /**
             * Update the item amount if the item
             * is stackable.
             */
        }
        else
        {
            // Add the new items to the list.
            items.Add(item);
        }
    }

    public bool HasItem(InventoryItem _item)
    {
        foreach (InventoryItem item in items) 
        {
            if (item.itemId.Equals(item.itemId))
            {
                return true;
            }
        }

        return false;
    }

    private Nullable<int> GetItemIndex(InventoryItem _item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemId.Equals(_item.itemId))
            {
                return i;
            }
        }

        return null;
    }
}
