using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Dialogue : MonoBehaviour
{
    private PlayerDetector detector;
    public GameObject detectorObject;
    public GameObject highlight;
    public float offset;
    
    public TMP_Text screen;
    public bool doesBranch;
    
    public string[] text;
    public string initialText;
    public string[] choices;
    private string parent;
    private int pos;
    private float inputVertical;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        detector = detectorObject.GetComponent<PlayerDetector>();
        pos = 0;
        
        parent = transform.name;
        timer = 0;
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
            moveHighlight();
            inputVertical = Input.GetAxisRaw("Vertical");
        }

        Debug.Log(inputVertical);
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

    private void moveHighlight()
    {
        
        timer -= Time.deltaTime;
        if (inputVertical == 1 && timer < 0)
        {
            highlight.transform.position = new Vector2(highlight.transform.position.x, highlight.transform.position.y + offset);
            timer = 1;
        }
        if (inputVertical == -1 && timer < 0)
        {
            highlight.transform.position = new Vector2(highlight.transform.position.x, highlight.transform.position.y - offset);
            timer = 1;
        }
        Debug.Log(timer);
    }
}
