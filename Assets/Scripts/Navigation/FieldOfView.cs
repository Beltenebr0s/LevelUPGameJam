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
            if ( hit.collider.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.PlayerCaught();
            }

        }
    }

}
