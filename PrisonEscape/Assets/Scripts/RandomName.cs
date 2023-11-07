using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomName : MonoBehaviour
{
    private TMP_Text text;
    public string[] adjective;
    public string[] noun;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        generateName();
    }

    private void generateName()
    {
        int randomA = Random.Range(0, adjective.Length);
        int randomB = Random.Range(0, noun.Length);

        text.text = adjective[randomA] + " " + noun[randomB];
    }
}
