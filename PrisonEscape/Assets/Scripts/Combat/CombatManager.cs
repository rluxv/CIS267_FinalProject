using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CombatManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPlayerTurn;
    private bool canPlayerAttack;
    private int playerHealth, playerHealthMax;
    private int enemyHealth, enemyHealthMax;

    [SerializeField] private TMP_Text playerHealthTMP;
    [SerializeField] private TMP_Text enemyHealthTMP;

    void Start()
    {
        //for testing purposes, player health and enemy health will be passed to the scene later on
        playerHealth = 20;
        playerHealthMax = 20;

        enemyHealth = 20;
        enemyHealthMax = 20;


        isPlayerTurn = true;
        canPlayerAttack = true;

        updateHealthBars();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }
    
    private void updateHealthBars()
    {
        playerHealthTMP.SetText(playerHealth + "/" + playerHealthMax);
        enemyHealthTMP.SetText(enemyHealth + "/" + enemyHealthMax);

        if (isPlayerHealthLow())
        {
            playerHealthTMP.color = Color.red;
        }
        if (isEnemyHealthLow())
        {
            enemyHealthTMP.color = Color.red;
        }
    }

    private void getInput()
    {
        // we will also need to use Input.GetButtonDown for joystick controls
        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("AButton")) //A Button on joystick
        {
            Debug.Log("Attack Button (A) Pressed");
            if (isPlayerTurn && canPlayerAttack)
            {
                playerAttackEnemy();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Y) || Input.GetButtonDown("YButton")) //Y Button on joystick
        {
            Debug.Log("Item Button (Y) Pressed");
        }
        else if(Input.GetButtonDown("XButton"))
        {
            Debug.Log("X Button Pressed");

        }
        else if (Input.GetButtonDown("BButton"))
        {
            Debug.Log("B Button Pressed");

        }
    }

    private void playerAttackEnemy()
    {
        canPlayerAttack = false;
        // do attack & animations

        int damage = Random.Range(1, 4);
        enemyHealth -= damage;
        Debug.Log("Enemy Health: " + enemyHealth + "/" + enemyHealthMax);
        updateHealthBars();

        isPlayerTurn = false;

        //Add a delay to make it seem like the enemy is "thinking"
        if (!isEnemyDead())
        {
            Invoke("doEnemyTurn", 2);
        }

    }

    private void doEnemyTurn()
    {
        // do enemy attack
        // this will be a lot more complex too as the enemy will be able to do different moves
        //

        

        int damage = Random.Range(1, 4);
        playerHealth -= damage;
        Debug.Log("Player Health: " + playerHealth + "/" + playerHealthMax);
        updateHealthBars();

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
            enemyHealth = 0;
            return true;
        }
        else return false;
    }

    private bool isPlayerDead()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Player Defeated");
            playerHealth = 0;
            return true;
        }
        else return false;
    }

    private bool isPlayerHealthLow()
    {
        double percent = (double)playerHealth / (double) playerHealthMax;
        if(percent <= .20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool isEnemyHealthLow()
    {
        double percent = (double) enemyHealth / (double) enemyHealthMax;
        if (percent <= .20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}