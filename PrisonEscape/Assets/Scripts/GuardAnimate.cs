using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAnimate : MonoBehaviour
{
    private Animator animator;
    private Vector3 previousPosition;
    private bool up, down, left, right;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        up = false;
        down = false;
        left = false;
        right = false;
    }

    // Update is called once per frame
    void Update()
    {
        getDirection();
        setDirection();
    }

    private void setDirection()
    {
        
        //up and down
        if (up)
        {
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
        }
        else if (down)
        {
            animator.SetBool("Down", true);
            animator.SetBool("Up", false);
        }
        else
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }

        //left and right
        if (right)
        {
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else if (left)
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        }
        else
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }
    }

    private void getDirection()
    {
        Vector3 currentDirection = (transform.position - previousPosition).normalized;
        Debug.Log(currentDirection);
        previousPosition = transform.position;

        //Direction checking--------------
        if (currentDirection.x > .9) 
        {
            right = true;
            Debug.Log("Right" + right);
        }
        else {right = false;}
        //--------------------------------
        if (currentDirection.x < -.9)
        {
            left = true;
            Debug.Log("left" + left);
        }
        else
        {   left = false;}
        //------------------------------
        if (currentDirection.y > .9)
        {
            up = true;
            Debug.Log("up" + up);
        }
        else { up = false; }
        //-------------------------------
        if (currentDirection.y < -.9)
        {
            down = true;
            Debug.Log("down" + down);
        }
        else { down = false; }
    }
}
