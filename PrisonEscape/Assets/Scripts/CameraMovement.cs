using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(GameManager.getPlayerPosX(),GameManager.getPlayerPosY(),transform.position.z );
    }
}
