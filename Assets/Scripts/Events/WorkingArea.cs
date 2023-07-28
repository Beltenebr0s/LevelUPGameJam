using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class WorkingArea : MonoBehaviour
{
    public AudioSource SFX;

    public bool isWorking = false;
    public float timeWithoutWorkingPermitted = 100f;
    public float timeToRefillGauge = 3f;
    public float timer;

    [SerializeField] private Animator playerAnim;
    [SerializeField] private Image gauge;

    private void Start()
    {
        timer = 0f;
        gauge.fillAmount = 1f;
    }

    private void Update()
    {
        if (GameManager.Instance.gameRunning)
        {
            if (!isWorking)
            {
                if (timer >= timeWithoutWorkingPermitted)
                {
                    GameManager.Instance.PlayerCaught();
                }
                timer += Time.deltaTime;
            }
            else if (isWorking && timer > 0)
            {
                timer -= Time.deltaTime * timeWithoutWorkingPermitted / timeToRefillGauge;
            }

            gauge.fillAmount = 1 - timer / timeWithoutWorkingPermitted;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAnim.SetBool("isWorking", true);
            SFX.Play();
            isWorking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAnim.SetBool("isWorking", false);
            SFX.Pause();
            isWorking = false;
        }
    }

}
