using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace UnityEngine.Animations.Rigging.Saving
{
    internal static class ComponentsHelpers
    {
#if UNITY_EDITOR
        public static bool CouldValidate(MonoBehaviour target)
        {
            if (Application.isPlaying) return false;
            if (target == null) return false;
            if (PrefabStageUtility.GetCurrentPrefabStage() != null) return false;
            if (!PrefabUtility.IsPartOfPrefabInstance(target.gameObject) && PrefabUtility.IsPartOfAnyPrefab(target.gameObject)) return false;
            return true;
        }
#endif

        public static Transform FindAnywhere(this Transform transform, string path)
        {
            var result = transform.Find(path);
            if (result) return result;
            var gameObject = transform.gameObject;
            Find(gameObject.scene, path, gameObject, ref result);
            return result;
        }

        private static void Find(Scene scene, string path, GameObject ignored, ref Transform result)
        {
            var rootObjects = scene.GetRootGameObjects();
            for (int i = 0, length = rootObjects.Length; i < length; i++)
            {
                if (ignored == rootObjects[i]) continue;
                if (path.Substring(0, path.IndexOf('/')) != rootObjects[i].name) continue;
                path = path.Substring(path.IndexOf('/')+1);
                
                result = rootObjects[i].transform.Find(path);
                if (result) break;
            }
        }
    }
}