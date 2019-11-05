using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicHelper
{
   
    public static float CalculateInitalVelocity(float finalVelocity, float acceleration, float displacement, float grav = -9.81f )
    {

        return Mathf.Sqrt(finalVelocity * finalVelocity + 2 * acceleration * displacement);
    }
   Vector3 CalculateLaunchVelocity(Vector3 position, Vector3 targetPosition, float maxHeight, float grav = -9.81f)
    {
        float displacementY = targetPosition.y - position.y;
        float displacementX = targetPosition.x - position.x;
        Vector3 displacementXZ = new Vector3(targetPosition.x - position.x, 0, 0);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * grav * maxHeight);
        Vector3 velocityX = Vector3.right * (displacementX / (Mathf.Sqrt(-2 * maxHeight / grav) + Mathf.Sqrt(2 * (displacementY - maxHeight) / grav)));

        return velocityX + velocityY;
    }

    public static Vector3[] CalculateArcArray(Vector3 velocity, int resolution, float gravity = -9.81f)
    {
        
        Vector3[] points = new Vector3[resolution + 1];
        float gAbsolute = Mathf.Abs(gravity);
        float a = CalculateAngle(velocity);

        float speed = velocity.magnitude;
        Debug.Log("magnitude: " + speed);
        float maxDistance = (speed * speed * Mathf.Sin(2 * a)) / gAbsolute;
        Debug.Log("max: " + maxDistance);
        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            points[i] = CalculateArcPoint(velocity, t, maxDistance, gravity);
        }

        return points;
    }

    public static Vector3 CalculateArcPoint(Vector3 velocity, float t, float maxDistance, float gravity = -9.81f)
    {
        float gAbsolute = Mathf.Abs(gravity);
        float x = t * maxDistance;
        float a = CalculateAngle(velocity);
        float y = x * Mathf.Tan(a) - ((gAbsolute * x * x) / (2 * velocity.magnitude * velocity.magnitude * Mathf.Cos(a) * Mathf.Cos(a)));
        return new Vector3(x, y);
    }

    void RenderArc()
    {
        //lineRenderer.positionCount = resolution + 1;
        //lineRenderer.SetPositions(CalculateArcArray());
    }

    public static float CalculateAngle(Vector3 velocity)
    {
        
        float angle = Vector3.Angle(velocity, Vector3.right);

        return angle * Mathf.Deg2Rad;
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
}
