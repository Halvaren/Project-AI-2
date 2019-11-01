using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CellDisplayer)), CanEditMultipleObjects]
public class CellDisplayerEditor : Editor
{
    SerializedProperty cellType;
    SerializedProperty forestPrefab;
    SerializedProperty mountainPrefab;

    private void OnEnable()
    {
        cellType = serializedObject.FindProperty("cellType");
        forestPrefab = serializedObject.FindProperty("forestPrefab");
        mountainPrefab = serializedObject.FindProperty("mountainPrefab");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(cellType);
        EditorGUILayout.PropertyField(forestPrefab);
        EditorGUILayout.PropertyField(mountainPrefab);
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed)
        {
            Object[] updatedObjects = serializedObject.targetObjects;
            foreach(Object updatedObject in updatedObjects)
            {
                ((CellDisplayer)updatedObject).ChangeCellContainer();
            }
        }
    }
}
