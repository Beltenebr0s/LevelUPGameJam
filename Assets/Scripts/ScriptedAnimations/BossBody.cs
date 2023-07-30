using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBody : MonoBehaviour
{
    private float scaleSign;
    private Vector3 scaleVector;
    public void HacerChikito()
    {
        scaleSign = Mathf.Sign(transform.localScale.x);
        scaleVector = Vector3.one * Settings.bossSize;
        scaleVector.x *= scaleSign;
        transform.localScale = Vector3.one * Settings.bossSize;
        transform.Find("GooglyEyes").gameObject.SetActive(Settings.googlyEyes);
    }
}
