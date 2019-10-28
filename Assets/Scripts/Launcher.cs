using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Launcher : MonoBehaviour
{
    Rigidbody2D rb2D;
    public Transform target;
    public float h = 25;
    Vector3 targetPos;
    float grav;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        targetPos = target.position;
        grav = Physics.gravity.y;
        rb2D.gravityScale = 0;
    }
    


    void Launch()
    {
        rb2D.gravityScale = 1;
        rb2D.velocity = CalculateLaunchVelocity();
        Debug.Log("launch velocity: " + CalculateLaunchVelocity());
    }

   Vector3 CalculateLaunchVelocity()
    {
        Vector3 position = rb2D.position;
        float displacementY = targetPos.y - position.y;
        float displacementX = targetPos.x - position.x;
        Vector3 displacementXZ = new Vector3 (targetPos.x - position.x, 0, 0);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * grav * h);
        Vector3 velocityX = Vector3.right * (displacementX / (Mathf.Sqrt(-2 * h / grav) + Mathf.Sqrt(2 * (displacementY - h) / grav)));

        return velocityX + velocityY;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }
}
