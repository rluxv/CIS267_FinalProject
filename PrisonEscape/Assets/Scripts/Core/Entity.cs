using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Entity class will be used for holding player-entity realted data. Most player-based entities like inmates, guards, and the player
 * will have the same base level information like health and name. We will use this to make managing that information easier.
 * 
 * If you think the value will be used for players and inmates then put it in here or vice versa.  
 */
public class Entity 
{
    private float health;
    private string name;

    public Entity(string name)
    {
        this.name = name;
        health = 100f;
    }

}
