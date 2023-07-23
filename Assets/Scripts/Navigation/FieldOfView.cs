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
            if ( hitObject.CompareTag("Player") && !hitObject.GetComponent<Working>().isWorking)
            {
                GameManager.Instance.PlayerCaught();
            }

        }
    }

}
