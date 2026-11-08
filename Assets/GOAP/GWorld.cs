
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld 
{
    private static readonly GWorld instance = new GWorld();
    private WorldStates world;
    private Queue<GameObject> patients;
    private Queue<GameObject> cubicles;
    
    // Construtor privado para o Singleton
    private GWorld()
    {
        world = new WorldStates(); 
        patients = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();
        
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
        foreach (GameObject c in cubes)
            cubicles.Enqueue(c);
        
        if(cubes.Length > 0 )
            world.ModifyState("FreeCubicle", cubes.Length);

        Time.timeScale = 5;
    }

    // Propriedade pública para aceder à instância (corrigido o loop infinito)
    public static GWorld Instance
    {
        get { return instance; }
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
    
    public void AddCubicle(GameObject p)
    {
        cubicles.Enqueue(p);
    }

    public GameObject RemoveCubicle()
    {
        if (cubicles.Count == 0) return null;
        return cubicles.Dequeue();
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}