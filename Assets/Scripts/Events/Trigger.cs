using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Trigger : MonoBehaviour
{
    public LoadingCircle loadingCircle;
    public bool triggerActive = false;
    private Renderer objectRenderer;
    private Coroutine coolActionCoroutine;
    public Event associatedEvent;
    public AudioSource SFX;

    [SerializeField] private Animator playerAnim;

    [SerializeField] private GameObject teleportPopup;
    [SerializeField] private Vector3 relPos;

    private GameObject interactuable;
    private SpriteChange spriteChange;
    private Vector3 rescaling;

    private void Start()
    {
        this.enabled = false;
        objectRenderer = GetComponent<Renderer>();
        transform.GetChild(0).gameObject.SetActive(false);
        playerAnim = GameObject.Find("Main Character").GetComponent<Animator>();
        interactuable = transform.Find("Interactuable").gameObject;
        spriteChange = interactuable.GetComponent<SpriteChange>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("[" + this.gameObject.name + "] Trigger enter");
            triggerActive = true;
            spriteChange.SetSprite2();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
            playerAnim.SetBool("isSabotaging", false);
            loadingCircle.StopLoading();
            spriteChange.SetSprite1();
            if(coolActionCoroutine != null)
            {
                StopCoroutine(coolActionCoroutine);
            }
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.F))
        {
            coolActionCoroutine = StartCoroutine(WaitAndDoEvent());
            loadingCircle.StartLoading();
            SFX.Play();
           
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

}