using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBody : MonoBehaviour
{
    public float size = 1f;
    public bool googlyEyesOn = false;


    public void HacerChikito()
    {
        transform.localScale = Vector3.one * size;
        transform.Find("GooglyEyes").gameObject.SetActive(googlyEyesOn);
    }
}
