using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private bool triggerActive = false;
    private Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.Space))
        {
            SomeCoolAction();
        }
    }

    public void SomeCoolAction()
    {
        if (objectRenderer.material.color == Color.red)
        {
            objectRenderer.material.color = Color.green;
        }
        else
        {
            objectRenderer.material.color = Color.red;
        }
    }
}