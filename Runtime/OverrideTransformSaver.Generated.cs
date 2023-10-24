// <auto-generated/>
using UnityEngine;
using UnityEngine.Animations.Rigging;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.Animations.Rigging.Saving
{
    public class OverrideTransformSaver : MonoBehaviour
    {
        [SerializeField] private string[] transformPathes = new string[PropertyCount];
        [SerializeField] private OverrideTransform target;
        
        private const int PropertyCount = 2;
    
        private void Awake()
        {
            var root = transform.root; 
            if (!string.IsNullOrEmpty(transformPathes[0]))
                target.data.constrainedObject = root.Find(transformPathes[0]); 
            if (!string.IsNullOrEmpty(transformPathes[1]))
               target.data.sourceObject = root.Find(transformPathes[1]);

            Destroy(this);
        }
        
    #if UNITY_EDITOR
        private void OnValidate()
        {
            if(Application.isPlaying) return;
            if(target == null) return;
            var trList = new[] {target.data.constrainedObject,target.data.sourceObject};
             for (int i = 0; i < PropertyCount; i++)
            {
                if (trList[i])
                    transformPathes[i] = AnimationUtility.CalculateTransformPath(trList[i], transform.root);
            }
           
        }
    
        private void Reset() => OnValidate();
    
        [MenuItem("CONTEXT/OverrideTransform/Transfer motion to smth", false, 612)]
        public static void TransferMotionToConstraint(MenuCommand command)
        {
            var sourceScript = command.context as OverrideTransform;
            var thisScript = sourceScript.gameObject.AddComponent< OverrideTransformSaver>();
            thisScript.target = sourceScript;
            thisScript.Reset();
        }
        
    #endif
        }
    }