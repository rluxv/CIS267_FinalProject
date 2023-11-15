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
    int pos;
    bool onFrame;
    // Start is called before the first frame update
    void Start()
    {
        detector = detectorObject.GetComponent<PlayerDetector>();
        pos = 0;
        onFrame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        dialogue();
    }
    
    private void dialogue()
    {
        
        if (detector.playerInRange() && Input.GetKeyDown(KeyCode.Space) || detector.playerInRange() && Input.GetButtonDown("BButton"))
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
