using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectSpawner))]
public class ObjectSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ObjectSpawner objectSpawner = (ObjectSpawner)target;
        if (GUILayout.Button("Generate x amount of objects"))
        {
            objectSpawner.GenerateAmountOfObjects();
        }

        if (GUILayout.Button("Generate random amount of objects"))
        {
            objectSpawner.GenerateObjects();
        }
    }
}
