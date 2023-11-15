using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    private float entityHealth;
    private float entityMaxHealth;

    public EntityBase(float health, float maxHealth = 100)
    {
        entityHealth = health;
        entityMaxHealth = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
