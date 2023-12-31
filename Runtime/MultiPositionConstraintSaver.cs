// <auto-generated/>

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace UnityEngine.Animations.Rigging.Saving
{
    public class MultiPositionConstraintSaver : MonoBehaviour
    {
        [SerializeField] private List<string> transformPathes = new List<string>(capacity:PropertyCount);
        [SerializeField] private MultiPositionConstraint target;
        
        private const int PropertyCount = 1;
        [SerializeField] private int AllPropertyCount = PropertyCount;
        
        private void Awake()
        {
            var root = transform.root;

            if (!string.IsNullOrEmpty(transformPathes[0])) 
                target.data.constrainedObject = root.FindAnywhere(transformPathes[0]);

            if (AllPropertyCount > PropertyCount)
            {
                var copy = target.data.sourceObjects;
                for (int i = PropertyCount; i < AllPropertyCount; i++)
                    if(!string.IsNullOrEmpty(transformPathes[i])) 
                        copy.SetTransform(i - PropertyCount, root.FindAnywhere(transformPathes[i]));
                target.data.sourceObjects = copy;
            }
            
            Destroy(this);
        }
        
    #if UNITY_EDITOR
        private void OnValidate()
        {
            if (!ComponentsHelpers.CouldValidate(target)) return;
            
            //reset
            transformPathes.Clear();
            AllPropertyCount = PropertyCount;
            
            var trList = new[] {target.data.constrainedObject};
            for (int i = 0; i < PropertyCount; i++)
            {
                if (trList[i])
                    transformPathes.Add(AnimationUtility.CalculateTransformPath(trList[i], transform.root));
                else
                    transformPathes.Add(string.Empty);
            }


            int sourcesLength = target.data.sourceObjects.Count;
            if (sourcesLength > 0)
            {
                for (int i = 0; i < sourcesLength; i++)
                {
                    if (target.data.sourceObjects[i].transform)
                        transformPathes.Add(AnimationUtility.CalculateTransformPath(target.data.sourceObjects[i].transform, transform.root));
                    else
                        transformPathes.Add(string.Empty);
                }

                AllPropertyCount += sourcesLength;
            }
           
        }
    
        private void Reset() => OnValidate();
    
        [MenuItem("CONTEXT/MultiPositionConstraint/Transfer motion to smth", false, 612)]
        public static void TransferMotionToConstraint(MenuCommand command)
        {
            var sourceScript = command.context as MultiPositionConstraint;
            var thisScript = sourceScript.gameObject.AddComponent< MultiPositionConstraintSaver>();
            thisScript.target = sourceScript;
            thisScript.Reset();
        }
        
    #endif
        }
    }