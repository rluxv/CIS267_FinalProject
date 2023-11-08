using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CombatManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPlayerTurn;
    private bool canPlayerAttack;
    private int playerHealth, playerHealthMax;
    private int enemyHealth, enemyHealthMax;
    void Start()
    {
        //for testing purposes, player health and enemy health will be passed to the scene later on
        playerHealth = 20;
        playerHealthMax = 20;

        enemyHealth = 20;
        enemyHealthMax = 20;


        isPlayerTurn = true;
        canPlayerAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void getInput()
    {
        // we will also need to use Input.GetButtonDown for joystick controls
        if (Input.GetKeyDown(KeyCode.A)) //A Button on joystick
        {
            Debug.Log("Attack Button Pressed");
            if (isPlayerTurn && canPlayerAttack)
            {
                playerAttackEnemy();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Y)) //Y Button on joystick
        {
            Debug.Log("Item Button Pressed");
        }
    }

    private void playerAttackEnemy()
    {
        canPlayerAttack = false;
        // do attack & animations

        int damage = Random.Range(1, 4);
        enemyHealth -= damage;
        //This prevents health from going below 0 or above the max
        Mathf.Clamp(enemyHealth, 0, enemyHealthMax);
        Debug.Log("Enemy Health: " + enemyHealth + "/" + enemyHealthMax);

        isPlayerTurn = false;

        if(!isEnemyDead()) doEnemyTurn();

    }

    private void doEnemyTurn()
    {
        // do enemy attack
        // this will be a lot more complex too as the enemy will be able to do different moves
        //
        int damage = Random.Range(1, 4);
        playerHealth -= damage;
        //This prevents health from going below 0 or above the max
        Mathf.Clamp(playerHealth, 0, playerHealthMax);
        Debug.Log("Player Health: " + playerHealth + "/" + playerHealthMax);

        if (!isPlayerDead())
        {
            isPlayerTurn = true;
            canPlayerAttack = true;
        }

    }

    private bool isEnemyDead()
    {
        if (enemyHealth <= 0)
        {
            Debug.Log("Enemy Defeated");
            return true;
        }
        else return false;
    }

    private bool isPlayerDead()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Player Defeated");
            return true;
        }
        else return false;
    }

}
