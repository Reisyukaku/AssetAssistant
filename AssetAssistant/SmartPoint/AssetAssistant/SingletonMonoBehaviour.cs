using UnityEngine;
using UnityEngine.SceneManagement;

namespace SmartPoint.AssetAssistant
{
    [DisallowMultipleComponent]
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        protected static T _instance;
        private static Scene lastScene;

        public static bool isQuit
        {
            get => Instance.enabled;
            set => Instance.enabled = value;
        }

        public static bool isInstantiated
        {
            get => Instance != null;
        }

        public static GameObject GetGameObject() => (GameObject) null;

        public static T Instance
        {
            get => _instance;
        }

        protected virtual bool Awake() {
            //
            return true;
        }

        protected virtual void OnApplicationQuit()
        {
            isQuit = true;
        }

        public static T Instantiate(string instanceName = null, Transform parent = null) {
            if (!string.IsNullOrEmpty(instanceName)) {
                Instance.name = instanceName;
                if (parent != null) {
                    Instance.transform.SetParent(parent);
                }
            }
            return Instance;
        }

        protected SingletonMonoBehaviour()
        {
            //
        }
    }
}
