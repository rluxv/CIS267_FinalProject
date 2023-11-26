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
    public string[] choiceResults;
    private string parent;
    private int pos;
    private float inputVertical;
    public float timer;
    private float Otime;
    static private int choicePos;
    private bool talking;
    

    // Start is called before the first frame update
    void Start()
    {
        detector = detectorObject.GetComponent<PlayerDetector>();
        pos = 0;
       
        parent = transform.name;
        Otime = timer;
        talking = false;
       
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
            result();
            moveHighlight();
            
            inputVertical = Input.GetAxisRaw("Vertical");
        }

        
    }

    private void result()
    {
       
        
        if (talking && Input.GetKeyDown(KeyCode.Escape) || talking && Input.GetButtonDown("AButton"))
        {
            screen.text = parent + choiceResults[choicePos];
            PlayerPos.CanMove(true);
            talking = false;
        }
       
    }

    private void choice()
    {
        
        if (detector.playerInRange() && Input.GetKeyDown(KeyCode.Space) || detector.playerInRange() && Input.GetButtonDown("AButton"))
        {
            talking=true;
            PlayerPos.CanMove(false);
            highlight.SetActive(true);
            screen.text =  parent + "- " + initialText +"\n"+ choices[0] + "\n" + choices[1] + "\n" + choices[2] + "\n" + choices[3];
        }
        

       
    }
    
    private void dialogue()
    {
        
        if (detector.playerInRange() && Input.GetKeyDown(KeyCode.Space) || detector.playerInRange() && Input.GetButtonDown("AButton"))
        {
            talking = true;
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

        if (detector.playerInRange())
        {


            timer -= Time.deltaTime;
            if (inputVertical == 1 && timer < 0 && choicePos > 0)
            {
                highlight.transform.position = new Vector2(highlight.transform.position.x, highlight.transform.position.y + offset);
                timer = Otime;
                choicePos--;
            }
            if (inputVertical == -1 && timer < 0 && choicePos < 3)
            {
                highlight.transform.position = new Vector2(highlight.transform.position.x, highlight.transform.position.y - offset);
                timer = Otime;
                choicePos++;
            }
        }
        
        //Debug.Log(choicePos);
        //Debug.Log(timer);
    }

    
}
