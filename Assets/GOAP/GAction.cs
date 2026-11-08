using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GAction : MonoBehaviour
{
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;
    public string targetTag;
    public float duration = 0;
    public WorldState[] preConditions;
    public WorldState[] afterEffects;
    public NavMeshAgent agent;

    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> effects;

    public WorldStates agentBeLiefs;

    public GInventory inventory;
    
    
    
    public bool running = false;

    
    
    public void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();

        if (preConditions != null)
        {
            foreach (WorldState w in preConditions)
            {
                if (w != null)
                    preconditions[w.key] = w.value;
            }
        }

        if (afterEffects != null)
        {
            foreach (WorldState w in afterEffects)
            {
                if (w != null)
                    effects[w.key] = w.value;
            }
        }
        
        inventory = this.GetComponent<GAgent>().inventory;
    }


    public bool IsAchievable()
    {
        return true;
    }

    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        // Proteção: se o preconditions for null, evita o erro e retorna true
        if (preconditions == null)
        {
            return true;
        }

        foreach (KeyValuePair<string, int> p in preconditions)
        {
            if (!conditions.ContainsKey(p.Key) ||
                conditions[p.Key] != p.Value)
            {
                return false;
            }
        }

        return true;
    }
    public abstract bool PrePerform();
    public abstract bool PostPerform();
}
