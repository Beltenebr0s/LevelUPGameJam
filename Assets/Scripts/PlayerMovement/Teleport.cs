using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public Vector3 destination = Vector3.zero;

    [SerializeField] private TeleportController teleportController;
    public Texture background;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            teleportController.PlayerIsHere(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            teleportController.PlayerIsNotHere();
            Destroy(transform.Find("Teleport Popup(Clone)").gameObject);
        }
    }
}
