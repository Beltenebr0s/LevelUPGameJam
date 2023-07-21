using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NPC 
{
    public string name;
    public Vector2 bubbleRelativePos;
    [SerializeField] private List<string> dialogos = new List<string>();

    public string RandomDialog()
    {
        return dialogos[UnityEngine.Random.Range(0, dialogos.Count)];
    } 
}
