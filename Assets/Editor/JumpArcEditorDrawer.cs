using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(JumpArc))]
public class JumpArcEditorDrawer : Editor
{
    private void OnSceneGUI()
    {
        JumpArc t = target as JumpArc;

        Handles.BeginGUI();
        GUILayout.BeginVertical();
        GUILayout.BeginArea(new Rect(20, 20,100, 100));
        //t.InitialVelocityIsKnown = GUILayout.Toggle(t.InitialVelocityIsKnown, "Init");
        GUILayout.EndArea();
        GUILayout.BeginArea(new Rect(120, 20, 200, 100));
        if(GUILayout.Button("Calculate Initial Velocity"))
        {
            t.InitialVelocity = JumpArc.CalculateInitialVelocity(0, 0, 0);
        }
        GUILayout.EndArea();
        GUILayout.EndVertical();
        Handles.EndGUI();
        //Debug.Log("onscenegui");
        //GUILayout.b
        
    }   
}
