using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace SmartPoint.AssetAssistant
{
    public class AssetBundleRequestItem : IAssetRequestItem
    {
        public AssetBundleRequestItem(AssetBundleDownloadManifest _manifest, string _uri, bool _loadAllAssets = true, bool _loadDependencies = true, string[] _variants = null)
        {
            //
        }

        public bool isComplete
        {
            get => new bool();
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

        public UnityWebRequest webRequest
        {
            get => (UnityWebRequest) null;
            set
            {
            }
        }

        public FileStream fileStream
        {
            get => (FileStream) null;
            set
            {
            }
        }

        public string[] variants
        {
        
            set
            {
            }
        }

        public bool loadAllAssets
        {
            get => new bool();
            set
            {
            }
        }

        public AssetBundleCache cache
        {
            get => (AssetBundleCache) null;
            set
            {
            }
        }

        public AssetBundleCreateRequest createRequest
        {
            get => (AssetBundleCreateRequest) null;
            set
            {
            }
        }

        public AsyncOperation assetRequest
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

        public CustomYieldInstruction customInstruction
        {
            get => (CustomYieldInstruction) null;
            set
            {
            }
        }
    }
}
