using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : GAgent
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
       base.Start() ;
       SubGoal s1 = new SubGoal("isWaiting", 1, true);
       goals.Add(s1, 3);
    }

    

}
