using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPursuit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private PlayerTrail trail;
    private Vector2 Target;
    private int pos;
    private bool isTarget;
    void Start()
    {
        trail = player.GetComponent<PlayerTrail>();
      
        pos = 0;
        isTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        logTrailPositions();
        pursuit();
        
    }


    private void pursuit()
    {
        if (isTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target, 3 * Time.deltaTime);
        }
    }

    private void logTrailPositions()
    {
        
        
        
        if (trail.getTrailPos() == null)
        {
            isTarget = false;
        }
        else 
        {
            isTarget = true;
            Target = trail.getTrailPos();
        }
            
       
     
       
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTrail"))
        {
            Debug.Log("Collision");
            Destroy(collision.gameObject);
            
        }
    }

}
