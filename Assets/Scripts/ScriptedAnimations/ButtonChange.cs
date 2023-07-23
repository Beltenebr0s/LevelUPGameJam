using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonChange : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private UnityEngine.UI.Image _image;
    [SerializeField] private Sprite unpressed, pressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = pressed;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = unpressed;
    }
}
