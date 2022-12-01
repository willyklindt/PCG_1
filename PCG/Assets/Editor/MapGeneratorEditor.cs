using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DungeonStorage), true)]

public class MapGeneratorEditor : Editor
{
    DungeonStorage storage;

    private void Awake()
    {
        storage = (DungeonStorage)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create Dungeon"))
        {
            storage.MapGenerator();
        }
    }
}
