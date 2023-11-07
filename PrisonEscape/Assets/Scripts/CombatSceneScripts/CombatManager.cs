using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    private bool player_turn;
    public GameObject combatMenu;
    private JoystickInputs joystickInputs;
    private InputAction input;
    private Animator combatAnimator;

    void Start()
    {
        joystickInputs = new JoystickInputs();
        joystickInputs.Buttons.ActionButton.performed += Attack;
        joystickInputs.Buttons.ActionButton.Enable();
        combatAnimator = combatMenu.GetComponent<Animator>();


        player_turn = true;
        gameManager = GameObject.Find("GameManager");
        Debug.Log(gameManager.GetComponent<TestScript>().testInt + " value");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        if(player_turn)
        {
            Debug.Log("Performing Attack");
            combatAnimator.SetBool("isPlayerTurn", false);
            player_turn = false;
            
            
        }
        
    }
}
