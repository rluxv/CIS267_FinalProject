using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    public float movementSpeed;
    private float inputHorizontal, inputVertical;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        playerAnimate();
    }
    private void playerAnimate()
    {
       if(inputVertical == 1)
        {
            animator.SetBool("MovingUp", true);
            animator.SetBool("MovingDown", false);
        }
        else if(inputVertical == -1) 
        { 
            animator.SetBool("MovingDown", true);
            animator.SetBool("MovingUp", false);
        }
        else
        {
            animator.SetBool("MovingUp", false);
            animator.SetBool("MovingDown", false);
        }
    }
    
       
    private void move()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        //Debug.Log(inputHorizontal + " " + inputVertical);   
        player.velocity = new Vector2(movementSpeed * inputHorizontal, movementSpeed * inputVertical); ;

        GameManager.setPlayerPosX(transform.position.x);
        GameManager.setPlayerPosY(transform.position.y);

        
    }

    
}
