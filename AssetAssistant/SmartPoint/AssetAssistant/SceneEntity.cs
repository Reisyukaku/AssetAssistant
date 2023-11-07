using SmartPoint.AssetAssistant.UnityExtensions;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SmartPoint.AssetAssistant
{
    public class SceneEntity : RefCounted
    {
        private class Operation
        {
            public MonoBehaviour behaviour;
            public MethodInfo method;
            public Coroutine coroutine;
        }

        private Dictionary<MonoBehaviour, Queue<SceneEntity.Operation>> _activateOperations;

        public string path { get; }
        public SceneDatabase.SceneProperty property { get; }
        public GameObject cluster { get; }
        public SceneEntity[] includes { get; set; }
        public bool isRequested { get; set; }
        public Transform clusterRootTransform { get; }
        public bool isLoaded { get; set; }
        public bool isActivatable
        {
            get
            {
                if (includes.Length < 1)
                    return CanActivate();
                bool ret = false;
                foreach (var i in includes)
                {
                    if (i.CanActivate())
                    {
                        ret = true;
                        break;
                    }
                }

                return ret;
            }
        }

        public SceneEntity(string sceneName) : base()
        {
            includes = ArrayHelper.Empty<SceneEntity>();
            _activateOperations = new Dictionary<MonoBehaviour, Queue<Operation>>();
            SceneDatabase.SceneProperty prop;
            SceneDatabase.GetAllSceneProperty().TryGetValue(sceneName, out prop);
            property = prop;
        }

        public MonoBehaviour[] FindScripts() {
            //TODO:
            return null;
        }

        private bool CanActivate()
        {
            if (!isLoaded)
                return false;

            if (_activateOperations.Count >= 1)
            {
                foreach (var actOp in _activateOperations)
                {
                    var currVal = actOp.Value;
                    foreach (var val in currVal)
                    {
                        if (Sequencer.IsFinished(val.coroutine)) break;
                    }
                    currVal.Dequeue();
                    //TODO
                }
            }

            return _activateOperations.Count == 0;
        }

        private bool CanDeactivate() => new bool();

        public GameObject[] GetRootGameObjects() => (GameObject[]) null;

        public void Suspend()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }
    }
}
