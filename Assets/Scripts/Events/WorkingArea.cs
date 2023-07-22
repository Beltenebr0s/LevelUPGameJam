using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingArea : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAnim.SetBool("isWorking", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerAnim.SetBool("isWorking", false);
        }
    }

}
