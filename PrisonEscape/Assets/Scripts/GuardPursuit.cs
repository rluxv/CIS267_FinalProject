using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPursuit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private PlayerTrail trail;
    private Vector2 Target;
    private Vector2[] test;
    private int pos;
    void Start()
    {
        trail = player.GetComponent<PlayerTrail>();
        test = new Vector2[10];
        pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        logTrailPositions();
        pursuit();
    }

    private void pursuit()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, 3 * Time.deltaTime);
    }

    private void logTrailPositions()
    {
        if(trail.getTrailPos() != null )
        {
            Target = trail.getTrailPos();
            
            Debug.Log(trail.getTrailPos());
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
