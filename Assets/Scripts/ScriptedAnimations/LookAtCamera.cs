using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class LookAtCamera : MonoBehaviour
{
    private float distToCameraZ;
    private GameObject mainCamera;
    private int number;

    private void Start()
    {
        mainCamera = Camera.main.gameObject;
        distToCameraZ = mainCamera.GetComponent<CameraController>().relativePos.z;
    }
    void LateUpdate()
    {
        if (GetComponent<Renderer>() != null)
        {
            number = 50 + (int)Mathf.Round(transform.position.z);
            GetComponent<SortingGroup>().sortingLayerID = SortingLayer.NameToID("New Layer " + number.ToString());
        }

        if (GetComponent<SortingGroup>() != null)
        {
            number = 50 + (int)Mathf.Round(transform.position.z);      
            GetComponent<SortingGroup>().sortingLayerID = SortingLayer.NameToID("New Layer " + number.ToString());
        }

        transform.forward = Camera.main.transform.forward;
        
        //transform.LookAt(new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z), Vector3.up);
        //transform.forward *= -1;
    }
}
