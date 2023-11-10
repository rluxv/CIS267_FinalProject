using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    private static KeepOnLoad keepOnLoad;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (keepOnLoad == null)
        {
            keepOnLoad = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
}
