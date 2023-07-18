using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public LoadingCircle loadingCircle;
    private bool triggerActive = false;
    private Renderer objectRenderer;
    private Coroutine coolActionCoroutine;

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
            StopCoroutine(coolActionCoroutine);
            loadingCircle.StopLoading();
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.Space))
        {
            coolActionCoroutine = StartCoroutine(WaitAndDoCoolAction());
            loadingCircle.StartLoading();
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

    private IEnumerator WaitAndDoCoolAction()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        
        SomeCoolAction();
        
        loadingCircle.StopLoading();

    }
}