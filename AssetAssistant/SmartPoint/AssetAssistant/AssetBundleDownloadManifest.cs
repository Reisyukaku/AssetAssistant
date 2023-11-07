using SmartPoint.AssetAssistant.UnityExtensions;
using UnityEngine;
using UnityEngine.Networking;

namespace SmartPoint.AssetAssistant
{
    [Serializable]
    public class AssetBundleDownloadManifest
    {
        private const int currentVersion = 6;

        [SerializeField]
        private int _version;

        [SerializeField]
        private string _projectName;

        [SerializeField]
        private AssetBundleRecord[] _records;

        [SerializeField]
        private string[] _assetBundleNamesWithVariant;

        private Dictionary<string, HashSet<string>> _variantMap;
        private Dictionary<string, AssetBundleRecord> _recordLookupFromAssetBundleName;
        private Dictionary<string, AssetBundleRecord> _recordLookupFromAssetPath;
        private bool _dirty;
        private string _path;
        private AssetBundleDownloadManifest _latest;

        public string projectName { get => _projectName; set => _projectName = value; }
        public string path { get => _path; set => _path = value; }
        public AssetBundleDownloadManifest latest { get => _latest; set => _latest = value; }
        public int recordCount { get => _records.Length; }
        public AssetBundleRecord[] records { get => _records; }
        public long totalSize
        {
            get
            {
                long size = 0;
                foreach (var r in _recordLookupFromAssetBundleName)
                    size += r.Value.size;
                return size;
            }
        }

        public long installSize
        {
            get
            {
                long size = 0;
                foreach (var r in _recordLookupFromAssetBundleName)
                    if (r.Value.isBeginInstalled) size += r.Value.size;
                return size;
            }
        }

        public int installCount
        {
            get
            {
                int cnt = 0;
                foreach (var r in records) cnt += r.isBeginInstalled ? 1 : 0;
                return cnt;
            }
        }

        public AssetBundleRecord[] installAssetBundleRecords
        {
            get
            {
                int latest = 0;
                foreach (var r in records)
                {
                    if (r.latest != null) latest++;
                }
                //TODO
                return null;
            }
        }

       
        public static AssetBundleDownloadManifest Load(byte[] data) {
            return (AssetBundleDownloadManifest)new MemoryStream(data).DeserializeBinaryFormatter();
        }

        public static AssetBundleDownloadManifest Load(string path, bool isSimulation = false)
        {
            AssetBundleDownloadManifest ret = null;
            if (path.IsUrl())
            {
                var web = UnityWebRequest.Get(path);
                web.SendWebRequest();
                while (!web.isNetworkError && !web.isHttpError) {
                    if (web.isDone) {
                        ret = Load(web.downloadHandler.data);
                    }
                }
            }
            else 
            {
                if (File.Exists(path)) {
                    ret = (AssetBundleDownloadManifest)new FileStream(path, FileMode.Open).DeserializeBinaryFormatter();
                }
            }
            if (ret._version != 6) ret.Clear();
            if (isSimulation) { 
                //TODO
            }
            ret.BuildLookupTables();
            return ret;
        }

        public static AssetBundleDownloadManifest Load(string targetPath, AssetBundleManifest other, OnRecordCreated callback)
        {
            AssetBundleDownloadManifest ret = new AssetBundleDownloadManifest();
            ret.LoadFromAssetBundleManifest(targetPath, other, callback);
            return ret;
        }

        public delegate void OnRecordCreated(AssetBundleRecord record);

        public string[] GetDependencies(string assetBundleName) => records.Where(x => x.assetBundleName == assetBundleName).FirstOrDefault().allDependencies;

        private void LoadFromAssetBundleManifest(string targetPath, AssetBundleManifest other, OnRecordCreated callback)
        {
            projectName = Path.GetFileNameWithoutExtension(targetPath);
            other.GetAllAssetBundles();
            other.GetAllAssetBundlesWithVariant();

            if (callback != null) {
                foreach (var bund in other.GetAllAssetBundles()) {
                    var hash = other.GetAssetBundleHash(bund);
                    RecordedHash.Parse(hash.ToString());
                }
            }
        }

        public void Save(string path)
        {
            if (_dirty) {
                if(!Directory.Exists(path.RemoveEnd(".bin"))){
                    Directory.CreateDirectory(path.RemoveEnd(".bin"));
                }
                new FileStream(path, FileMode.Create).SerializeBinaryFormatter(this);
            }
            _dirty = false;
        }

        public AssetBundleDownloadManifest()
        {
            _version = currentVersion;
            projectName = string.Empty;
            _assetBundleNamesWithVariant = ArrayHelper.Empty<string>();
            path = string.Empty;
            _records = ArrayHelper.Empty<AssetBundleRecord>();
            _recordLookupFromAssetBundleName = new Dictionary<string, AssetBundleRecord>();
            _dirty = false;
        }

        public void Append(string projectName, AssetBundleDownloadManifest appendManifest)
        {
            throw new NotImplementedException();
        }

        private void MarkDifference(AssetBundleDownloadManifest latestManifest)
        {
            throw new NotImplementedException();
        }

        private void BuildLookupTables()
        {
            _recordLookupFromAssetBundleName = _records.ToDictionary(x => x.assetBundleName);
            //_recordLookupFromAssetPath = ;
            _variantMap = new Dictionary<string, HashSet<string>>();
            //TODO
        }

        public AssetBundleRecord AddRecord(string projectName, string assetBundleName) => (AssetBundleRecord) null;

        public void Clear()
        {
            _records = ArrayHelper.Empty<AssetBundleRecord>();
            _recordLookupFromAssetBundleName?.Clear();
            _variantMap?.Clear();
            _recordLookupFromAssetPath = null;
            _version = 6;
            MarkDifference(latest);
        }

        public bool IsExist(string assetBundleName) => _recordLookupFromAssetBundleName.ContainsKey(assetBundleName);

        public string[] GetExists(string[] assetBundleNames)
        {
            throw new NotImplementedException();
        }

        public void RemoveRecords(string[] assetBundleNames)
        {
            throw new NotImplementedException();
        }

        public void RestrictRecords(string[] assetBundleNames)
        {
            throw new NotImplementedException();
        }

        public string[] GetAllAssetBundleNames()
        {
            throw new NotImplementedException();
        }

        public string[] GetAssetBundleNamesWithVariant()
        {
            throw new NotImplementedException();
        }

        public string FindMatchAssetBundleNameWithVariants(string assetBundleName, string[] variants)
        {
            throw new NotImplementedException();
        }

        public string GetAssetBundleNameAtPath(string path) {
            AssetBundleRecord rec = null;
            _recordLookupFromAssetPath.TryGetValue(path, out rec);
            string ret = string.Empty;
            if (rec != null) {
                ret = rec.assetBundleName;
            }
            return ret;
        }

        public AssetBundleRecord GetAssetBundleRecord(string assetBundleName) {
            AssetBundleRecord rec = null;
            _recordLookupFromAssetBundleName.TryGetValue(assetBundleName, out rec);
            return rec;
        }

        public AssetBundleRecord[] GetAssetBundleRecordsWithDependencies(string assetBundleName)
        {
            AssetBundleRecord rec = null;
            List<AssetBundleRecord> recList = new List<AssetBundleRecord>();

            _recordLookupFromAssetBundleName.TryGetValue(assetBundleName, out rec);
            if (rec == null) return ArrayHelper.Empty<AssetBundleRecord>();

            recList.Add(rec);

            foreach (var r in rec.allDependencies) {
                rec = null;
                _recordLookupFromAssetBundleName.TryGetValue(r, out rec);
                recList.Add(rec);
            }
            
            return recList.ToArray();
        }
    }
}
