using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Entity base provides the plaeyr with basic entity properties
    public EntityBase entity;
    public GameObject obj;

    // Set the players inventory.
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        //entity = GetComponent<EntityBase>();
        obj = this.gameObject;
        inventory = new Inventory();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void test()
    {
        Debug.Log("test");
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
