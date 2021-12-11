using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class AssetManager
    {
        private const int MaxInstallRequest = 20;
        public static int Timeout;
        private static byte[] _preallocatedBuffer;
        private static List<IAssetRequestItem> _errorRequestList;
        private static LinkedList<RequestItemPacket> _requestList;
        private static RequestItemPacket _requestPacket;
        private static RequestItemPacket _dependencyRequestPacket;
        private static UnityEngine.Object _waitObject;
        private static AssetBundleDownloadManifest _defaultManifest;
        private static bool _cacheEnabled;
        private static Dictionary<string, AssetBundleDownloadManifest> _installedTable;
        private static bool _ready;
        private static List<RequestItemPacket> _removePackets;
        private static List<Shader> _shaders;
        public static bool fence;
        public AssetManager.OnRequestError onRequestError;

        public static string editorPath
        {
            get {
                var path = Path.Combine(StartupSettings.assetBundleTargetURI, "AssetBundles/Editor");
                if (Path.IsPathRooted(StartupSettings.assetBundleTargetURI))
                    return path;
                var currDir = Directory.GetCurrentDirectory();
                path = Path.Combine(currDir, path);
                return Path.GetFullPath(path);
            }
        }

        public static string cachePath
        {
            get {
                string ret = string.Empty;
                if(_cacheEnabled)
                    ret = Application.persistentDataPath + "/Cache";
                if (StartupSettings.assetBundleTarget == AssetBundleTarget.StreamingAssets)
                    ret = Application.streamingAssetsPath + "/AssetAssistant";
                else {
                    if (string.IsNullOrEmpty(StartupSettings.assetBundleTargetURI))
                    {
                        ret = Directory.GetCurrentDirectory() + "/AssetBundles/" + StartupSettings.platformName;
                    }
                    else { 
                        ret = StartupSettings.assetBundleTargetURI + "/AssetBundles/" + StartupSettings.platformName;
                    }
                    if (!Path.IsPathRooted(ret)) 
                        ret = Path.GetFullPath(Directory.GetCurrentDirectory() + ret);
                }
                return ret;
            }
        }

        public static string buitinAssetsPath
        {
            get => Application.streamingAssetsPath + "/AssetAssistant";
        }

        public static AssetBundleDownloadManifest defaultDownloadManifest
        {
            get => _defaultManifest;
        }

        public static Shader FindShader(string name) {

            return _shaders.Find(x => x.name == name);
        }

        public static bool isReady
        {
            get => _ready;
        }

        public static bool canDispatch
        {
            get => _requestPacket == null;
        }

        [AssetAssistantInitializeMethod(0)]
        private static void Initialize()
        {
            //TODO
        }

        public static void ClearCacheFiles()
        {
            if (!Directory.Exists(cachePath)) return;
            Debug.Log("Clear All Cached AssetBundles");
            Directory.Delete(cachePath, true);
            if (!Directory.Exists(cachePath + "/" + Application.productName)) {
                Directory.CreateDirectory(cachePath + "/" + Application.productName);
            }
            foreach (var it in _installedTable.Values) {
                it.Clear();
            }
        }

        public static void Cleanup()
        {
            ClearCacheFiles();
        }

        private static IEnumerator SetupOperation() => (IEnumerator) null;

        public static InstallRequestItem Install(AssetBundleDownloadManifest manifest = null, string[] assetBundleNames = null)
        {
            if (_defaultManifest == null) return null;
            manifest.installAssetBundleRecords.Where(rec => rec.isBeginInstalled).ToArray();
            //TODO: figure out more
            return (InstallRequestItem) null;
        }

        public static string[] GetAllAssetBundleNames() 
        {
            if (Application.isPlaying) {
                if (StartupSettings.assetBundleTarget != AssetBundleTarget.AssetDatabase) { 
                    //_defaultManifest

                    //TODO
                }
            }
            return null;
        }

        public static string[] GetAssetBundleNamesWithVariant() => (string[]) null;

        public static bool IsExistAssetBundle(string assetBundleName) => new bool();

        public static string[] FindAssetBundleNames(string filter) => (string[]) null;

        public static bool IsCached(string assetBundleName) => new bool();

        private static AssetBundleDownloadManifest GetManifest(string path, out string fileName)
        {
            fileName = _defaultManifest.projectName;
            return _defaultManifest;
        }

        public static AssetRequestOperation AppendAssetBundleRequest(string assetBundleName, bool loadAllAssets = true, RequestEventCallback callback = null, string[] variants = null)
        {
            return (AssetRequestOperation) null;
        }

        public static AssetRequestOperation RequestAssetBundle(string assetBundleName, bool loadAllAssets = true, RequestEventCallback callback = null, string[] variants = null)
        {
            return (AssetRequestOperation) null;
        }

        public static AssetRequestOperation RequestAsset(string assetPath, RequestEventCallback callback = null)
        {
            return (AssetRequestOperation) null;
        }

        public static AssetRequestOperation AppendAssetRequest(string assetPath, RequestEventCallback callback = null)
        {
            return (AssetRequestOperation) null;
        }

        public static AssetRequestOperation DispatchRequests(RequestEventCallback callback = null)
        {
            return (AssetRequestOperation) null;
        }

        public static AssetBundleCache LoadAssetBundle(string assetBundleName) => (AssetBundleCache) null;

        private static AssetBundleCache LoadAssetBundle(AssetBundleDownloadManifest manifest, AssetBundleRecord record, bool loadAllAssets = true, bool loadDependency = true, string[] variants = null)
        {
            return (AssetBundleCache) null;
        }

        public static UnityEngine.Object LoadAsset(string assetPath, bool cached = false) => (UnityEngine.Object) null;

        public static int UnloadAssetBundleAtAssetPath(string assetPath) => new int();

        public static int UnloadAssetBundle(string assetBundleName) => new int();

        private static void Update(float deltaTime)
        {
            //
        }

        private static AssetBundleRecord GetAssetBundleRecord(AssetBundleDownloadManifest manifest, string assetBundleName)
        {
            return (AssetBundleRecord) null;
        }

        private static void OnStreamWriteFinished(IAsyncResult asyncResult)
        {
            //
        }

        private static bool ProcessRequestItem(IAssetRequestItem requestItem) => new bool();

        public static string RemapVariantName(string assetBundleName, string[] variants) => (string) null;

        public static void OnResumeSingleton()
        {
            //
        }

        private static void OnDestroy()
        {
            //
        }

        public AssetManager()
        {
            //
        }

        public delegate void OnRequestError();
    }
}
