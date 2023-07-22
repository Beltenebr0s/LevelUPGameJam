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

    [SerializeField] private Animator playerAnim;

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
            playerAnim.SetBool("isSabotaging", false);
            loadingCircle.StopLoading();
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.Space))
        {
            coolActionCoroutine = StartCoroutine(WaitAndDoEvent());
            loadingCircle.StartLoading();
        }
    }

    public void DoEvent()
    {
        associatedEvent.CompleteEvent();
        transform.GetChild(0).gameObject.SetActive(false);
        this.enabled = false;
        associatedEvent = null;
    }

    private IEnumerator WaitAndDoEvent()
    {
        playerAnim.SetBool("isSabotaging", true);

        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        
        DoEvent();
        
        loadingCircle.StopLoading();

        playerAnim.SetBool("isSabotaging", false);

    }

    public void SetAssociatedEvent(Event ev)
    {
        associatedEvent = ev;
    }
}