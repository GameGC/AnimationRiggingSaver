using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace UnityEditor.Animations.Rigging.Saving
{
    public class WrappedCustomEditor<T, TS> : Editor where T : MonoBehaviour where TS : MonoBehaviour
    {
        private static Assembly _asm;
        private static FieldInfo _fieldInfo;

        private Editor _wrappedEditor;


        private void OnEnable()
        {
            if (_asm == null)
                _asm = AppDomain.CurrentDomain.Load(
                    "Unity.Animation.Rigging.Editor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");

            if (_fieldInfo == null)
                _fieldInfo = typeof(CustomEditor).GetField("m_InspectedType",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            var editor = _asm.GetTypes().First(t =>
            {
                if (!t.IsClass) return false;
                var attributes = t.GetCustomAttributes(typeof(CustomEditor), false);
                if (attributes.Length > 0)
                {
                    if (attributes[0] is CustomEditor ce)
                        return _fieldInfo.GetValue(ce) == typeof(T);
                }

                return false;
            });

            Editor.CreateCachedEditorWithContext(targets, serializedObject.context, editor,ref _wrappedEditor);
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            _wrappedEditor.OnInspectorGUI();
            if (EditorGUI.EndChangeCheck() && !UnityEngine.Application.isPlaying)
                if (target is T t)
                    t.GetComponent<TS>()?.Invoke("OnValidate", 0);
        }
    }
}