using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileColor : MonoBehaviour
{

    public Material defaultColor; 
    public Material otherColor;

    public bool colorOn; 

    void Start()
    {
        defaultColor = GetComponent<Renderer>().material;
        colorOn = false; 
    }

    // Update is called once per frame
    void Update()
    {

        //if (tileManagement.Instance.currentTile = this.gameObject)
        //{
        //    colorOn = true;
        //}

        //else if (tileManagement.Instance.currentTile != this.gameObject)
        //{
        //    colorOn = false; 
        //}

        if (colorOn == true)
        {
            GetComponent<Renderer>().material = otherColor;
        }

        if (colorOn == false)
        {
            GetComponent<Renderer>().material = defaultColor;
        }
    }
}
