using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suvat
{
    float displacement;
    Vector3 initialVelocity;
    Vector3 finalVelocity;
    float acceleration;
    float time;

    public static float CalculateInitalVelocity(float finalVelocity, float acceleration, float displacement )
    {

        return Mathf.Sqrt(finalVelocity * finalVelocity + 2 * acceleration * displacement);
    }

    
}
