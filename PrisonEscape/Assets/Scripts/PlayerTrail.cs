using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    public GameObject trail;
    GameObject spawnedObject;
    private Vector2[] objectPositions;
    private List<Vector2> objectPositionsList;
    public float timer;
    private float maxTime;
    private int pos;
    // Start is called before the first frame update
    void Start()
    {
        objectPositionsList = new List<Vector2>();
        maxTime = timer;
        PlaceTrail();
        pos =0;
    }

    // Update is called once per frame
    void Update()
    {
        timerTick();

    }

    private void PlaceTrail()
    {
        spawnedObject = Instantiate(trail);
        spawnedObject.transform.position  = PlayerPos.getPlayerPos();
        
        pos++;
        //Debug.Log("Object Position: " + spawnedObject.transform.position);
    }

    private void timerTick()
    {
        timer = timer - Time.deltaTime;
        if(timer < 0)
        {
            PlaceTrail();
            timer = maxTime;
           
                
        }
        //Debug.Log("Timer: " + timer);
    }

    public Vector2 getTrailPos()
    {
        if (spawnedObject != null)
        {
            return spawnedObject.transform.position;
        }
        else { return PlayerPos.getPlayerPos(); }

    }
}
