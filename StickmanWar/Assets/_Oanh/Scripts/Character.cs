using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public float Heart{get;set;}
    [HideInInspector]
    public float Dame{get;set;}
    [HideInInspector]
    public ECharacter eCharacter{get;set;}
    private void OnEnable() => GameController.Instance.SetDataCharacter(this);
}
