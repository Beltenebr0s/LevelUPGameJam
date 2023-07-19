using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private float relativePos;

    void Start()
    {
        relativePos = transform.position.x - player.transform.position.x;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + relativePos, transform.position.y, transform.position.z);
    }

}