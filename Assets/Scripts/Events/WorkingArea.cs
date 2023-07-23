using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WorkingArea : MonoBehaviour
{
    public AudioSource SFX;
    [SerializeField] private Animator playerAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAnim.SetBool("isWorking", true);
            SFX.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAnim.SetBool("isWorking", false);
            SFX.Pause();
        }
    }

}
