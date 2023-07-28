using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBody : MonoBehaviour
{
    public void HacerChikito()
    {
        transform.localScale = Vector3.one * Settings.bossSize;
        transform.Find("GooglyEyes").gameObject.SetActive(Settings.googlyEyes);
    }
}
