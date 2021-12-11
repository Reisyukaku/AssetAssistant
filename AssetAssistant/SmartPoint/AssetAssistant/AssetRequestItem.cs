using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class AssetRequestItem : IAssetRequestItem
    {
        public AssetRequestItem(AssetBundleDownloadManifest _manifest, string _assetName)
        {
            manifest = _manifest;
            uri = _assetName;
        }

        public Object asset
        {
            get;
            //TODO
        }

        public bool isComplete
        {
            get => status == RequestStatus.Complete;
        }

        public RequestStatus status
        {
            get => status;
            set => status = value;
        }

        public AssetBundleDownloadManifest manifest
        {
            get => (AssetBundleDownloadManifest) null;
            set
            {
            }
        }

        public string uri
        {
            get => uri;
            set => uri = value;
        }

        public string assetBundleName
        {
            get => assetBundleName;
            set => assetBundleName = value;
        }

        public AsyncOperation resourceRequest
        {
            get => (AsyncOperation) null;
            set
            {
            }
        }

        public RequestEventCallback callback
        {
            get => (RequestEventCallback) null;
            set
            {
            }
        }

        public string error
        {
            get => (string) null;
            set
            {
            }
        }
    }
}
