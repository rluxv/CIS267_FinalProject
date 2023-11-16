using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneChange : MonoBehaviour
{
    private void OnDestroy()
    {
        GameManager_v2.PreviousScene = gameObject.scene.name;
    }
}
