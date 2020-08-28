﻿using UnityEditor;
using UnityEngine;

namespace Toolbox.Editor.Drawers
{
    /// <summary>
    /// Base class for Toolbox drawers based on the native <see cref="PropertyDrawer"/> implementation. 
    /// </summary>
    public abstract class ToolboxNativePropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// Safe GUI method. Provided property is previously validated by the <see cref="IsPropertyValid(SerializedProperty)"/> method.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="property"></param>
        /// <param name="label"></param>
        protected virtual void OnGUISafe(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);
        }


        /// <summary>
        /// Native OnGUI call to draw provided property.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="property"></param>
        /// <param name="label"></param>
        public override sealed void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (IsPropertyValid(property))
            {
                OnGUISafe(position, property, label);
            }
            else
            {
                var warningContent = new GUIContent(property.displayName + " has invalid property drawer");
                ToolboxEditorLog.WrongAttributeUsageWarning(attribute, property);
                ToolboxEditorGui.DrawEmptyProperty(position, property, warningContent);
            }
        }


        /// <summary>
        /// Checks if provided property can be properly handled by this drawer.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public virtual bool IsPropertyValid(SerializedProperty property)
        {
            return true;
        }
    }
}