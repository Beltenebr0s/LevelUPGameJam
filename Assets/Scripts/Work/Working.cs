using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Working : MonoBehaviour
{
    public bool isWorking = false;
    public float timeWithoutWorkingPermitted = 100;
    public float timer;
    private Animator playerAnim;

    void Start()
    {
        timer = 0f;
        playerAnim = GameObject.Find("Main Character").GetComponent<Animator>();
    }

    void Update()
    {
        if(!isWorking && GameManager.Instance.gameRunning)
        {
            if (timer >= timeWithoutWorkingPermitted)
            {
                GameManager.Instance.PlayerCaught();
            }
            timer += Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "OrdenadorPlayer")
        {
            isWorking = true;
            timer = 0f;
            playerAnim.SetBool("isSabotaging", true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "OrdenadorPlayer")
        {
            isWorking = false;
            playerAnim.SetBool("isSabotaging", false);
        }
    }
}
