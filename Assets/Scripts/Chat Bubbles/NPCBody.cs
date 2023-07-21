using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCBody : MonoBehaviour
{
    
    [SerializeField] private ChatBubbleController chatBubbleController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            chatBubbleController.CreateBubble(GetComponent<Transform>(), gameObject.tag);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(transform.Find("Chat Bubble(Clone)") != null)
            {
                Destroy(transform.Find("Chat Bubble(Clone)").gameObject);
            }
        }
    }
}
