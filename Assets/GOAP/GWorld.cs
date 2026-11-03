
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld 
{
    public static readonly GWorld instannce = new GWorld();
    private static WorldStates world;
    private static Queue<GameObject> patients;

    static GWorld()
    {
        world = new WorldStates(); 
    }

    private GWorld()
    {
        
    }

    public void AddPatient(GameObject p)
    {
        patients.Enqueue(p);
    }

    public GameObject RemovePatient()
    {
        if (patients.Count == 0) return null;
        return patients.Dequeue();
    }
    public static GWorld Instance
    {
        get { return Instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}