using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class tileManagement : MonoBehaviour
{
    public static tileManagement Instance;

    public float focusTime;
    public float focusTimeReset;
    public bool timerOn;

    public float focusTimeMax;
    public float focusTimeMin; 

    public List<Task> tasks;
    public Task currentTask;
    int index;

    public bool tileComplete;
    public bool justFinishedTile;

    public Text thoughts;
    public Text moreThoughts; 

    public Material[] colors;
    public Material defaultColor;

    void Start()
    {
        Instance = this;

        tasks = new List<Task>();
        GameObject[] temps = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject obj in temps)
        {
            tasks.Add(obj.GetComponent<Task>());
        }

        timerOn = true;
        tileComplete = false;
        justFinishedTile = false;

    }

    void Update()
    {
        if(currentTask != null){
            thoughts.text = currentTask.taskWords;
        }

        if (tileComplete == true){
            tasks.Remove(currentTask);
            tasks.Remove(currentTask); 
            Destroy(currentTask.gameObject);
            currentTask = null;
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
            if(currentTask != null){
                currentTask.chosen = false;
            }
            index = Random.Range(0, tasks.Count);
            currentTask = tasks[index];
            currentTask.chosen = true;
        }

        if (tasks.Count == 0){
            thoughts.text = "Wow, I actually accomplished things today? Impressive.";
            moreThoughts.text = "Press 'R' to Restart"; 
            timerOn = false; 
        }

        if (tasks.Count == 0 && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("ADHD"); 
        }

    }
}
