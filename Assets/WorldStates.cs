using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldState
{
    public string key;
    public int value;

    public WorldState(string key, int value)
    {
        this.key = key;
        this.value = value;
    }

    public WorldState() { }
}

public class WorldStates
{
    public Dictionary<string, int> states;

    public WorldStates()
    {
        states = new Dictionary<string, int>();
    }

    public bool HasState(string key)
    {
        return states.ContainsKey(key);
    }

    public void AddState(string key, int value)
    {
        states[key] = value;
    }

    public void ModifyState(string key, int value)
    {
        if (states.ContainsKey(key))
        {
            states[key] += value;

            if (states[key] <= 0)
                states.Remove(key);
        }
        else if (value > 0)
        {
            states.Add(key, value);
        }
    }

    public void RemoveState(string key)
    {
        states.Remove(key);
    }

    public void SetState(string key, int value)
    {
        states[key] = value;
    }

    public Dictionary<string, int> GetStates()
    {
        return new Dictionary<string, int>(states);
    }
}
