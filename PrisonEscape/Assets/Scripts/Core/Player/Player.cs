using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Entity entity;

    // Start is called before the first frame update
    void Start()
    {
        // Initalize a new entity object for the data values.
        entity = new Entity("NAME HERE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
