using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Init : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject inmatePrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject inmate = Instantiate(inmatePrefab);
            inmate.transform.position = spawnPoint.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
