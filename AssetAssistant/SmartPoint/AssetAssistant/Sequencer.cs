using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SmartPoint.AssetAssistant
{
    public sealed class Sequencer : SingletonMonoBehaviour<Sequencer>
    {
        public const int StringBuilderCapaity = 1024;
        private static IUnityEditorProxy _editorProxy;
        private static List<(int, TickCallback)> _orderableList;
        private static Dictionary<Coroutine, Coroutine> _subToOwner;
        private static Dictionary<Coroutine, Coroutine> _ownerToSub;
        private static Coroutine _referenceCoroutine;
        private static List<UnityEngine.Object> _trashObjects;
        private static List<LogMessage> _messageList;
        private static Queue<string> _messageQueue;
        private static WebhookTarget _webhookTarget;
        private static bool _onetimeSkipFlag;
        public static EventCallback start;
        public static EventCallback onDestroy;
        public static EventCallback onFinalize;
        public static EventCallback applicationQuit;
        public static TickCallback earlyUpdate;
        public static TickCallback update;
        public static TickCallback afterUpdate;
        public static TickCallback earlyLateUpdate;
        public static TickCallback lateUpdate;
        public static TickCallback postLateUpdate;
        public static TickCallback onEndOfFrame;
        private static WaitForEndOfFrame waitForEndOfFrame;

        public static StringBuilder stringBuilder
        {
            get; private set;
        }

        public static float elapsedTime
        {
            get; private set;
        }

        public static int nativeScreenWidth
        {
            get; private set;
        }

        public static int nativeScreenHeight
        {
            get; private set;
        }

        public static float nativeAspectRatio
        {
            get; private set;
        }

        public static int screenWidth
        {
            get; private set;
        }

        public static int screenHeight
        {
            get; private set;
        }

        public static float aspectRatio
        {
            get; private set;
        }

        public static bool isSuspendUpdate
        {
            get; set;
        }

        [RuntimeInitializeOnLoadMethod]
        public static void Initialize()
        {
            waitForEndOfFrame = new WaitForEndOfFrame();
            Instantiate();
        }

        public static IUnityEditorProxy editorProxy //TODO: i know this isnt right
        {
            get {
                if (_editorProxy != null) return _editorProxy;
                Assembly asm = null;
                if (Application.isEditor) {
                    var t = Type.GetTypeFromHandle(typeof(IUnityEditorProxy).TypeHandle);
                    if (t.ToString().Contains("AssetAssistant.dll")) {
                        var uri = new Uri(Directory.GetCurrentDirectory() + '/');
                        var uri2 = new Uri(t.ToString().Replace("AssetAssistant.dll", "EditorAssetAssistant.dll"));
                        var finalUri = uri.MakeRelativeUri(uri2);
                        asm = Assembly.LoadFile(finalUri.ToString());
                    }
                    else {
                        asm = Assembly.LoadFile("Library/ScriptAssemblies/Assembly-CSharp-Editor.dll");
                    }
                    if (asm != null) {
                        var mod = asm.GetModule("SmartPoint.EditorAssetAssistant.UnityEditorProxy"); //TODO: This right???
                        _editorProxy = (IUnityEditorProxy)mod.GetMethod("GetInstance").Invoke(null, null);
                    }
                }
                return null;
            }
        }

        protected override bool Awake() => new bool();

        public static void SubscribeUpdate(int order, TickCallback callback)
        {
            var ind = _orderableList.FindIndex(x => x == (order, callback));
            if (ind == -1) 
            {
                _orderableList.Add((order, callback));
            }
            else
            {
                _orderableList.Insert(ind, (order, callback));
            }
        }

        public static void UnsubscribeUpdate(Sequencer.TickCallback callback)
        {
            var ind = _orderableList.FindIndex(x => x.Item2 == callback);
            if (ind == -1)
            {
                _orderableList.RemoveAt(ind);
            }
        }

        public static void Trash(UnityEngine.Object trashObject)
        {
            _trashObjects.Add(trashObject);
        }

        public static Coroutine Start(IEnumerator routine) {
            if (Instance == null) {
                Debug.LogError("Error: Sequencer is null");
                return null;
            }
            var rout = Instance.StartCoroutine(RunCoroutine(routine));
            if (_referenceCoroutine != null) {
                _ownerToSub.Add(rout, _referenceCoroutine);
            }
            return rout;
        }

        private static IEnumerator RunCoroutine(IEnumerator routine) { 
            while(true) yield return null;
        }

        public static void Stop(Coroutine coroutine)
        {
        }

        public static bool IsFinished(Coroutine coroutine) => new bool();

        private void Update()
        {
        }

        private IEnumerator AfterUpdate() => (IEnumerator) null;

        private void LateUpdate()
        {
        }

        private void OnDestroy()
        {
        }

        protected override void OnApplicationQuit()
        {
        }

        public static Component AddComponent(Type componentType) => (Component) null;

        public static T AddComponent<T>() where T : Component => (T) null;

        public static void RemoveComponent(Type componentType)
        {
        }

        public static void RemoveCompoent<T>() where T : Component
        {
        }

        private static void LogReceiver(string condition, string stackTrace, LogType type)
        {
        }

        public static LogMessage GetLastLog() {
            if (LogMessage.lastID <= 0 && _messageList.Count <= LogMessage.lastID) return null;
            return _messageList[LogMessage.lastID];
        }

        public static LogMessage[] GetLogs(int startID) {
            var cnt = LogMessage.lastID - startID;
            //TODO
            return null;
        }

        private string FormatMessage(string message) => (string) null;

        private IEnumerator LogSender(string url) => (IEnumerator) null;

        public static bool IntersectGUI(Vector3 position) => new bool();

        public static List<RaycastResult> GetIntersectGUIs(Vector3 position) => (List<RaycastResult>) null;

        public Sequencer() : base()
        {
            _editorProxy = null;
            _orderableList = new List<(int, TickCallback)>();
            _subToOwner = new Dictionary<Coroutine, Coroutine>();
            _ownerToSub = new Dictionary<Coroutine, Coroutine>();
            _referenceCoroutine = null;
            _trashObjects = new List<UnityEngine.Object>();
            _messageList = new List<LogMessage>();
            _messageQueue = new Queue<string>();
            _onetimeSkipFlag = true;
            stringBuilder = new StringBuilder();
            elapsedTime = 0f;
            waitForEndOfFrame = null;
        }

        public enum WebhookTarget
        {
            None,
            Discord,
            Slack,
        }

        public delegate void EventCallback();
        public delegate void TickCallback(float deltaTime);
    }
}
