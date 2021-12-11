using SmartPoint.AssetAssistant.UnityExtensions;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SmartPoint.AssetAssistant
{
    public class SceneEntity : RefCounted
    {
        private SceneDatabase.SceneProperty _property;
        private Scene _scene;
        private bool _isRequested;
        private bool _isLoaded;
        private GameObject _suspendObject;
        private SceneEntity[] _includes;
        private Dictionary<MonoBehaviour, Queue<Operation>> _activateOperations;

        public SceneEntity(string sceneName) : base()
        {
            includes = ArrayHelper.Empty<SceneEntity>();
            _activateOperations = new Dictionary<MonoBehaviour, Queue<Operation>>();
            SceneDatabase.SceneProperty prop;
            SceneDatabase.GetAllSceneProperty().TryGetValue(sceneName, out prop);
            _property = prop;
        }

        public string path
        {
            get => _property.scenePath;
        }

        public SceneDatabase.SceneProperty property
        {
            get => _property;
        }

        public GameObject cluster
        {
            get => _suspendObject;
        }

        public SceneEntity[] includes
        {
            get => _includes; 
            set => _includes = value;
        }

        public bool isRequested
        {
            get => _isRequested;
            set => _isRequested = value;
        }

        public Transform clusterRootTransform
        {
            get => _suspendObject.transform;
        }

        public bool isLoaded
        {
            get => _isLoaded;
            set => _isLoaded = value;
        }

        public MonoBehaviour[] FindScripts() {
            //TODO:
            return null;
        }

        public bool isActivatable
        {
            get {
                if (_includes.Length < 1) 
                    return CanActivate();
                bool ret = false;
                foreach (var i in _includes) {
                    if (i.CanActivate()) {
                        ret = true;
                        break;
                    }
                }

                return ret;
            }
        }

        private bool CanActivate() => new bool();

        private bool CanDeactivate() => new bool();

        public GameObject[] GetRootGameObjects() => (GameObject[]) null;

        public void Suspend()
        {
        }

        public void Resume()
        {
        }

        private class Operation
        {
            public MonoBehaviour behaviour;
            public MethodInfo method;
            public Coroutine coroutine;

            public Operation()
            {
                //
            }
        }
    }
}
