using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public LoadingCircle loadingCircle;
    public bool triggerActive = false;
    private Renderer objectRenderer;
    private Coroutine coolActionCoroutine;
    public Event associatedEvent;

    [SerializeField] private Animator playerAnim;

    [SerializeField] private GameObject teleportPopup;
    [SerializeField] private Vector3 relPos;

    private GameObject interactuable;
    private Vector3 rescaling;

    private void Start()
    {
        this.enabled = false;
        objectRenderer = GetComponent<Renderer>();
        transform.GetChild(0).gameObject.SetActive(false);
        playerAnim = GameObject.Find("Main Character").GetComponent<Animator>();
        interactuable = transform.Find("Interactuable").gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("[" + this.gameObject.name + "] Trigger enter");
            triggerActive = true;
            interactuable.SetActive(false);
            Create(transform);
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
            interactuable.SetActive(true);
            Destroy(transform.Find("F Popup(Clone)").gameObject);
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.F))
        {
            coolActionCoroutine = StartCoroutine(WaitAndDoEvent());
            loadingCircle.StartLoading();
        }
    }

    public void DoEvent()
    {
        associatedEvent.CompleteEvent();
        interactuable.SetActive(false);
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

    public void Create(Transform parent)
    {
        GameObject teleportPopupTransf = Instantiate(teleportPopup, parent);
        teleportPopupTransf.transform.localPosition = relPos;

        rescaling.x = teleportPopupTransf.transform.localScale.x / parent.transform.localScale.x;
        rescaling.y = teleportPopupTransf.transform.localScale.y / parent.transform.localScale.y;
        rescaling.z = teleportPopupTransf.transform.localScale.z / parent.transform.localScale.z;
        teleportPopupTransf.transform.localScale = rescaling;
    }

}