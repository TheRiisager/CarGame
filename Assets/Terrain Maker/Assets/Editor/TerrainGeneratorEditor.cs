using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TerrainGenerator))]
public class TerrainGeneratorEditor : Editor
{
    public bool updateMyEditor;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TerrainGenerator terrainGenerator = (TerrainGenerator)target;

        updateMyEditor = EditorGUILayout.Toggle("Update On/Off", updateMyEditor);
        if (updateMyEditor == true)
        {
            terrainGenerator.GenerateTerrain();
        }
        else if (GUILayout.Button("Generate terrain"))
        {
            terrainGenerator.GenerateTerrain();
        }
    }
}


