
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrisonerDialogue : MonoBehaviour
{
    private GameObject prompt;
    public float detectionRange;
    public bool inRange;
    // Start is called before the first frame update
    void Start()
    {
       transform.localScale = new Vector3(detectionRange, detectionRange, detectionRange);
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inRange);
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}

