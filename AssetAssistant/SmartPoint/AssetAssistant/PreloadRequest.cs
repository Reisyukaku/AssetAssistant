using System;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    [Serializable]
    public struct PreloadRequest
    {
        [SerializeField]
        public string assetBundleName;
        [SerializeField]
        public bool loadAllAssets;

        public PreloadRequest(string assetBundleName, bool loadAllAssets)
        {
            this.assetBundleName = assetBundleName;
            this.loadAllAssets = loadAllAssets;
        }
    }
}
