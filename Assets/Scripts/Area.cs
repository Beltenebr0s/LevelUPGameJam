using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]

public class Area : MonoBehaviour
{
    public BoxCollider areaCollider;
    [SerializeField] private bool camFixedX;
    [SerializeField] private bool camFixedZ;

    [SerializeField] private Vector3 camStartingPos;

    public bool isCurrentArea = false;


    public Vector3 GetStartingPos()
    {
        return camStartingPos;
    }

    public float IsXFixed() 
    { 
        if (camFixedX)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public float IsZFixed()
    {
        if (camFixedZ)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCurrentArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCurrentArea = false;
        }
    }
}
