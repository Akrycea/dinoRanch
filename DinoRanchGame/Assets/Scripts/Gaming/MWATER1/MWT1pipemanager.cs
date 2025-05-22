using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWT1pipemanager : MonoBehaviour
{
    //holds pipes
    public GameObject PipesHolder;
    public GameObject[] Pipes;
    int totalPipes = 0;

    int correctPipes;
    
    public int solution;
    
    void Start()
    {
        //solution = 0;

        //counts pipes (without the start and end ones)
        totalPipes = PipesHolder.transform.childCount;
        //holds all the pipes
        Pipes = new GameObject[totalPipes];

        //puts all the pipes into the array
        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    //this is supposed to be a win
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && solution == totalPipes)
        {   
           Debug.Log("you win");  
        }
    }
}
