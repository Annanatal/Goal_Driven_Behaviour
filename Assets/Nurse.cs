using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : GAgent
{
    // Removi a linha "public new List<GAction> actions..." daqui, 
    // pois a classe base (GAgent) já deve possuí-la.

    void Start()
    {
       base.Start();
       SubGoal s1 = new SubGoal("treatPatient", 1, true);
       goals.Add(s1, 3);
    }
}
