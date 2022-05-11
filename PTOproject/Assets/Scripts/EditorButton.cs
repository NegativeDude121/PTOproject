using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelLayoutGenerator))]
public class EditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        LevelLayoutGenerator levelLayoutGenerator = (LevelLayoutGenerator)target;
        if(GUILayout.Button("Generate Map"))
        {
            levelLayoutGenerator.GenerateMap();
        }
    }
}
