using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class JumpArc : MonoBehaviour
{
    LineRenderer _lineRenderer;
    public float arcHeight = 2;
    public float arcDistance = 3;
    public int numberPoints = 3;
    private float _initialVelocity;
    private float _finalVelocity;
    private float _acceleration;
    private float _displacement; 

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        //Debug.Log("sq rt 120: " + Mathf.Sqrt(120));
    }

    // Start is called before the first frame update
    void Start()
    {
        //_initialVelocity = CalculateInitialVelocity(); 

        _lineRenderer.positionCount = numberPoints;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, transform.position + new Vector3(arcDistance * 0.5f, arcHeight, 0));
        _lineRenderer.SetPosition(2, transform.position + new Vector3(arcDistance, 0, 0));
        // y = a x^2 + arcHeight

        float g = Physics.gravity.magnitude; // get the gravity value
        float vSpeed = Mathf.Sqrt(2 * g * arcHeight); // calculate the vertical speed
        float totalTime = 2 * vSpeed / g; // calculate the total time
        float hSpeed = arcDistance / totalTime; // calculate the horizontal speed
        //rigidbody.velocity = Vector3(hSpeed, vSpeed, 0); // launch the projectile!
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float CalculateInitialVelocity(float finalVelocity, float acceleration, float displacement)
    {
        float initialVelocity = 0.0f;

        initialVelocity = Mathf.Sqrt(finalVelocity * finalVelocity - 2 * acceleration * displacement);

        return initialVelocity;
    }


}
