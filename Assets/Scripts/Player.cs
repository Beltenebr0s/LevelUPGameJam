using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float runningIncr = 2f;
    private float speed;
    public Rigidbody2D rb;
    private SpriteRenderer spriteRend;

    void Start()
    {
        speed = baseSpeed;
        spriteRend = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Shift para correr
        if (Input.GetKey(KeyCode.LeftShift))
        { speed = baseSpeed * runningIncr; }

        else
        { speed = baseSpeed; }

        //Movimiento por el plano con el teclado
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(movH, 0, movV) * speed * Time.deltaTime);

        if (movH > 0)
        {
            spriteRend.flipX = true;
        }
        else if (movH < 0)
        {
            spriteRend.flipX = false;
        }
    }
}
