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
using UnityEngine.SceneManagement;

public class InmateMovement : MonoBehaviour
{
    private List<Vector3> pathFindingPositions;
    Vector3 finalPathPosition;
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

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.autoRepath = true;
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;



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
       

        if (agent.hasPath == false) 
        {
            performPathChange();
        }
    
    }

    private void performPathChange()
    {
        int randomIndex = UnityEngine.Random.Range(0, pathFindingPositions.Count);
        agent.SetDestination(pathFindingPositions[randomIndex]);
        isPathing = true;
        finalPathPosition = pathFindingPositions[randomIndex];

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene("CombatScene");
            GameManager_v2.PreviousScene = this.gameObject.scene.name;
            Destroy(this.gameObject);
        }
    }
}
