using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(CharacterController2D))]
public class CharacterController2DEditor : Editor
{
    CharacterController2D controller2D;

    private void OnEnable()
    {
        controller2D = (CharacterController2D)target;
    }

    public override void OnInspectorGUI()
    {


        base.OnInspectorGUI();
    }

    private void OnSceneGUI()
    {
        serializedObject.Update();

        Vector3 heightArrowOrigin = controller2D.transform.position + new Vector3(-1, -1);
        Vector3 jumpHeightArrowEndPoint = heightArrowOrigin + new Vector3(0, controller2D.jumpHeight);

        Vector3 runArrowOrigin = controller2D.transform.position + new Vector3(0, -1f);
        Vector3 runArrowEndPoint = runArrowOrigin + new Vector3(controller2D.runSpeed, 0);

        Vector3 jumpArcOrigin = runArrowOrigin;
        Handles.color = Color.white;
        Handles.DrawLine(heightArrowOrigin, jumpHeightArrowEndPoint);
        controller2D.jumpHeight = Handles.ScaleValueHandle(controller2D.jumpHeight, jumpHeightArrowEndPoint, Quaternion.LookRotation(Vector3.up), 10, Handles.ArrowHandleCap, 0.1f);

        Handles.DrawLine(runArrowOrigin, runArrowEndPoint);
        controller2D.runSpeed = Handles.ScaleValueHandle(controller2D.runSpeed, runArrowEndPoint, Quaternion.LookRotation(Vector3.right), 10, Handles.ArrowHandleCap, 0.1f);
        float scaledGravity = Physics2D.gravity.y * controller2D.gameObject.GetComponent<Rigidbody2D>().gravityScale;
        Vector2 verticalJumpVelocity = KinematicHelper.CalculateInitialVelocity(controller2D.transform.position, controller2D.transform.position + Vector3.up * controller2D.jumpHeight, controller2D.jumpHeight, scaledGravity);

        Vector3[] arcPoints = KinematicHelper.CalculateArcArray(new Vector3(controller2D.runSpeed, verticalJumpVelocity.y), 10, scaledGravity );

        for (int i = 0; i < arcPoints.Length - 1; i++)
        {
            Handles.DrawLine(runArrowOrigin + arcPoints[i], runArrowOrigin + arcPoints[i + 1]);
        }
        serializedObject.ApplyModifiedProperties();
        
        if(GUI.changed)
        {
            EditorUtility.SetDirty(controller2D);
            EditorSceneManager.MarkSceneDirty(controller2D.gameObject.scene);
        }
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
