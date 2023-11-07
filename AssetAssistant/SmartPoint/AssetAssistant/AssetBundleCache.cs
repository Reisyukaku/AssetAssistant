using SmartPoint.AssetAssistant.UnityExtensions;
using System.ComponentModel;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SmartPoint.AssetAssistant
{
    public class AssetBundleCache : RefCounted
    {
        private static Dictionary<string, AssetBundleCache> container { get; set; }
        private bool unloadAllLoadedObjects { get; set; }

        public Object loadedFirstAsset => loadedAssets[0];
        public Object[] loadedAssets { get; set; }
        public string[] variants { get; }
        public string[] remapDependencies { get;  }

        public bool allLoaded
        {
            get {
                bool ret = false;
                if (loadedAssets.Length < 1)
                    ret = true;
                else {
                    int i = 0;
                    for (i = 0; i < loadedAssets.Length; i++)
                    {
                        if (loadedAssets[i] != null) break;
                    }
                    if (i == loadedAssets.Length - 1) ret = true;
                }
                return ret;
            }
        }

        public AssetBundleRecord record { get; set; }
        public AssetBundle assetBundle { get; set; }
        public bool isLoaded { get; set; }

        public bool canLoadAsset
        {
            get {
                bool ret = false;
                int i = 0;
                foreach (string d in remapDependencies) {
                    
                    if (!string.IsNullOrEmpty(d)) {
                        AssetBundleCache cache;
                        var val = container.TryGetValue(d, out cache);
                        if (!val || cache == null) break;
                    }
                    if (++i >= remapDependencies.Length)
                        ret = true;
                }
                return ret;
            }
        }

        private AssetBundleCache() : base()
        {
            loadedAssets = ArrayHelper.Empty<Object>();
            container = new Dictionary<string, AssetBundleCache>();
        }

        public override int Release() 
        {
            if (referencedCount == 1) {
                unloadAllLoadedObjects = false;
                return referencedCount;
            }
            Debug.Log("Unload asset-bundle:" + record.assetBundleName);
            record = null;
            if (assetBundle != null) {
                assetBundle.Unload(unloadAllLoadedObjects);
                assetBundle = null;
            }
            referencedCount--;
            return referencedCount;
        }

        public static bool Contains(string assetBundleName, bool includeNotLoaded = false)
        { 
            AssetBundleCache c = null;
            if(!string.IsNullOrEmpty(assetBundleName)) 
                container.TryGetValue(assetBundleName, out c);
            return c != null;
        }

        public static AssetBundleCache Add(AssetBundleRecord record, bool isLoaded = false, string[] variants = null)
        {
            return (AssetBundleCache) null;
        }

        public static AssetBundleCache Get(string assetBundleName, bool includeNotLoaded = false)
        {
            return (AssetBundleCache) null;
        }

        public static int ReleaseFromAssetBundleChache(AssetBundleCache cache, bool unloadAllLoadedObjects = false)
        {
            int ret = 0;
            foreach (var dep in cache.record.allDependencies)
            {
                AssetBundleCache c;
                if (!string.IsNullOrEmpty(dep))
                {
                    if (container.TryGetValue(dep, out c)) {
                        c.unloadAllLoadedObjects = unloadAllLoadedObjects;
                        c.Release();
                    }
                }
            }
            return ret;
        }

        public static int ReleaseFromAssetBundleName(string assetBundleName, bool unloadAllLoadedObjects = false)
        {
            int ret = 0;
            AssetBundleCache c;
            if (container.TryGetValue(assetBundleName, out c)) {
                ret = ReleaseFromAssetBundleChache(c, unloadAllLoadedObjects);
            }

            return ret;
        }

        public static void Destroy()
        {
            foreach(var c in container)
            {
                c.Value.assetBundle.Unload(true);
            }
            
            container.Clear();
        }
    }
}
