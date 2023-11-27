using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    public GameObject trail;
    private Vector2[] objectPositions;
    public float timer;
    private float maxTime;
    private int pos;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = timer;
        pos =0;
    }

    // Update is called once per frame
    void Update()
    {
        timerTick();

    }

    private void PlaceTrail()
    {
        GameObject spawnedObject = Instantiate(trail);
        spawnedObject.transform.position  = PlayerPos.getPlayerPos();
        
    }

    private void timerTick()
    {
        timer = timer - Time.deltaTime;
        if(timer < 0)
        {
            PlaceTrail();
            timer = maxTime;
           
                
        }
        Debug.Log("Timer: " + timer);
    }

    public Vector2 getTrailPositions(int i)
    {
        return objectPositions[i];
    }
}
