using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Entity base provides the plaeyr with basic entity properties
    public EntityBase entity;
    public GameObject obj;

    // Set the players inventory.
    public Inventory inventory;
    private int balance;

    //  this is so level loaders can access the gameManager + script after colliding with the player
     public GameObject gameManagerObject;

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

    public float GetMaxHealth()
    {
        return entity.GetEntityMaxHealth();
    }

    public void SetMaxHealth(float maxhealth)
    {
        entity.SetEntityMaxHealth(maxhealth);
    }

    public int getBalance()
    {
        return balance;
    }

    public void setBalance(int bal)
    {
        balance = bal;
    }

    public void increaseBalance(int amt)
    {
        balance += amt;
    }

    public void decreaseBalance(int amt)
    {
        balance -= amt;
    }

    public GameObject getGameManagerObject()
    {
        return gameManagerObject;
    }
}
