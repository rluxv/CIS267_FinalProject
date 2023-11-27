using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColiderControler : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    public void setColidersActive(bool colidersActive)
    {

        boxCollider.enabled = colidersActive;

    }

}
