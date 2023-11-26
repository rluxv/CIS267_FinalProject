using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{

   
    private Vector2 player;
    private bool active;
    public float MovementSpeed;
    public GameObject[] path;
    private int pathLength;
    private int pathPos;
    // Start is called before the first frame update
    void Start()
    {
        
        active = false;
       pathLength = 0;
        pathPos = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            pursuit();
        }
        else
        {
            route();
        }
        restart();
        
    }


    private void route()
    {
        Vector2 guard = transform.position;
        Vector2 pathV = path[pathPos].transform.position;

        pathLength = path.Length;
        transform.position = Vector2.MoveTowards(transform.position, path[pathPos].transform.position, MovementSpeed * Time.deltaTime);
        if(guard == pathV)
        {
            pathPos++;
        }
        if(pathPos == path.Length)
        {
            pathPos = 0;
        }
    }

    private void pursuit()
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
