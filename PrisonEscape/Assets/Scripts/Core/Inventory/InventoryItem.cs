using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem : ItemInterface
{
    public string itemId;
    public string name;
    public int? amount;
    public bool? isStackable;
    private Inventory inventory;
    public int index;
    public int maxUses;
    public int numUses;

    public InventoryItem()
    {
        amount = 1;
    }

    public InventoryItem(string itemId)
    {
        this.itemId = itemId;
    }

    public virtual void Use()
    {
        throw new System.NotImplementedException();
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public Inventory GetInventory()
    {
        return this.inventory;
    }
}
