using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private GameObject teleportPopup;
    [SerializeField] private RawImage backgroundCanvas; 
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 relPos;

    [SerializeField]private Teleport closestTeleport;

    private NPC NPCTriggered;
    private Vector3 rescaling;

    private void Update()
    {
        if(closestTeleport != null && Input.GetKeyDown(KeyCode.F))
        {
            player.transform.position = closestTeleport.destination;
            backgroundCanvas.texture = closestTeleport.background;
        }
    }

    public void Create(Transform parent)
    {
        GameObject teleportPopupTransf = Instantiate(teleportPopup, parent);
        teleportPopupTransf.transform.localPosition = relPos;

        Debug.Log(teleportPopupTransf.transform.localScale);
        Debug.Log(parent.transform.localScale);

        rescaling.x = teleportPopupTransf.transform.localScale.x / parent.transform.localScale.x;
        rescaling.y = teleportPopupTransf.transform.localScale.y / parent.transform.localScale.y;
        rescaling.z = teleportPopupTransf.transform.localScale.z / parent.transform.localScale.z;
        teleportPopupTransf.transform.localScale = rescaling;
    }

    public void PlayerIsHere(Teleport teleport)
    {
        closestTeleport = teleport;
        Create(closestTeleport.gameObject.GetComponent<Transform>());
    }

    public void PlayerIsNotHere()
    {
        closestTeleport = null;
    }
}
