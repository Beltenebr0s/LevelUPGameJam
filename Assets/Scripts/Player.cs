using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float runningIncr = 2f;
    private float speed;
    public Rigidbody2D rb;

    void Start()
    {
        this.speed = this.baseSpeed;
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

        this.transform.Translate(new Vector3(movH, 0, movV) * speed * Time.deltaTime);
    }
}
