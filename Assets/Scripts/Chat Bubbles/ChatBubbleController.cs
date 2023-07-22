using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBubbleController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private List<NPC> NPCList = new List<NPC>();

    [SerializeField] private GameObject chatBubble;

    private NPC NPCTriggered;
    private Vector3 rescaling;

    public void CreateBubble(Transform parent, string tag)
    {
        NPCTriggered = NPCList.Find(x => x.name == tag);
        Create(parent, NPCTriggered.bubbleRelativePos, NPCTriggered.RandomDialog());
    }
    public void Create(Transform parent, Vector3 relPos, string newDialog)
    {
        GameObject chatBubbleTransf = Instantiate(chatBubble, parent);

        rescaling.x = relPos.x / parent.transform.localScale.x;
        rescaling.y = relPos.y / parent.transform.localScale.y;
        rescaling.z = relPos.z / parent.transform.localScale.z;
        chatBubbleTransf.transform.localPosition = rescaling;

        rescaling.x = chatBubbleTransf.transform.localScale.x / parent.transform.localScale.x;
        rescaling.y = chatBubbleTransf.transform.localScale.y / parent.transform.localScale.y;
        rescaling.z = chatBubbleTransf.transform.localScale.z / parent.transform.localScale.z;
        chatBubbleTransf.transform.localScale = rescaling;

        chatBubbleTransf.GetComponent<ChatBubble>().Setup(newDialog);
    }
}
