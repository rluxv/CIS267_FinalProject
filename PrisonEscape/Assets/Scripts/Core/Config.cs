using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Config
{
    // Scene Keys
    public const string LEVEL_1 = "Level1";
    public const string LEVEL_2 = "Level2";
    public const string LEVEL_3 = "Level3";

    public const float DEFAULT_ENTITY_HEALTH = 20;
    public const string DEFAULT_SAVE_LEVEL = LEVEL_1;
    public static Vector3 DEFAULT_POSITION = Vector3.zero;
    public const int DEFAULT_INVENTORY_SIZE = 10;
    public const int STARTING_BALANCE = 5;

    // Inventory Items
    public const string ITEM_WATER = "ITEM.CONSUMABLE.WATER";
}
