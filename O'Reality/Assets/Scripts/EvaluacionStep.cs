using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EvaluacionStep
{
    public GameObject target;
    public int step;
    public string instruction;

    public EvaluacionStep(GameObject targetObject, int step, string instruction)
    {
        this.target = targetObject;
        this.step = step;
        this.instruction = instruction;
    }

    public string ToString()
    {
        return "Paso " + step + ": " + instruction; 
    }
}

