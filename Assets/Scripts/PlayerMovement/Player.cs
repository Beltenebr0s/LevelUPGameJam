using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float runningIncr = 2f;
    [SerializeField] private float blinkRange;
    [SerializeField] private Animator animator;
    private float speed;
    public Rigidbody rb;
    private bool lookingLeft = false;

    void Start()
    {
        speed = baseSpeed;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        //Shift para correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("shift", true);
            speed = baseSpeed * runningIncr; 
        }

        else
        {
            animator.SetBool("shift", false);
            speed = baseSpeed;
        }

        //Movimiento por el plano con el teclado
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(movH, 0, movV).normalized * speed * Time.deltaTime, Space.World);

        animator.SetFloat("speed", System.Math.Abs(movH) + System.Math.Abs(movV));

        if (movH > 0 && lookingLeft)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            lookingLeft = false;
        }
        else if (movH < 0 && !lookingLeft)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            lookingLeft = true;
        }

        if (System.Math.Abs(movH) + System.Math.Abs(movV) == 0)
        {
            rb.velocity = Vector3.zero;
        }

        if(Random.value < blinkRange)
        {
            animator.SetTrigger("blink");
        }
    }
}
