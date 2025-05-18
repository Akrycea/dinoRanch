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
        solution = 0;
        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (solution < totalPipes)
            {
                //solution = 0;
            }
            else if (solution == totalPipes)
            {
                Debug.Log("you win");
            }
        }
    }
}
