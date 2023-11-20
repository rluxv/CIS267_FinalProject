using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    private PlayerDetector detector;
    public GameObject detectorObject;
    
    public TMP_Text screen;
    public string[] text;
    public string initialText;
    public string[] choices;
    private string parent;
    int pos;
    public bool doesBranch;
   
    // Start is called before the first frame update
    void Start()
    {
        detector = detectorObject.GetComponent<PlayerDetector>();
        pos = 0;
        
        parent = transform.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(!doesBranch)
        {
            dialogue();
        }
       
        if (doesBranch)
        {
            choice();
        }
    }

    private void choice()
    {
        
        if (detector.playerInRange() && Input.GetKeyDown(KeyCode.Space) || detector.playerInRange() && Input.GetButtonDown("AButton"))
        {
            screen.text =  parent + "- " + initialText +"\n"+ choices[0] + "\n" + choices[1] + "\n" + choices[2] + "\n" + choices[3];
        }


    }
    
    private void dialogue()
    {
        
        if (detector.playerInRange() && Input.GetKeyDown(KeyCode.Space) || detector.playerInRange() && Input.GetButtonDown("AButton"))
        {
            
            screen.text = text[pos];
            pos++;
        }

       

        if (pos == text.Length)
        {
            pos = 0;
        }
    }

    
}
