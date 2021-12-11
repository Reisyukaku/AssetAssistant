using System;
using System.Collections.Generic;

namespace SmartPoint.AssetAssistant
{
    public class AssetBundleMemory
    {
        [NonSerialized]
        private static Dictionary<string, byte[]> _memoryLookupFromAssetPath;

        public static bool LoadFromFile(string path) => new bool();

        public static bool GetBuffer(string path, out byte[] buffer) {
            return _memoryLookupFromAssetPath.TryGetValue(path, out buffer);
        }

        public AssetBundleMemory()
        {
            _memoryLookupFromAssetPath = new Dictionary<string, byte[]>();
        }
    }
}
