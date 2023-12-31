// <auto-generated/>

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace UnityEngine.Animations.Rigging.Saving
{
    public class MultiAimConstraintSaver : MonoBehaviour
    {
        [SerializeField] private string[] transformPathes = new string[PropertyCount];
        [SerializeField] private  MultiAimConstraint target;
        
        private const int PropertyCount = 2;
        [SerializeField] private int AllPropertyCount = PropertyCount;
    
        private void Awake()
        {
            var root = transform.root;
           if (!string.IsNullOrEmpty(transformPathes[0]))
                target.data.constrainedObject = root.FindAnywhere(transformPathes[0]);
           if (!string.IsNullOrEmpty(transformPathes[1]))
               target.data.worldUpObject = root.FindAnywhere(transformPathes[1]);

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
            transformPathes = new string[PropertyCount + target.data.sourceObjects.Count];
            AllPropertyCount = PropertyCount;
            
            var trList = new[] {target.data.constrainedObject,target.data.worldUpObject};
            for (int i = 0; i < PropertyCount; i++)
            {
                if (trList[i])
                    transformPathes[i] = (AnimationUtility.CalculateTransformPath(trList[i], transform.root));
                else
                    transformPathes[i] = (string.Empty);
            }


            int sourcesLength = target.data.sourceObjects.Count;
            if (sourcesLength > 0)
            {
                for (int i = 0; i < sourcesLength; i++)
                {
                    if (target.data.sourceObjects[i].transform)
                        transformPathes[i+PropertyCount] = (AnimationUtility.CalculateTransformPath(target.data.sourceObjects[i].transform, transform.root));
                    else
                        transformPathes[i+PropertyCount] =(string.Empty);
                }

                AllPropertyCount += sourcesLength;
            }
        }
    
        private void Reset() => OnValidate();
    
        [MenuItem("CONTEXT/MultiAimConstraint/Transfer motion to smth", false, 612)]
        public static void TransferMotionToConstraint(MenuCommand command)
        {
            var sourceScript = command.context as MultiAimConstraint;
            var thisScript = sourceScript.gameObject.AddComponent< MultiAimConstraintSaver>();
            thisScript.target = sourceScript;
            thisScript.Reset();
        }
#endif
        }
    }