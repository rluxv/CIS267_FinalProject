using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHairColor : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer hair;
    private Color[] colors;
    private int pos; 
    void Start()
    {
        hair = GetComponent<SpriteRenderer>();
        colors = new Color[8]  ;
        colors[0] = Color.white;
        colors[1] = Color.blue;
        colors[2] = Color.green;
        colors[3] = Color.cyan;
        colors[4] = Color.gray;
        colors[5] = Color.magenta;
        colors[6] = Color.red;
        colors[7] = Color.yellow;
        
           
        pos = Random.Range(0,8);
    }

    // Update is called once per frame
    void Update()
    {
       
        hair.color = colors[pos];
    }
}
