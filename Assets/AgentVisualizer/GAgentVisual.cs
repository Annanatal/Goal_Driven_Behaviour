using UnityEngine;

public class GAgentVisual : MonoBehaviour
{
    public GAgent thisAgent;

    // Campos exibidos no Inspector para debug
    [Header("Debug Info")]
    public string agentName;
    public string currentAction;
    public string actionsList;
    public string goalsList;

    void Update()
    {
        if (thisAgent == null)
        {
            thisAgent = GetComponent<GAgent>();
            if (thisAgent == null) return;
        }

        agentName = thisAgent.gameObject.name;

        if (thisAgent.currentAction != null)
        {
            currentAction = thisAgent.currentAction.GetType().Name + " (" + thisAgent.currentAction.agent.name + ")";
        }
        else
        {
            currentAction = "None";
        }

        // Formatar lista de ações
        actionsList = "";
        foreach (GAction act in thisAgent.actions)
        {
            string pre = "";
            string eff = "";
            foreach (var p in act.preconditions) pre += p.Key + ", ";
            foreach (var e in act.effects) eff += e.Key + ", ";
            
            actionsList += $"==== {act.GetType().Name}({pre})({eff})\n";
        }

        // Formatar lista de objetivos
        goalsList = "";
        foreach (var g in thisAgent.goals)
        {
            foreach (var val in g.Key.sgoals)
            {
                goalsList += $"===== {val.Key}\n";
            }
        }
    }
}