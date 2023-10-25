// <auto-generated/>
using UnityEngine;
using UnityEngine.Animations.Rigging;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace UnityEngine.Animations.Rigging.Saving
{
    public class TwoBoneIKConstraintSaver : MonoBehaviour
    {
        [SerializeField] private string[] transformPathes = new string[PropertyCount];
        [SerializeField] private  TwoBoneIKConstraint target;
        
        private const int PropertyCount = 5;
    
        private void Awake()
        {
            var root = transform.root; 
            if (!string.IsNullOrEmpty(transformPathes[0]))
                target.data.root = root.FindAnywhere(transformPathes[0]);
            if (!string.IsNullOrEmpty(transformPathes[1]))
                target.data.mid = root.FindAnywhere(transformPathes[1]);
            if (!string.IsNullOrEmpty(transformPathes[2]))
                target.data.tip = root.FindAnywhere(transformPathes[2]);
            if (!string.IsNullOrEmpty(transformPathes[3]))
                target.data.target = root.FindAnywhere(transformPathes[3]);
            if (!string.IsNullOrEmpty(transformPathes[4])) 
                target.data.hint = root.FindAnywhere(transformPathes[4]);

            Destroy(this);
        }
        
    #if UNITY_EDITOR
        private void OnValidate()
        {
            if (!ComponentsHelpers.CouldValidate(target)) return;
            var trList = new[] {target.data.root,target.data.mid,target.data.tip,target.data.target,target.data.hint};
             for (int i = 0; i < PropertyCount; i++)
            {
                if(trList[i])
                    transformPathes[i] = AnimationUtility.CalculateTransformPath(trList[i], transform.root);
            }
           
        }
    
        private void Reset() => OnValidate();
    
        [MenuItem("CONTEXT/TwoBoneIKConstraint/Transfer motion to smth", false, 612)]
        public static void TransferMotionToConstraint(MenuCommand command)
        {
            var sourceScript = command.context as TwoBoneIKConstraint;
            var thisScript = sourceScript.gameObject.AddComponent< TwoBoneIKConstraintSaver>();
            thisScript.target = sourceScript;
            thisScript.Reset();
        }

 		
    #endif
        }
    }