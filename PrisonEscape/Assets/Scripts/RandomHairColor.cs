using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHairColor : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer hair;
    private readonly Color[] colors;
    private List<Color> colorList;
    private int pos; 
    void Start()
    {
        hair = GetComponent<SpriteRenderer>();
        colorList[8] = Color.white + Color.blue + Color.green + Color.cyan + Color.gray + Color.magenta + Color.red + Color.yellow;
        pos = 1;
    }

    // Update is called once per frame
    void Update()
    {
        pos = 2;
        hair.color = colorList[pos];
    }
}
