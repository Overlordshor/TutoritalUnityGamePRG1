using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainGenerator))]
public class TerrainGeneratorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        var target = (TerrainGenerator)base.target;

        base.OnInspectorGUI();

        if (GUILayout.Button("Generate"))
        {
            target.Render();
        }
    }
}