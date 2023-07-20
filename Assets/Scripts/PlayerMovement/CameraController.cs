using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Vector3 relativePos;

    [SerializeField] private GameObject player;


    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + relativePos.x, transform.position.y, player.transform.position.z + relativePos.z);
    }
}