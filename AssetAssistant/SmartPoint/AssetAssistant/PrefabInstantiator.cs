using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SmartPoint.AssetAssistant
{
    public class PrefabInstantiator : MonoBehaviour
    {
        [SerializeField]
        public Object prefab;

        public void Restore()
        {
            if (prefab) {
                GameObject instantiatedObject = (GameObject)Instantiate(prefab, transform.parent);
                if (instantiatedObject != null) {
                    instantiatedObject.name = prefab.name;
                    instantiatedObject.transform.localPosition = transform.localPosition;
                    instantiatedObject.transform.localScale = transform.localScale;
                    instantiatedObject.transform.localRotation = transform.localRotation;
                }
            }
        }

        [SceneRestoreOperationMethod]
        private IEnumerator RestoreOperation(SceneEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
