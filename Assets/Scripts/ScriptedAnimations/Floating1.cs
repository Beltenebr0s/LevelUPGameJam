using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating1 : MonoBehaviour
{
    public float forceMax = 1f;
    public float change = 0.01f;
    [SerializeField] private int increm = -1;
    [SerializeField] private float force;
    void Start()
    {
        force = forceMax;
    }


    void Update()
    {
        this.transform.Translate(new Vector3(0, 1, 0) * force * Time.deltaTime);

        //pasa a sumar o a restar cuando la fuerza se sale de los límites
        if (Mathf.Abs(force) > forceMax)
        { increm *= -1; }
        force += change * increm;
    }
}
