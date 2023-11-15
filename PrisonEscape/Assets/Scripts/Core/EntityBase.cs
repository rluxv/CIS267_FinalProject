using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    private float entityHealth;
    private float entityMaxHealth;

    void Start()
    {
        entityHealth = Config.DEFAULT_ENTITY_HEALTH;
        entityMaxHealth = Config.DEFAULT_ENTITY_HEALTH;
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
