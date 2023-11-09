
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class PrisonerDialogue : MonoBehaviour
{
    public GameObject prompt;
    public string[] lines;
    
    public float detectionRange;
    public float promptOffset;
    private bool inRange;
    private bool promptShown;
    // Start is called before the first frame update
    void Start()
    {
        

        transform.localScale = new Vector2(detectionRange, detectionRange);
        inRange = false;
        promptShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inRange);
        showButtonPrompt();
        dialogue();
    }

    private void dialogue()
    {
        
    }

    private void showButtonPrompt()
    {
        
        if (inRange && !promptShown)
        {
            prompt.SetActive(true);
            promptShown = true;
        }
        else if(!inRange && promptShown)
        {
            prompt.SetActive(false);
            promptShown = false;
        }
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

