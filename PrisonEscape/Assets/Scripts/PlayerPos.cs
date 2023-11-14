using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class PlayerPos
{


    //player position functions and variables
    static float playerPosX;
    static float playerPosY;
    static public float getPlayerPosX()
    {
        return playerPosX;
    }

    static public float getPlayerPosY()
    {
        return playerPosY;
    }

    static public void setPlayerPosX(float x) 
    {
        playerPosX = x;
    }

    static public void setPlayerPosY(float y)
    {
        playerPosY = y;
    }
}
