using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{     
    //LateUpadate is used, for some reason if update is used the camera twitches 
    void LateUpdate()
    {
        transform.position = new Vector3(GameManager.getPlayerPosX(),GameManager.getPlayerPosY(),transform.position.z );
    }
}
