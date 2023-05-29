using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class MsgVariables : MonoBehaviour
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }
    public Story globalVariablesStory;

    [SerializeField] public TextAsset loadGlobalsJSON;

    void Awake()
    {
        // create the story
        Story globalVariablesStory = new Story(loadGlobalsJSON.text);

        // initialize the dictionary
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            UnityEngine.Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
        }
    }

    //public MsgVariables(TextAsset loadGlobalsJSON)
    //{
    //    // create the story
    //    Story globalVariablesStory = new Story(loadGlobalsJSON.text);

    //    // initialize the dictionary
    //    variables = new Dictionary<string, Ink.Runtime.Object>();
    //    foreach (string name in globalVariablesStory.variablesState)
    //    {
    //        Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
    //        variables.Add(name, value);
    //        UnityEngine.Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
    //    }
    //}

    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            variables[name] = value;
            UnityEngine.Debug.Log("Variable changed: " + name + " = " + value);
        }
    }

    private void VariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }

    public void SetVariableState(string variableName, Ink.Runtime.Object variableValue)
    {
        if (variables.ContainsKey(variableName))
        {
            variables[variableName] = variableValue;
        }
        else
        {
            UnityEngine.Debug.LogWarning("Tried to update variable that wasn't initialized by globals.ink: " + variableName);
        }
    }

    public void AddProgressCounter(int progressToAdd)
    {
        Ink.Runtime.IntValue currentProgress = ((Ink.Runtime.IntValue)GetVariableState("player_progression"));

        int currentProgressInt = (int)currentProgress.value;

        int newProgress = currentProgressInt + progressToAdd;

        Ink.Runtime.Object obj = new Ink.Runtime.IntValue(newProgress);

        SetVariableState("player_progression", obj);

        UnityEngine.Debug.Log("Player progression = " + newProgress);
    }
}
