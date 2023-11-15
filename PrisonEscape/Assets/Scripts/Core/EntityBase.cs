using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase
{
    private float entityHealth;
    private float entityMaxHealth;

    public EntityBase(float health, float maxHealth = 100)
    {
        entityHealth = health;
        entityMaxHealth = maxHealth;
    }

    public void SetEntityHealth(float health)
    {
        entityHealth = health;
    }

    public float GetEntityHealth()
    {
        return entityHealth;
    }
}
