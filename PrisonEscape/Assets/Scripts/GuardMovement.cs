using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardMovement : MonoBehaviour
{

 
    private Vector2 player;
    private bool active;
    public float MovementSpeed;
    public GameObject[] path;
    private int pathLength;
    private int pathPos;
    private bool Switch;


    // Start is called before the first frame update
    void Start()
    {
        
        active = false;
       pathLength = 0;
        pathPos = 0;    
        Switch = false;
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
       


        if (guard == pathV && !Switch)
        {
            pathPos++;
        }
        if(pathLength == pathPos)
        {
            pathPos --;
            Switch = true;  
        }
        if (guard == pathV && Switch && pathPos != 0)
        {
            pathPos--;
        }
        if(pathPos == 0)
        {
            
            Switch = false;
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

            SceneManager.LoadScene("CombatScene");
            GameManager_v2.PreviousScene = this.gameObject.scene.name;
            Destroy(this.gameObject);
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
