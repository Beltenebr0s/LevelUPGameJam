using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonChangeToogle : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _image;
    [SerializeField] private Sprite unpressed, pressed;
    public void PressButton()
    {
        _image.sprite = pressed;
    }

    public void UnpressButton()
    {
        _image.sprite = unpressed;
    }
}
