using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Entity base provides the plaeyr with basic entity properties
    private EntityBase entity;
    public GameObject obj;

    // Set the players inventory.
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        entity = new EntityBase(Config.DEFAULT_ENTITY_HEALTH);
        obj = this.gameObject;
        inventory = new Inventory();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(float health)
    {
        entity.SetEntityHealth(health);
    }

    public float GetHealth()
    {
        return entity.GetEntityHealth();
    }
}
