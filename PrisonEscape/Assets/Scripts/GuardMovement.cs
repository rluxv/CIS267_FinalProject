using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{

   
    private Vector2 player;
    private bool active;
    public float MovementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
        active = true;
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(active)
        {
            movement();
        }
        restart();
    }

    private void movement()
    {
        player = PlayerPos.getPlayerPos();
        transform.position = Vector2.MoveTowards(transform.position, player, MovementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

            Debug.Log("Collision");
            active = false;
            
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
