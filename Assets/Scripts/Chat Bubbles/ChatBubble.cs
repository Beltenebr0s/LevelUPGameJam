using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    private SpriteRenderer bubble;
    private TMP_Text dialog;
    public static GameObject chatBubble;

    private void Awake()
    {
        bubble = transform.Find("Background").gameObject.GetComponent<SpriteRenderer>();
        dialog = transform.Find("Text").gameObject.GetComponent<TMP_Text>();
    }

    public void Setup(string text)
    {
        dialog.text = text;
        dialog.ForceMeshUpdate();
        Vector2 textSize = dialog.GetRenderedValues(false);

        Vector2 padding = new Vector2(2f, 4f);
        bubble.size = textSize + padding;
    }
}
