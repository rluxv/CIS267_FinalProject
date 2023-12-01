using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    public float movementSpeed;
    private float inputHorizontal, inputVertical;
    private Animator animator;
    public float sprintBoost;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        PlayerPos.CanMove(true);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        playerAnimate();
        playerStopCheck();
        shortcut();
    }

   

    private void shortcut()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("SampleScene");
            
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void playerStopCheck()
    {
        if(PlayerPos.CanMove() == false)
        {
            player.velocity = Vector3.zero;
            inputVertical = 0;
            inputVertical = 0;
            animator.SetBool("Moving", false);
        }
    }

    private void playerAnimate()
    {
        if(inputHorizontal != 0 || inputVertical != 0) 
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        //up and down
       if(inputVertical > 0)
        {
            animator.SetBool("MovingUp", true);
            animator.SetBool("MovingDown", false);
        }
        else if(inputVertical <0) 
        { 
            animator.SetBool("MovingDown", true);
            animator.SetBool("MovingUp", false);
        }
        else
        {
            animator.SetBool("MovingUp", false);
            animator.SetBool("MovingDown", false);
        }

        //left and right
        if (inputHorizontal > 0)
        {
            animator.SetBool("MovingRight", true);
            animator.SetBool("MovingLeft", false);
        }
        else if (inputHorizontal <0)
        {
            animator.SetBool("MovingLeft", true);
            animator.SetBool("MovingRight", false);
        }
        else
        {
            animator.SetBool("MovingRight", false);
            animator.SetBool("MovingLeft", false);
        }
    }
    
       
    private void move()
    {
        if (PlayerPos.CanMove())
        {
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");
            //Debug.Log(inputHorizontal + " " + inputVertical);   
            player.velocity = new Vector2(movementSpeed * inputHorizontal, movementSpeed * inputVertical); ;
            sprint();
            PlayerPos.setPlayerPosX(transform.position.x);
            PlayerPos.setPlayerPosY(transform.position.y);
            PlayerPos.setPlayerPos(transform.position);
        }
        

        
    }
    private void sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) )
        {
            Debug.Log("Sprinting activated");
            movementSpeed += sprintBoost;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed -= sprintBoost;
            Debug.Log("Sprinting deactivated");
        }
    }

}
