using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBubbleController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private List<NPC> NPCList = new List<NPC>();

    [SerializeField] private GameObject chatBubble;

    private NPC NPCTriggered;

    public void CreateBubble(Transform parent, string tag)
    {
        NPCTriggered = NPCList.Find(x => x.name == tag);
        Create(parent, NPCTriggered.bubbleRelativePos, NPCTriggered.RandomDialog());
    }
    public void Create(Transform parent, Vector3 relPos, string newDialog)
    {
        GameObject chatBubbleTransf = Instantiate(chatBubble, parent);
        chatBubbleTransf.transform.localPosition = relPos;
        Vector3 rescaling = new Vector3(1/parent.transform.localScale.x, 1/ parent.transform.localScale.y, 1/ parent.transform.localScale.z);
        chatBubbleTransf.transform.localScale = rescaling;

        chatBubbleTransf.GetComponent<ChatBubble>().Setup(newDialog);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
