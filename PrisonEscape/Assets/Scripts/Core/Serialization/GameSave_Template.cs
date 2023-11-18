using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameSave_Template
{
    // Add more to this class as you need. All properties should be public varibles.

    public string saveId;
    public string level;
    public Vector3 position;
    public float playerHealth;
    public Inventory playerInventory;
    public int coins;
}
