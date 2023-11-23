using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool active;
    public float MovementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            verticalMovement();
            HorizontalMovement();
        }
        restart();
    }

    private void HorizontalMovement()
    {
        if (PlayerPos.getPlayerPosX() > transform.position.x)
        {
            rb.velocity = new Vector2(MovementSpeed, rb.velocity.y);

        }
        if (PlayerPos.getPlayerPosX() < transform.position.x)
        {
            rb.velocity = new Vector2(-MovementSpeed, rb.velocity.y);

        }
    }
    private void verticalMovement()
    {
        if (PlayerPos.getPlayerPosY() > transform.position.y)
        {
            rb.velocity = new Vector2(rb.velocity.x, MovementSpeed);

        }else if (PlayerPos.getPlayerPosY() < transform.position.y)
        {
            rb.velocity = new Vector2(rb.velocity.x, -MovementSpeed);
        }
        
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

            Debug.Log("Collision");
            active = false;
            rb.velocity = Vector2.zero;
        }
    }

    private void restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            active = true;
        }
        
    }
}
