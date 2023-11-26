
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerDetector : MonoBehaviour
{
    public GameObject prompt;
    public GameObject highlight;
    public TMP_Text text;
    private bool inRange;
    private bool promptShown;
    
    // Start is called before the first frame update
    void Start()
    {                 
        inRange = false;
        promptShown = false;
        
       
    }

    // Update is called once per frame
    void Update()
    {
      
        showButtonPrompt();
        
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
            
            
            //SceneManager.LoadScene("CombatScene");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            text.text = "";
            highlight.SetActive(false);
        }
    }

    //getters 

    public bool playerInRange()
    {
        return inRange;
    }
    public bool PromptShown()
    {
        return promptShown;
    }
   
}

