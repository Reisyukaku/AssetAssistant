
using UnityEngine.Networking;

namespace SmartPoint.AssetAssistant
{
    public class InstallRequestItem : IAssetRequestItem
    {
        public InstallRequestItem(AssetBundleDownloadManifest _cacheManifest, string _uri)
        {
            //
        }

        public RequestStatus status
        {
            get => new RequestStatus();
            set
            {
            }
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
            get => (string) null;
            set
            {
            }
        }

        public InstallItem[] items
        {
            get => items;
        }

        public long installSize
        {
            get => new long();
            set
            {
            }
        }

        public long totalSize
        {
            get => new long();
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

        public bool isComplete
        {
            get => new bool();
        }

        public float progress
        {
            get => new float();
        }

        public class InstallItem
        {
            public AssetBundleRecord record;
            public UnityWebRequest webRequest;
            public bool send;

            public InstallItem()
            {
                //
            }
        }
    }
}
