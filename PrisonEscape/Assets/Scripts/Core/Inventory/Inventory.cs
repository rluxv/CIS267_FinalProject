using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Inventory
{
    // Inventory size is number of items they can hold. Default = 10 items.
    public int inventorySize;

    // Inventory Items
    public List<InventoryItem> items;

    public Inventory()
    {
        inventorySize = Config.DEFAULT_INVENTORY_SIZE;
        items = new List<InventoryItem>();
    }

    public void AddItem(InventoryItem item)
    {
        int newId = items.Count + 1;

        item.index = newId;
        item.SetInventory(this);

        // Check if we have the item.
        /*if (HasItem(item))
        {
            int? itemIndex = GetItemIndex(item);

            if (itemIndex != null)
            {
                if (itemIndex >= items.Count) return;

                // If the item is stackable then we combine the amounts.
                if ((bool)items[(int)itemIndex].isStackable) 
                {
                    items[(int)itemIndex].amount = items[(int)itemIndex].amount + item.amount;
                }
                else
                {

                    items.Add(item);
                }
            }
        }
        else
        {
            // Add the new items to the list.
            items.Add(item);
        }*/
        items.Add(item);
    }

    public void RemoveItem(int index, int? amount)
    {
        InventoryItem item = GetItem<InventoryItem>(index);
        if (index >= items.Count) return;

        //if (item != null && amount != null && amount >= 1)
        //{
        //    items[(int)index].amount = items[(int)index].amount - amount;
        //}
        //else
        //{
        //    // Simply Remove the item.
        //    items.RemoveAt(index);
        //}
        items.RemoveAt(index);
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

    public T GetItem<T>(string itemId)
    {
        int? itemIndex = GetItemIndex(new InventoryItem(itemId));
        
        // Item was not found.
        if (itemIndex == null)
        {
            return default(T);
        }

        InventoryItem item = items.ElementAt((int)itemIndex);
        return JsonUtility.FromJson<T>(JsonUtility.ToJson(item)); ;

    }

    public T GetItem<T>(int itemIndex)
    {
        if (itemIndex >= items.Count) return default(T);

        InventoryItem item = items.ElementAt((int)itemIndex);
        return JsonUtility.FromJson<T>(JsonUtility.ToJson(item));

    }
}
