using SmartPoint.AssetAssistant.Forms;
using SmartPoint.AssetAssistant.UnityExtensions;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class StartupSettings : SingletonScriptableObject<StartupSettings>
    {
        [SerializeField]
        private string _platformName;
        [SerializeField]
        private bool _useSceneBrowser;
        [SerializeField]
        private MessageBoxManifestBase _messageBoxManifest;
        [SerializeField]
        private AssetBundleTarget _assetBundleTarget;
        [SerializeField]
        private string _assetBundleTargetURI;
        [SerializeField]
        private string[] _assetBundlesForEditor;
        [SerializeField]
        private string[] _externalProjectNames;
        [SerializeField]
        private bool _clearCacheFiles;
        [SerializeField]
        private bool _webhookInEditMode;
        [SerializeField]
        private string _webhookURL;
        [SerializeField]
        private int _minimumResolution;
        [SerializeField]
        private PreloadRequest[] _preloadRequests;
        [SerializeField]
        private SerializedMethod _preloadMethod;
        [SerializeField]
        private SerializedMethod[] _initializeMethods;
        [SerializeField]
        private SerializedMethod[] _assetManagerAfterSetupMethods;
        [SerializeField]
        private SerializedMethod[] _sceneRestoreOperationMethods;
        [SerializeField]
        private SerializedMethod[] _sceneBeforeActivateOperationMethods;
        [SerializeField]
        private string _startupScenePath;
        [SerializeField]
        private ReferenceObject[] _permanentObjects;
        [SerializeField]
        private bool _runBootSequence;
        [SerializeField]
        private static string _creationTime;
        [SerializeField]
        private static string _buildVersion;

        public static string platformName
        {
            get {
                string ret = string.Empty;
                if (instance != null)
                    ret = instance.name;
                return ret;
            }
        }

        public static MessageBoxManifestBase messageBoxManifest
        {
            get {
                if (instance == null) return null;
                return instance._messageBoxManifest;
            }
        }

        public static bool useSceneBrowser
        {
            get
            {
                if (instance == null) return true;
                return instance._useSceneBrowser;
            }
        }

        public static string assetBundleTargetURI
        {
            get
            {
                if (instance == null) return string.Empty;
                return instance._assetBundleTargetURI;
            }
        }

        public static string[] assetBundlesForEditor
        {
            get
            {
                if (instance == null) return ArrayHelper.Empty<string>();
                return instance._assetBundlesForEditor;
            }
        }

        public static string[] externalProjectNames
        {
            get
            {
                if (instance == null) return ArrayHelper.Empty<string>();
                return instance._externalProjectNames;
            }
        }

        public static AssetBundleTarget assetBundleTarget
        {
            get
            {
                if (instance == null) return AssetBundleTarget.AssetDatabase;
                return instance._assetBundleTarget;
            }
        }

        public static bool runBootSequence
        {
            get
            {
                if (instance == null) return false;
                return instance._runBootSequence;
            }
        }

        public static int minimumResolution
        {
            get
            {
                if (instance == null) return 0;
                return instance._minimumResolution;
            }
        }

        public static bool clearCacheFiles
        {
            get
            {
                if (instance == null) return false;
                return instance._clearCacheFiles;
            }
        }

        public static bool webhookInEditMode
        {
            get
            {
                if (instance == null) return false;
                return instance._webhookInEditMode;
            }
        }

        public static string webhookURL
        {
            get
            {
                if (instance == null) return string.Empty;
                return instance._webhookURL;
            }
        }

        public static string startupScenePath
        {
            get
            {
                if (instance == null) return string.Empty;
                return instance._startupScenePath;
            }
        }

        public static PreloadRequest[] preloadRequests
        {
            get
            {
                if (instance == null) return null;
                return instance._preloadRequests;
            }
        }

        public static SerializedMethod preloadMethod
        {
            get
            {
                if (instance == null) return new SerializedMethod();
                return instance._preloadMethod;
            }
        }

        public static SerializedMethod[] initializeMethods
        {
            get
            {
                if (instance == null) return ArrayHelper.Empty<SerializedMethod>();
                return instance._initializeMethods;
            }
        }

        public static SerializedMethod[] assetManagerAfterSetupMethods
        {
            get
            {
                if (instance == null) return ArrayHelper.Empty<SerializedMethod>();
                return instance._assetManagerAfterSetupMethods;
            }
        }

        public static SerializedMethod[] sceneRestoreOperationMethods
        {
            get
            {
                if (instance == null) return ArrayHelper.Empty<SerializedMethod>();
                return instance._sceneRestoreOperationMethods;
            }
        }

        public static SerializedMethod[] sceneBeforeActivateOperationMethods
        {
            get
            {
                if (instance == null) return ArrayHelper.Empty<SerializedMethod>();
                return instance._sceneBeforeActivateOperationMethods;
            }
        }

        public static ReferenceObject[] permanentObjects
        {
            get
            {
                if (instance == null) return null;
                return instance._permanentObjects;
            }
        }

        public static string buildVersion
        {
            get => _buildVersion;
            set => _buildVersion = value;
        }

        public static string creationTime
        {
            get => _creationTime;
            set => _creationTime = value;
        }

        public StartupSettings() : base()
        {
            _useSceneBrowser = true;
            _webhookURL = string.Empty;
            _preloadRequests = ArrayHelper.Empty<PreloadRequest>();
            _initializeMethods = ArrayHelper.Empty<SerializedMethod>();
            _assetManagerAfterSetupMethods = ArrayHelper.Empty<SerializedMethod>();
            _sceneRestoreOperationMethods = ArrayHelper.Empty<SerializedMethod>();
            _sceneBeforeActivateOperationMethods = ArrayHelper.Empty<SerializedMethod>();
            _startupScenePath = string.Empty;
            _permanentObjects = ArrayHelper.Empty<ReferenceObject>();
            _runBootSequence = true;
            _creationTime = string.Empty;
            _buildVersion = string.Empty;
        }
    }
}
