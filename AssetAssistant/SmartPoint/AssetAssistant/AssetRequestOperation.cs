using System.Collections.Generic;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class AssetRequestOperation : CustomYieldInstruction
    {
        private IAssetRequestItem[] _requests;

        public IAssetRequestItem[] requests
        {
            get => _requests;
            set => _requests = value;
        }

        public IAssetRequestItem request(int i)
        {
            return _requests[i];
        }

        public AssetRequestItem AssetRequest(int i)
        {
            return (AssetRequestItem)_requests[i];
        }

        public AssetRequestItem[] assetRequests
        {
            get => (AssetRequestItem[]) _requests;
        }

        public AssetBundleRequestItem assetBundleRequest
        {
            get => (AssetBundleRequestItem) null;
        }

        public AssetBundleRequestItem[] assetBundleRequests
        {
            set { }
        }

        public AssetRequestOperation(IAssetRequestItem requestItem)
        {
        }

        public AssetRequestOperation(IAssetRequestItem[] requestItems)
        {
        }

        public AssetRequestOperation(List<IAssetRequestItem> requestItems)
        {
        }

        public override bool keepWaiting
        {
            get => new bool();
        }
    }
}
