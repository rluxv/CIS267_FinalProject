using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    private PlayerDetector detector;
    public GameObject detectorObject;
    public GameObject prompt;
    public TMP_Text screen;
    public string[] text;
    int pos;

    // Start is called before the first frame update
    void Start()
    {
        detector = detectorObject.GetComponent<PlayerDetector>();
        pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(detector.playerInRange());
        dialogue();
    }

    private void dialogue()
    {
        
        if (detector.playerInRange() && Input.GetKeyDown(KeyCode.Space) || detector.playerInRange() && Input.GetButtonDown("BButton"))
        {
            screen.text = text[pos];
            pos++;
        }

        if (!detector.playerInRange())
        {
            screen.text = "";
        }

        if (pos == text.Length)
        {
            pos = 0;
        }
    }

    
}
