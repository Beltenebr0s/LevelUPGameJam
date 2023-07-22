using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private float distToCameraZ;
    private GameObject mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.gameObject;
        distToCameraZ = mainCamera.GetComponent<CameraController>().relativePos.z;
    }
    void LateUpdate()
    {
        if (gameObject.GetComponent<Renderer>() != null)
        {
            if (mainCamera.transform.position.z - distToCameraZ < transform.position.z)
            {
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Back");
            }
            else
            {
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Front");
            }
        }
        transform.forward = Camera.main.transform.forward;
        
        //transform.LookAt(new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z), Vector3.up);
        //transform.forward *= -1;
    }
}
