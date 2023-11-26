using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class PlayerPos
{


    //player position functions and variables
    static float playerPosX;
    static float playerPosY;
    static Vector2 playerPos;
    static bool canMove;

    static public bool CanMove()
    {
        return canMove;
    }

    static public void CanMove(bool m)
    {
        canMove = m;
    }

    static public Vector2 getPlayerPos() 
    {
        return playerPos; 
    }

    static public float getPlayerPosX()
    {
        return playerPosX;
    }

    static public float getPlayerPosY()
    {
        return playerPosY;
    }
    static public void setPlayerPos(Vector2 pos)
    {
        playerPos = pos;
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
