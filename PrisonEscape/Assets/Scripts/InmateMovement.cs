using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class InmateMovement : MonoBehaviour
{
    private List<Vector3> pathFindingPositions;
    public float movementSpeed;
    private bool isPathing;
    private NavMeshPath path;
    int pathIndex;
    bool shouldSwitch;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        pathFindingPositions = new List<Vector3>();
        GameObject pathingObjectContainer = GameObject.FindWithTag("PATH_OBJECTS_CONTAINER");
        isPathing = false;
        path = new NavMeshPath();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;



        for (int i = 0; i < pathingObjectContainer.transform.childCount; i++)
        {
            
            GameObject child = pathingObjectContainer.transform.GetChild(i).gameObject;
            Debug.Log(child.name);
            //Do something with child
            pathFindingPositions.Add(child.transform.position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        performPathChange();
    }

    private void performPathChange()
    {



        agent.SetDestination(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
