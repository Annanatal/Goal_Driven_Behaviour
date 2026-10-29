using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GWorld : MonoBehaviour
{
    public static GWorld Instance;

    private WorldStates world;

    private void Awake()
    {
        Instance = this;
        world = new WorldStates();
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
