using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CellDisplayer)), CanEditMultipleObjects]
public class CellDisplayerEditor : Editor
{
    SerializedProperty cellType;

    /*SerializedProperty basicMaterial;
    SerializedProperty forestMaterial;
    SerializedProperty mountainMaterial;
    SerializedProperty waterMaterial;

    SerializedProperty basicMesh;
    SerializedProperty forestMesh;
    SerializedProperty mountainMesh;
    SerializedProperty waterMesh;

    SerializedProperty forestPrefab;
    SerializedProperty mountainPrefab;*/

    private void OnEnable()
    {
        cellType = serializedObject.FindProperty("cellType");

        /*basicMaterial = serializedObject.FindProperty("basicMaterial");
        forestMaterial = serializedObject.FindProperty("forestMaterial");
        mountainMaterial = serializedObject.FindProperty("mountainMaterial");
        waterMaterial = serializedObject.FindProperty("waterMaterial");

        basicMesh = serializedObject.FindProperty("basicMesh");
        forestMesh = serializedObject.FindProperty("forestMesh");
        mountainMesh = serializedObject.FindProperty("mountainMesh");
        waterMesh = serializedObject.FindProperty("waterMesh");

        forestPrefab = serializedObject.FindProperty("forestPrefab");
        mountainPrefab = serializedObject.FindProperty("mountainPrefab");*/
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(cellType);

        /*EditorGUILayout.PropertyField(basicMaterial);
        EditorGUILayout.PropertyField(forestMaterial);
        EditorGUILayout.PropertyField(mountainMaterial);
        EditorGUILayout.PropertyField(waterMaterial);

        EditorGUILayout.PropertyField(basicMesh);
        EditorGUILayout.PropertyField(forestMesh);
        EditorGUILayout.PropertyField(mountainMesh);
        EditorGUILayout.PropertyField(waterMesh);

        EditorGUILayout.PropertyField(forestPrefab);
        EditorGUILayout.PropertyField(mountainPrefab);*/

        serializedObject.ApplyModifiedProperties();

        if (GUI.changed)
        {
            Object[] updatedObjects = serializedObject.targetObjects;
            foreach(Object updatedObject in updatedObjects)
            {
                ((CellDisplayer) updatedObject).ChangeCellContainer();
            }
        }
    }
}
