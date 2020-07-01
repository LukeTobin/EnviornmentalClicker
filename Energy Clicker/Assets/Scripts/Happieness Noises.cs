using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappienessNoises
{

    public Image peopleHappy;
    public Color peopleColor;

    public int uwu;


    // Start is called before the first frame update
    void Start()
    {
        peopleColor = peopleHappy.color;
        peopleColor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        peopleHappy.color = peopleColor;

        if (uwu > 5)
        {
            peopleColor = Color.green;
        }
        else
        {
            peopleColor = Color.red;
        }
    }
}
