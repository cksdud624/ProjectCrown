using System.ComponentModel;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DisplayNameAttribute))]
public class DisplayNameDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        DisplayNameAttribute displayName = (DisplayNameAttribute)attribute;
        label.text = displayName.DisplayName;
        EditorGUI.PropertyField(position, property, label);
    }
}
