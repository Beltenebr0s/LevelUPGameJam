using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float hitDistance = 10f;

    void Update()
    {
        Look();
    }

    private void Look()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitDistance, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, hitDistance))
        {
            GameObject hitObject = hit.collider.gameObject;
            if ( hitObject.CompareTag("Player Trigger") && !hitObject.transform.parent.GetComponent<Player>().isWorking)
            {
                GameManager.Instance.PlayerCaught();
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PlayerCaught();
        }
    }

}
