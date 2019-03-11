using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class tileManagement : MonoBehaviour
{
    public static tileManagement Instance; 

    public float focusTime;
    public float focusTimeReset;
    public bool timerOn;

    public float focusTimeMax;
    public float focusTimeMin; 

    public bool colorSwitch;

    public List<GameObject> tiles;
    public GameObject currentTile;
    int index;

    public bool tileComplete;
    public bool justFinishedTile;

    public List<string> tasks = new List<string>(); 
    public string currentTask;
    int taskIndex;
    public Text thoughts; 

    public Material[] colors;
    public Material defaultColor;
    public Material otherColor;
    int colorIndex;

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
        thoughts.text = currentTask; 

        if (tileComplete == true){
            tiles.Remove(currentTile);
            tasks.Remove(currentTask); 
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
            focusTimeReset = Random.Range(focusTimeMin, focusTimeMax);
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

            taskIndex = Random.Range(0, tasks.Count);
            currentTask = tasks[taskIndex];
            //Debug.Log("" + currentTask);

            colorIndex = Random.Range(0, colors.Length);
            otherColor = colors[colorIndex];  
            currentTile.gameObject.GetComponent<Renderer>().material = otherColor; 
        }
    }
}
