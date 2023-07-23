using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating2 : MonoBehaviour
{
    public float forceMax = 2f;
    public float forceMin = 0.05f;
    public float change = 0.95f;
    [SerializeField] private int increm = -1;
    [SerializeField] private float force;
    void Start()
    {
        force = -forceMax;
    }


    void Update()
    {
        this.transform.Translate(new Vector3(0, 1, 0) * force * Time.deltaTime);

        //Cuando la fuerza es muy pequeña, la cambia de signo y empieza a dividir entre change
        if (Mathf.Abs(force) < forceMin)
        {
            increm *= -1;
            force *= -1;
        }
        else
        {
            //Cuando la fuerza es muy grande, pasa a multiplicar por el cambio
            if (Mathf.Abs(force) > forceMax)
            { increm *= -1; }
        }
        force *= Mathf.Pow(change, increm);

    }
}