using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CombatManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPlayerTurn;
    private bool canPlayerAttack;
    private int playerHealth, playerHealthMax;
    private int enemyHealth, enemyHealthMax;
    [SerializeField] private Transform enemyHeartAnim;
    [SerializeField] private Transform enemyAnimSpawner;
    [SerializeField] private TMP_Text playerHealthTMP;
    [SerializeField] private TMP_Text enemyHealthTMP;
    [SerializeField] private TMP_Text CoinsEarnedTMP;
    [SerializeField] private TMP_Text DamageGivenTMP;
    [SerializeField] private TMP_Text DamageTakenTMP;
    [SerializeField] private TMP_Text BonusCoinsTMP;
    [SerializeField] private GameObject PlayerActionsMenu;
    [SerializeField] private GameObject ItemsMenu;
    [SerializeField] private GameObject CombatEndMenu;
    [SerializeField] private TMP_Text[] ItemsTMP;
    [SerializeField] private TMP_Text ItemSelectorTMP;
    private Animator PlayerActionsMenuAnimator;
    private Animator ItemsMenuAnimator;
    private GameManager_v2 GameManager;
    private GameObject GameManagerObj;
    private GameObject DontDestroyOnLoadObj;
    private bool combatEndMenuOpen;
    private int balance;
    private int coinsEarned;
    private int damageTaken;
    private int damageGiven;
    private bool itemsMenuOpen;
    private bool ctrlrHold;
    private int selected;
    Inventory inventory;
    private int enemyItemsLeft;
    private int enemyAttackItemsLeft;
    private bool playerIsGuarding;
    [SerializeField] private TMP_Text guardingText;
    void Start()
    {
        guardingText.gameObject.SetActive(false);
        ctrlrHold = false;
        combatEndMenuOpen = false;
        itemsMenuOpen = false;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager_v2>();
        GameManagerObj = GameObject.Find("GameManager");
        DontDestroyOnLoadObj = GameObject.Find("DontDestroyOnLoad");
        // get inventory here, code below temporary
        inventory = GameManager.GetPlayer().getInventory();
        playerIsGuarding = false;
        //Add some items to the inventory for testing
        for (int i = 0; i < 10; i++)
        {
            Water it = new Water();
            inventory.AddItem(it);
            //Debug.Log(inventory.GetItem(i).name + " Inv");
        }
        updateItemsMenuList();


        //for testing purposes, player health and enemy health will be passed to the scene later on
        //playerHealth = playerManager.playerHealth;
        //playerHealthMax = playerManager.playerHealthMax;
        playerHealth = (int) GameManager.GetPlayer().GetHealth();
        playerHealthMax = (int)GameManager.GetPlayer().GetMaxHealth();
        balance = GameManager.GetPlayer().getBalance();

        enemyHealth = 20;
        enemyHealthMax = 20;

        //give the enemy 3 items
        enemyItemsLeft = 3;
        enemyAttackItemsLeft = 3;


        isPlayerTurn = true;
        canPlayerAttack = true;
        //PlayerActionsMenu.SetActive(true);
        PlayerActionsMenuAnimator = PlayerActionsMenu.GetComponent<Animator>();
        ItemsMenuAnimator = ItemsMenu.GetComponent<Animator>();
        
        PlayerActionsMenuAnimator.SetBool("canPlayerAttack", true);

        updateHealthBars();
        DontDestroyOnLoadObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        if (itemsMenuOpen)
        { 
            getItemsMenuInput(false);
            getItemsMenuControllerAxisInput();
        }
    }

    public void updateItemsMenuList()
    {
        for (int i = 0; i < 10; i++)
        {
            try
            {
                //Debug.Log("Item " + i + " :" + inventory.GetItem(i).name);
                ItemsTMP[i].SetText(inventory.GetItem<InventoryItem>(i).name);
            }
            catch (System.Exception e)
            {
                //Debug.Log("No Item at " + i);
                ItemsTMP[i].SetText("<Empty>");
            }

        }
    }
    
    private void updateHealthBars()
    {
        playerHealthTMP.SetText(playerHealth + "/" + playerHealthMax);
        enemyHealthTMP.SetText(enemyHealth + "/" + enemyHealthMax);

        if (isPlayerHealthLow())
        {
            playerHealthTMP.color = Color.red;
        }
        else
        {
            playerHealthTMP.color = Color.white;
        }
        if (isEnemyHealthLow())
        {
            enemyHealthTMP.color = Color.red;
        }
        else
        {
            enemyHealthTMP.color = Color.white;
        }
    }

    private void getItemsMenuInput(bool ctrlPress)
    {
        if(itemsMenuOpen)
        {
            if (Input.GetButtonDown("BButton"))
            {
                ItemsMenuAnimator.SetTrigger("FadeOut");
                selected = 0;
                ItemSelectorTMP.GetComponent<RectTransform>().anchoredPosition = ItemsTMP[selected].GetComponent<RectTransform>().anchoredPosition;
                Invoke("hideItemsMenu", (float)0.4);
            }
            if (Input.GetButtonDown("AButton") || Input.GetKeyDown(KeyCode.Return))
            {
                if (inventory.GetItem<InventoryItem>(selected).itemId == Config.ITEM_WATER)
                {
                    //Debug.Log("Used a water.");
                    inventory.GetItem<Water>(selected).Use();
                    updateItemsMenuList();
                    //Invoke("hideItemsMenu", (float)0.4);
                }
            }
            if (Input.GetKeyDown(KeyCode.S) || (ctrlPress && Input.GetAxis("Vertical") == -1))
            {
                if(selected < 9)
                {
                    selected++;
                    ItemSelectorTMP.GetComponent<RectTransform>().anchoredPosition = ItemsTMP[selected].GetComponent<RectTransform>().anchoredPosition;
                }
                else if(selected == 9)
                {
                    selected = 0;
                    ItemSelectorTMP.GetComponent<RectTransform>().anchoredPosition = ItemsTMP[selected].GetComponent<RectTransform>().anchoredPosition;
                }
               
            }
            else if (Input.GetKeyDown(KeyCode.W) || (ctrlPress && Input.GetAxis("Vertical") == 1))
            {
                if (selected > 0)
                {
                    selected--;
                    ItemSelectorTMP.GetComponent<RectTransform>().anchoredPosition = ItemsTMP[selected].GetComponent<RectTransform>().anchoredPosition;
                }
                else if (selected == 0)
                {
                    selected = 9;
                    ItemSelectorTMP.GetComponent<RectTransform>().anchoredPosition = ItemsTMP[selected].GetComponent<RectTransform>().anchoredPosition;
                }
            }
        } 
    }

    private void getItemsMenuControllerAxisInput()
    {
        if (Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
        {
            if (ctrlrHold == true)
            {
                // do nothing
            }
            else
            {
                getItemsMenuInput(true);
                ctrlrHold = true;
            }
        }
        else
        {
            ctrlrHold = false;
        }
    }    

    private void getInput()
    {
        if(!itemsMenuOpen)
        {
            if (combatEndMenuOpen)
            {
                if (Input.GetButtonDown("AButton") || Input.GetKeyDown(KeyCode.Return))
                {
                    endBattle();
                }
            }
            else
            {
                // we will also need to use Input.GetButtonDown for joystick controls
                if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("AButton")) //A Button on joystick
                {
                    
                    if (isPlayerTurn && canPlayerAttack)
                    {
                        playerAttackEnemy();
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Y) || Input.GetButtonDown("YButton")) //Y Button on joystick
                {
                    if (isPlayerTurn && canPlayerAttack)
                    {
                        loadItemsMenu();
                    }
                }
                else if (Input.GetButtonDown("XButton"))
                {
                    playerGuard();
                }
                else if (Input.GetButtonDown("BButton"))
                {
                   

                }
            }
        }
        
    }

    private void playerGuard()
    {
        playerIsGuarding = true;
        guardingText.gameObject.SetActive(true);
        //PlayerActionsMenu.SetActive(false);
        canPlayerAttack = false;
        PlayerActionsMenuAnimator.SetBool("canPlayerAttack", false);
        // do attack & animations

        updateHealthBars();

        isPlayerTurn = false;

        //Add a delay to make it seem like the enemy is "thinking"
        if (!isEnemyDead())
        {
            Invoke("doEnemyTurn", 2);
        }
    }

    private void hideItemsMenu()
    {
        ItemsMenu.SetActive(false);
        itemsMenuOpen = false;
    }

    public void loadItemsMenu()
    {
        ItemsMenu.SetActive(true);
        itemsMenuOpen = true;
    }

    private void playerAttackEnemy()
    {
        //PlayerActionsMenu.SetActive(false);
        canPlayerAttack = false;
        PlayerActionsMenuAnimator.SetBool("canPlayerAttack", false);
        // do attack & animations

        int damage = Random.Range(1, 4);
        damageGiven += damage;
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
        if(((float)enemyHealth / (float)enemyHealthMax) <= .2 && enemyItemsLeft != 0) // if enemy health is low and we have a healing item, prioritize healing
        {
            Debug.Log("Enemy health " + ((float)enemyHealth / (float)enemyHealthMax));
            Debug.Log("Prioritizing healing");
            Instantiate(enemyHeartAnim, enemyAnimSpawner.position, Quaternion.identity);
            // use a health item
            enemyItemsLeft--;
            int healAmt = Random.Range(3, enemyHealthMax);
            enemyHealth += healAmt;
            if (enemyHealth >= enemyHealthMax)
            {
                enemyHealth = enemyHealthMax;
            }
        }
        else if(playerHealth / playerHealthMax <= .2) // if player health is low prioritize attacking
        {
            int damage = Random.Range(1, 4);
            if(playerIsGuarding)
            {
                damage = damage / 2;
            }
            damageTaken += damage;
            playerHealth -= damage;
        }
        else
        {
            // make a random decision
            int decisionToMake = Random.Range(1, 4);

            if(decisionToMake == 1) //1 = use health item
            {
                if(enemyItemsLeft != 0)
                {
                    // use a health item
                    Instantiate(enemyHeartAnim, enemyAnimSpawner.position, Quaternion.identity);
                    enemyItemsLeft--;
                    int healAmt = Random.Range(3, enemyHealthMax);
                    enemyHealth += healAmt;
                    if (enemyHealth >= enemyHealthMax)
                    {
                        enemyHealth = enemyHealthMax;
                    }
                }
                else
                {
                    decisionToMake = Random.Range(2, 4);
                }
            }
            if(decisionToMake == 2) // 2 = use attack item (stronger damage)
            {
                if(enemyAttackItemsLeft != 0)
                {
                    enemyAttackItemsLeft--;
                    int damage = Random.Range(4, 9);
                    if (playerIsGuarding)
                    {
                        damage = damage / 2;
                    }
                    damageTaken += damage;
                    playerHealth -= damage;
                }
                else
                {
                    decisionToMake = 3;
                }
            }
            if(decisionToMake == 3) // 3 = attack
            {
                int damage = Random.Range(1, 4);
                if (playerIsGuarding)
                {
                    damage = damage / 2;
                }
                damageTaken += damage;
                playerHealth -= damage;
            }
        }
        updateHealthBars();
        guardingText.gameObject.SetActive(false);
        if (!isPlayerDead())
        {
            playerIsGuarding = false;
            isPlayerTurn = true;
            canPlayerAttack = true;
            PlayerActionsMenuAnimator.SetBool("canPlayerAttack", true);
            //PlayerActionsMenu.SetActive(true);
        }

    }

    private bool isEnemyDead()
    {
        if (enemyHealth <= 0)
        {
            Debug.Log("Enemy Defeated");
            enemyHealth = 0;
            updateHealthBars();

            // proof of concept keeping health between scenes
            //playerManager.playerHealth = playerHealth;
            StartCoroutine(loadCombatEndMenu());
            //loadCombatEndMenu();
            return true;
        }
        else return false;
    }

    public void endBattle()
    {
        DontDestroyOnLoadObj.SetActive(true);
        GameManager.GetPlayer().SetHealth(playerHealth);
        GameManager.GetPlayer().increaseBalance(coinsEarned);
        GameManager.GetPlayer().setInventory(inventory);
        //We will change this to the scene the player was previously in
        SceneManager.LoadScene(GameManager_v2.PreviousScene);
    }

    IEnumerator loadCombatEndMenu()
    {
        yield return new WaitForSeconds(.450F);
        combatEndMenuOpen = true;
        CombatEndMenu.SetActive(true);
        PlayerActionsMenu.SetActive(false);
        coinsEarned = Random.Range(2, 6);
        
        DamageGivenTMP.SetText("Damage Given: " + damageGiven);
        DamageTakenTMP.SetText("Damage Taken: " + damageTaken);
        CoinsEarnedTMP.SetText("Coins Earned: " + coinsEarned);

        yield return new WaitForSeconds(.250F);
        CoinsEarnedTMP.gameObject.SetActive(true);

        yield return new WaitForSeconds(.250F);
        DamageTakenTMP.gameObject.SetActive(true);
        yield return new WaitForSeconds(.250F);
        DamageGivenTMP.gameObject.SetActive(true);
        if (damageGiven > damageTaken)
        {
            // coin bonus if you gave more damage than you took
            int bonusCoins = Random.Range(3, 5);
            coinsEarned += 4;
            yield return new WaitForSeconds(.250F);
            BonusCoinsTMP.SetText("Coin Bonus: " + bonusCoins);
            BonusCoinsTMP.gameObject.SetActive(true);
        }
        balance += coinsEarned;


    }

    private bool isPlayerDead()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Player Defeated");
            playerHealth = 0;
            updateHealthBars();
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
