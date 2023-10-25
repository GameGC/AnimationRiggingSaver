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
            return PrefabStageUtility.GetCurrentPrefabStage() == null &&
                   PrefabUtility.IsPartOfPrefabInstance(target.gameObject);
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
                result = rootObjects[i].transform.Find(path);
                if (result) break;
            }
        }
    }
}
