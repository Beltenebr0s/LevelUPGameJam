using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public LoadingCircle loadingCircle;
    private bool triggerActive = false;
    private Renderer objectRenderer;
    private Coroutine coolActionCoroutine;
    public Event associatedEvent;

    private void Start()
    {
        this.enabled = false;
        objectRenderer = GetComponent<Renderer>();
        transform.GetChild(0).gameObject.SetActive(false);
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
        associatedEvent.CompleteEvent();
        associatedEvent = null;
        this.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private IEnumerator WaitAndDoCoolAction()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        
        SomeCoolAction();
        
        loadingCircle.StopLoading();

    }

    public void SetAssociatedEvent(Event ev)
    {
        print("Hola me han puesto este evento: " + ev.ToString());
        associatedEvent = ev;
    }
}