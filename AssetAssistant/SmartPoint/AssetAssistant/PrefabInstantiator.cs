using System.Collections;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class PrefabInstantiator : MonoBehaviour
    {
        [SerializeField]
        public Object prefab;

        public void Restore()
        {
            //
        }

        [SceneRestoreOperationMethod]
        private IEnumerator RestoreOperation(SceneEntity entity) => (IEnumerator) null;

        public PrefabInstantiator()
        {
            //
        }
    }
}
