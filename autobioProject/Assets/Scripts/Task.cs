using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public bool chosen;
    public string taskWords;
    [HideInInspector]
    public GameObject taskTile;
    [HideInInspector]
    public GameObject taskImage;
    public Material taskColor;
    [HideInInspector]
    public MeshRenderer mr;
    Material defaultColor;
    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        defaultColor = mr.material;
        taskTile = this.gameObject;
        taskImage = transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        taskImage.SetActive(chosen);
        if(chosen){
            mr.material = taskColor;
        }else{
            mr.material = defaultColor;
        }
    }
}
