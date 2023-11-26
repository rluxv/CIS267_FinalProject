using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : ItemInterface
{
    public string itemId;
    public string name;
    public int? amount;
    public bool? isStackable;
    public Inventory inventory;
    public int index;

    public InventoryItem()
    { }

    public InventoryItem(string itemId)
    {
        this.itemId = itemId;
    }

    public void Use()
    {
        throw new System.NotImplementedException();
    }
}
