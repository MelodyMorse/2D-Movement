using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(LineRenderer))]
public class Launcher : MonoBehaviour
{
   /* Rigidbody2D rb2D;
    LineRenderer lineRenderer;
    //public Transform target;
    public float h = 25;
    public Vector3 targetPos;
    float grav;
    float gAbsolute;
    float angle;
    float speed;

    public int resolution = 10;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 0;
        grav = Physics2D.gravity.y;
        gAbsolute = Mathf.Abs(grav);
        //rb2D.gravityScale = 0;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.sortingLayerName = "Line";
    }
    private void Start()
    {
        //CalculateAngle();
        //CalculateArcArray();
        //RenderArc();
        
    }
    private void OnDrawGizmos()
    {
       /* Vector3[] points = CalculateArcArray();
        Gizmos.color = Color.blue;
        for (int i = 0; i < points.Length; i++)
        {
            if (i < points.Length - 1)
            {
                Gizmos.DrawLine(transform.position + points[i], transform.position + points[i + 1]);
            }
        }*/
    //}

    /*void Launch()
    {
        rb2D.gravityScale = 1;
        rb2D.velocity = CalculateLaunchVelocity();
        Debug.Log("launch velocity: " + CalculateLaunchVelocity());
        
    }

   Vector3 CalculateLaunchVelocity()
    {
        Vector3 position = transform.position;
        float displacementY = targetPos.y - position.y;
        float displacementX = targetPos.x - position.x;
        Vector3 displacementXZ = new Vector3 (targetPos.x - position.x, 0, 0);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * grav * h);
        Vector3 velocityX = Vector3.right * (displacementX / (Mathf.Sqrt(-2 * h / grav) + Mathf.Sqrt(2 * (displacementY - h) / grav)));

        return velocityX + velocityY;
    }

    public static Vector3 CalculateInitialVelocity(Vector3 pos, Vector3 targ, float maxHeight, float gravity)
    {
        
        float displacementY = targ.y - pos.y;
        float displacementX = targ.x - pos.x;
        Vector3 displacementXZ = new Vector3(targ.x - pos.x, 0, 0);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * maxHeight);
        Vector3 velocityX = Vector3.right * (displacementX / (Mathf.Sqrt(-2 * maxHeight / gravity) + Mathf.Sqrt(2 * (displacementY - maxHeight) / gravity)));

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

    float CalculateAngle()
    {
        Vector3 initVelocity = CalculateLaunchVelocity();
        float angle = Vector3.Angle(initVelocity, Vector3.right);

        return angle * Mathf.Deg2Rad;
    }

    Vector3[] CalculateArcArray()
    {
        Vector3[] points = new Vector3[resolution + 1];
        Vector3 v = CalculateLaunchVelocity();
        float a = CalculateAngle(); 

        speed = v.magnitude;
        Debug.Log("magnitude: " + speed);
        float maxDistance = (speed * speed * Mathf.Sin(2 * a)) / gAbsolute;
        Debug.Log("max: " + maxDistance);
        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            points[i] = CalculateArcPoint(t, maxDistance);
        }

        return points;
    }

    Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        Vector3 velociity = CalculateLaunchVelocity();
       
        float x = t * maxDistance;
        float a = CalculateAngle();
        float y = x * Mathf.Tan(a) - ((gAbsolute * x * x) / (2 * velociity.magnitude * velociity.magnitude * Mathf.Cos(a) * Mathf.Cos(a)));
        return new Vector3(x, y);
    }

    void RenderArc()
    {
        lineRenderer.positionCount = resolution + 1;
        lineRenderer.SetPositions(CalculateArcArray());
    }
    //initv = sqrt(2* grav * jumpHeight) */
}
