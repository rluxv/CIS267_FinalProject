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

    // Start is called before the first frame update
    void Start()
    {
        pathFindingPositions = new List<Vector3>();
        GameObject pathingObjectContainer = GameObject.FindWithTag("PATH_OBJECTS_CONTAINER");
        isPathing = false;
        path = new NavMeshPath();


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
        Vector3 guard = transform.position;
        Vector3 pathV = pathFindingPositions[pathIndex];


        int pathLength = pathFindingPositions.Count;
        NavMesh.CalculatePath(transform.position, pathFindingPositions[pathIndex], NavMesh.AllAreas, path);
        //NavMeshAgent.SetPath(path);

        if (guard == pathV && !shouldSwitch)
        {
            pathIndex++;
        }
        if (pathLength == pathIndex)
        {
            pathIndex--;
            shouldSwitch = true;
        }
        if (guard == pathV && shouldSwitch && pathIndex != 0)
        {
            pathIndex--;
        }
        if (pathIndex == 0)
        {

            shouldSwitch = false;
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
