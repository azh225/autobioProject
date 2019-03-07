using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManagement : MonoBehaviour
{
    public static tileManagement Instance; 

    public float focusTime;
    public float focusTimeReset;
    public bool timerOn; 

    public bool colorSwitch;

    public GameObject[] tiles;
    public GameObject currentTile;
    int index;

    public Material defaultColor;
    public Material otherColor;

    void Start()
    {
        Instance = this;
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        timerOn = true; 
    }

    void Update()
    {
        if (timerOn == true){
            focusTime -= Time.deltaTime;
        }

        if (focusTime < 0f){
            focusTime = focusTimeReset;
        }

        if (focusTime >= focusTimeReset - 1f){
            colorSwitch = true;
            currentTile.gameObject.GetComponent<Renderer>().material = defaultColor; 
        }

        if (focusTime <= focusTimeReset - 1f && colorSwitch == true){
            colorSwitch = false; 
            index = Random.Range(0, tiles.Length);
            currentTile = tiles[index];
            Debug.Log("" + currentTile.name);
            currentTile.gameObject.GetComponent<Renderer>().material = otherColor; 
        }
    }
}
