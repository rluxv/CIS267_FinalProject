using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    // Item type will help us identify what this item is used for.
    //
    // e.x. Type 'Food' will allow us to determine if we should eat.
    private string itemType;

    // Item id will be the defined item type. Once the id is establish we shouldn't change it
    //
    // e.x. itemId = "WEAPON_KNIVE" or "FOOD_BACON"
    private string itemId;

    // We can set the number of this item the player has.
    private int itemAmount;

    // Determine if this item can be stacked with other.
    // We might not want to stack weapons.
    private bool isStackable = true;

    // Constructor to establish item.
    public InventoryItem(string iType, string id, int amount)
    {
        itemType= iType;
        itemId= id;
        itemAmount = amount;
    }

    // Set the item type.
    public void SetItemType(string type)
    {
        itemType = type;
    }

    // Get the type of the item.
    public string GetItemType()
    {
        return itemType;
    }

    // Get the item id.
    public string GetItemId() 
    {
        return itemId;
    }

    // Only accessable in this class or classes that are derived from this one.
    protected void SetItemId(string id)
    {
        itemId = id;
    }

    // Get the amount of this item we have.
    public int GetItemAmount()
    {
        return itemAmount;
    }

    // Set the item amount, this overides the entire amount.
    public void SetItemAmount(int amount)
    {
        itemAmount = amount;
    }

    // Get if a item is stackable with others.
    public bool IsStackable()
    {
        return isStackable;
    }

    // Only accessable in this class or classes that are derived from this one.
    protected void SetIsStackable(bool isStackable)
    {
        this.isStackable = isStackable;
    }

    public void UseItem()
    {
        // This must be in each inventory item. Any classes that are derived from this class can
        // override this method.
        Debug.Log("INVENTORY: using item " + this.GetItemId());
    }
}
