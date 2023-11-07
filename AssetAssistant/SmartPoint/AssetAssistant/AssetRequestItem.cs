using UnityEngine;
using Object = UnityEngine.Object;

namespace SmartPoint.AssetAssistant
{
    public class AssetRequestItem : IAssetRequestItem
    {
        public RequestStatus status { get; set; }
        public AssetBundleDownloadManifest manifest { get; set; }
        public string uri { get; set; }
        public string assetBundleName { get; set; }
        public AsyncOperation resourceRequest { get; set; }
        public RequestEventCallback callback { get; set; }
        public string error { get; set; }
        public Object asset { get; }
        public bool isComplete
        {
            get => status == RequestStatus.Complete;
        }

        public AssetRequestItem(AssetBundleDownloadManifest _manifest, string _assetName)
        {
            manifest = _manifest;
            uri = _assetName;
            assetBundleName = null;
        }
    }
}
