using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenerateSentence))]
public class LSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GenerateSentence GS = (GenerateSentence)target;

        if (GUILayout.Button("Generate"))
        {
            GS.Generate();
        }

    }
}
