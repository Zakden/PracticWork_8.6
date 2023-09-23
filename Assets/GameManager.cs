using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] Runners;
    public Transform Stick;
    public float Speed;
    public float passDistance;

    private bool isRunning = true;
    private int target = 0;


    void Start()
    {
        Runners[target].transform.LookAt(Runners[target + 1]);
        Stick.SetParent(Runners[target]);
    }

    void Update()
    {
        if(isRunning)
        {
            Runners[target].transform.LookAt(Runners[target + 1]);
            Runners[target].transform.position = Vector3.MoveTowards(Runners[target].transform.position, Runners[target + 1].transform.position, Time.deltaTime * Speed);
            if (Vector3.Distance(Runners[target].transform.position, Runners[target + 1].transform.position) < passDistance)
            {
                target++;
                Stick.SetParent(Runners[target], false);
                if (target >= Runners.Length-1)
                    isRunning = false;
            }
        }    
    }
}
