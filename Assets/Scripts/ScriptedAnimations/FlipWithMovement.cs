using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWithMovement : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    private float xcoord = 0;
    private float xcoordPrev = 0;
    private bool lookingLeft = true;

    private void LateUpdate()
    {
        xcoordPrev = xcoord;
        xcoord = _transform.position.x;

        if (xcoord < xcoordPrev && !lookingLeft)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            lookingLeft = true;
        }
        else if (xcoord > xcoordPrev && lookingLeft)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            lookingLeft = false;
        }
    }
}
