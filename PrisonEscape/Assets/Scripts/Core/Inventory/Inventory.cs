using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    // Inventory size is number of items they can hold. Default = 10 items.
    public int inventorySize;

    public Inventory()
    {
        inventorySize = Config.DEFAULT_INVENTORY_SIZE;
    }
}
