using System;
using System.Collections.Generic;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class SceneDatabase : SingletonScriptableObject<SceneDatabase>
    {
        [SerializeField]
        private SceneProperty[] _properties;
        [NonSerialized]
        private static Dictionary<string, SceneProperty> _sceneDictionary;

        protected override void OnEnable()
        {
            //
        }

        public void InternalUpdate()
        {
            //
        }

        public static bool Contains(string scenePath) => new bool();

        public static string GUIDToPath(string guid) => (string) null;

        public static bool IsExist(string scenePath) => new bool();

        public static SceneProperty GetProperty(string scenePath) => (SceneProperty) null;

        public static string GetAssetBundleName(string scenePath) => (string) null;

        public static void AddProperty(string path)
        {
            //
        }

        public static Dictionary<string, SceneProperty> GetAllSceneProperty()
        {
            return _sceneDictionary;
        }

        public SceneDatabase()
        {
            //
        }

        [Serializable]
        public class SceneProperty
        {
            [SerializeField]
            private string _scenePath;
            [SerializeField]
            private string _guid;
            [SerializeField]
            private string _assetBundleName;
            [SerializeField]
            private bool _dontDiscard;
            [SerializeField]
            private bool _leaveHistory;
            [SerializeField]
            private string[] _includes;

            public string scenePath
            {
                get => _scenePath;
                set => _scenePath = value;
            }

            public string guid
            {
                get => _guid;
                set => _guid = value;
            }

            public string assetBundleName
            {
                get => _assetBundleName;
                set => _assetBundleName = value;
            }

            public bool dontDiscard
            {
                get => _dontDiscard;
                set => _dontDiscard = value;
            }

            public bool leaveHistroy
            {
                get => _leaveHistory;
                set => _leaveHistory = value;
            }

            public string[] includes
            {
                get => _includes;
                set => _includes = value;
            }

            public SceneProperty()
            {
                //
            }
        }
    }
}
