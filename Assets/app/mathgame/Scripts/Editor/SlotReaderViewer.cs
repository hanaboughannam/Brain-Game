using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SlotReader))]
public class SlotReaderViewer : Editor
{
    public override void OnInspectorGUI()
    {
        
        SlotReader reader = (SlotReader)target;

        EditorGUILayout.LabelField(reader.ReadallSlots());

        Repaint();

        base.OnInspectorGUI();
    }
}
