using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManagement : MonoBehaviour
{
    public static tileManagement Instance; 

    public float focusTime;
    public float focusTimeReset;

    public bool colorSwitch;

    public GameObject[] tiles;
    public GameObject currentTile;
    int index; 

    void Start()
    {
        Instance = this;
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        //index = Random.Range(0, tiles.Length);
        //currentTile = tiles[index];
        //Debug.Log("" + currentTile.name);
    }

    void Update()
    {
        focusTime -= Time.deltaTime; 

        if (focusTime < 0f) 
        {
            //index = Random.Range(0, tiles.Length);
            //currentTile = tiles[index];
            //Debug.Log("" + currentTile.name);
            focusTime = focusTimeReset;
        }

        if (focusTime >= focusTimeReset - 1f) 
        {
            colorSwitch = true;
        }


        if (focusTime <= focusTimeReset - 1f && colorSwitch == true)
        {
            colorSwitch = false; 
            index = Random.Range(0, tiles.Length);
            print(tiles[index].name);
            currentTile = tiles[index];
            Debug.Log("" + currentTile.name);
        }
    }
}
