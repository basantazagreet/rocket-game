using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Zero sanga comparing inefficient for floats. 
        if(period<=Mathf.Epsilon){
            return;
        }

        //sin wave ma 2 wata cycles huncha
        //cycles is in fraction later 360 le multiply garna
        float cycles = Time.time/period;

        //radian ma angle halna yo chaincha 360 degree
        const float tau = Mathf.PI * 2;

        //Hamilai euta oscillation factor chaiyeko ho
        float rawSinWave = Mathf.Sin(cycles*tau);

        //positive banauna -1 to 1 lai zero to 2
        movementFactor = (rawSinWave + 1f)/2f ;


        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
