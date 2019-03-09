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

    public List<GameObject> tiles;
    public GameObject currentTile;
    int index;

    public bool tileComplete;
    public bool justFinishedTile;

    public Material defaultColor;
    public Material otherColor;

    void Start()
    {
        Instance = this;
        tiles = new List<GameObject>();
        GameObject[] temps = GameObject.FindGameObjectsWithTag("Tile");
        foreach(GameObject obj in temps){
            tiles.Add(obj);
        }
        timerOn = true;
        tileComplete = false;
        justFinishedTile = false;
    }

    void Update()
    {
        if (tileComplete == true){
            tiles.Remove(currentTile);
            Destroy(currentTile.gameObject);
            currentTile = null;
            timerOn = true;
            focusTime = 0.5f; 
            tileComplete = false;
            justFinishedTile = true;
        }

        if (timerOn == true){
            focusTime -= Time.deltaTime;
        }

        if (focusTime < 0f){
            focusTime = focusTimeReset;
        }

        if (focusTime >= focusTimeReset){
            colorSwitch = true;
            currentTile.gameObject.GetComponent<Renderer>().material = defaultColor; 
        }

        if (focusTime <= focusTimeReset && colorSwitch == true){
            colorSwitch = false; 
            index = Random.Range(0, tiles.Count);
            currentTile = tiles[index];
            Debug.Log("" + currentTile.name);
            currentTile.gameObject.GetComponent<Renderer>().material = otherColor; 
        }
    }
}
