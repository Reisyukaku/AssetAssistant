using System.Collections;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class AssetBundleInstantiator : MonoBehaviour
    {
        [SerializeField]
        public string assetBundleName;

        [SceneRestoreOperationMethod]
        private IEnumerator RestoreOperation(SceneEntity entity)
        {
            AssetManager.AppendAssetBundleRequest(assetBundleName);
            AssetManager.DispatchRequests();
            yield return null;
            //???
            yield return null;
            //???

        }

        public virtual void OnFinished()
        {
            throw new NotImplementedException();
        }
    }
}
