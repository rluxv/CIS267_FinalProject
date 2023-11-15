using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Config
{
    public static float DEFAULT_ENTITY_HEALTH = 100f;
    public static string DEFAULT_SAVE_LEVEL = LEVEL_1;
    public static Vector3 DEFAULT_POSITION = Vector3.zero;

    // Scene Keys
    public static string LEVEL_1 = "Level1";
    public static string LEVEL_2 = "Level2";
    public static string LEVEL_3 = "Level3";
}
