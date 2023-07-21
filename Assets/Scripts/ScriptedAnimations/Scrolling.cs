using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{

    [SerializeField] private RawImage image;
    [SerializeField] private float x, y;
    void Update()
    {
        image.uvRect = new Rect(image.uvRect.position.x + x * Time.deltaTime, image.uvRect.position.y + y * Time.deltaTime, image.uvRect.size.x, image.uvRect.size.y);
    }
}
