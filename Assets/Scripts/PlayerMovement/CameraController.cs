using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;

public class CameraController : MonoBehaviour
{

    [SerializeField] private List<Area> areas = new List<Area> ();
    [SerializeField]private Area currentArea;

    [SerializeField] private GameObject player;

    private Vector3 vectorTransform;
    private float relativePosX;
    private float relativePosZ;
    

    void Start()
    {
        currentArea = areas[0];

        transform.position = currentArea.GetStartingPos();

        relativePosX = transform.position.x - player.transform.position.x;
        relativePosZ = transform.position.z - player.transform.position.z;
    }

    void LateUpdate()
    {
        if (!currentArea.isCurrentArea) 
        {
            SeachAreaAndStart();
        }
        
        float coordX = currentArea.IsXFixed() * (transform.position.x) + (1 - currentArea.IsXFixed()) * (player.transform.position.x + relativePosX);
        float coordZ = currentArea.IsZFixed() * (transform.position.z) + (1 - currentArea.IsZFixed()) * (player.transform.position.z + relativePosZ);
        transform.position = new Vector3(coordX, transform.position.y, coordZ);
    }

    private void SeachAreaAndStart()
    {
        for (int i = 0; i < areas.Count; i++)
        {
            if (areas[i].isCurrentArea)
            {
                currentArea = areas[i];
                break;
            }
        }

        transform.position = currentArea.GetStartingPos();

        relativePosX = transform.position.x - player.transform.position.x;
        relativePosZ = transform.position.z - player.transform.position.z;
    }

}