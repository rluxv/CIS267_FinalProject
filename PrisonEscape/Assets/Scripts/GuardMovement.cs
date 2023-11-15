using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{
    int pos;
    public Vector2[] positions;
    // Start is called before the first frame update
    void Start()
    {
        pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        verticalMovement();
    }

    private void verticalMovement()
    {
        
            transform.position = Vector2.MoveTowards(transform.position, positions[pos], 2 * Time.deltaTime);
        if(transform.position.y == positions[pos].y)
        {
            pos++;
        }
        if(pos == positions.Length)
        {
            pos = 0;
        }
    }
}
