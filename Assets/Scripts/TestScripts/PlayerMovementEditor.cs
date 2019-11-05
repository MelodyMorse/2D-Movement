using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PlayerMovementEditor : Editor
{
    PlayerMovement pm;
    private void OnEnable()
    {
        pm = (PlayerMovement)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    private void OnSceneGUI()
    {
       // Vector3 heightArrowOrigin = pm.transform.position + new Vector3(-1, -1);
       // Vector3 jumpHeightArrowEndPoint = heightArrowOrigin + new Vector3(0, pm.jumpHeight);
           
       // Handles.DrawLine(heightArrowOrigin, jumpHeightArrowEndPoint);
       
        //Handles.Label(controller2D.transform.position, "Hello World");
        //Handles.color = Color.blue;
        //float size = HandleUtility.GetHandleSize(controller2D.transform.position);
        //controller2D.jumpHeight = Handles.ScaleValueHandle(controller2D.jumpHeight, controller2D.transform.position + new Vector3(-1, -1), Quaternion.LookRotation(Vector3.up), controller2D.jumpHeight * 7.5f, Handles.ArrowHandleCap, 0.5f);

        /* Handles.ArrowHandleCap(
                  0,
                  controller2D.transform.position + new Vector3(3f, 0f, 0f),
                  controller2D.transform.rotation * Quaternion.LookRotation(Vector3.up),
                  1,
                  EventType.Repaint
              ); */

    }
    

}
