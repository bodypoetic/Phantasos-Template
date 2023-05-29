using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int playerProgression = 0;

    public MsgVariables msgVariables;
    
    public void Update()
    {
        // msgVariables.VariablesToStory();
    }

    public void AddProgressCounter()
    {
        // msgVariables.variables["player_progression"]
        
        playerProgression = playerProgression + 1;
        UnityEngine.Debug.Log("Player Progression = " + playerProgression);
    }
}
