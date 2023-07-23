using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private GameObject fPopup;
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
            if (closestTeleport.background != null)
            {
                backgroundCanvas.gameObject.SetActive(true);
                backgroundCanvas.texture = closestTeleport.background;
            }
            else
            {
                backgroundCanvas.gameObject.SetActive(false);
            }
            
        }
    }

    public void Create(Transform parent)
    {
        GameObject fPopupTransf = Instantiate(fPopup, parent);
        fPopupTransf.transform.localPosition = relPos;

        Debug.Log(fPopupTransf.transform.localScale);
        Debug.Log(parent.transform.localScale);

        rescaling.x = fPopupTransf.transform.localScale.x / parent.transform.localScale.x;
        rescaling.y = fPopupTransf.transform.localScale.y / parent.transform.localScale.y;
        rescaling.z = fPopupTransf.transform.localScale.z / parent.transform.localScale.z;
        fPopupTransf.transform.localScale = rescaling;
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
