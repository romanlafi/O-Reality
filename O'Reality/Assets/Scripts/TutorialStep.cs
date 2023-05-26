using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TutorialStep
{
    public GameObject target;
    public string instruction;

    public TutorialStep(GameObject targetObject, string instruction)
    {
        this.target = targetObject;
        this.instruction = instruction;
    }
}
