using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SmartPoint.AssetAssistant
{
    public class SceneBrowser
    {
        private static Dictionary<string, SceneEntity> _sceneEntities;
        private static SceneEntity _targetScene;
        private static SceneEntity _currentScene;
        private static HashSet<SceneEntity> _requestScenes;
        private static List<SceneEntity> _removedScenes;
        private static Stack<string> _sceneHistory;
        private static bool _startupSceneChanged;
        private static List<MethodInfo> _sceneRestoreOperationMethods;
        private static List<MethodInfo> _sceneBeforeActivateOperationMethods;
        private static Scene _initialScene;
        private static List<Coroutine> _changeSceneCoroutines;

        private static event SceneBrowser.ChangeSceneCallback _sceneNavigated
        {
            add
            {
            }
            remove
            {
            }
        }

        private static event SceneBrowser.ChangeSceneCallback _beforeSceneChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        private static event SceneBrowser.PrepareForSceneSwitching _prepareForSceneSwitching
        {
            add
            {
            }
            remove
            {
            }
        }

        public static bool hasHistory
        {
            get => new bool();
        }

        public static string[] histories
        {
            set { }
        }

        public static SceneEntity currentScene
        {
            get => (SceneEntity) null;
        }

        public static bool isRequested
        {
            get => new bool();
        }

        public static MethodInfo GetSceneRestoreOperationMethod(Type type) => (MethodInfo) null;

        public static MethodInfo GetSceneBeforeActivateOperationMethod(Type type) => (MethodInfo) null;

        public static event SceneBrowser.ChangeSceneCallback sceneNavigated
        {
            add
            {
            }
            remove
            {
            }
        }

        public static event SceneBrowser.ChangeSceneCallback beforeSceneChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        public static event SceneBrowser.PrepareForSceneSwitching prepareForSceneSwitching
        {
            add
            {
            }
            remove
            {
            }
        }

        [AssetAssistantInitializeMethod(0)]
        private static void Initialize()
        {
            //
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            //
        }

        private static IEnumerator WaitForAssetReady() => (IEnumerator) null;

        private static void Update(float deltaTime)
        {
            //
        }

        private static bool IsFinishedPrepareForSceneSwitching() => new bool();

        private static void SuspendSceneObjects(SceneEntity scene)
        {
            //
        }

        private static void ResumeSceneObjects(SceneEntity scene)
        {
            //
        }

        public static SceneEntity Open(string scenePath, bool useSubScene = true) => (SceneEntity) null;

        public void Close(SceneEntity entity)
        {
            //
        }

        public static void Close(Component component)
        {
            //
        }

        private static void UnloadScene(SceneEntity scene)
        {
            //
        }

        private static void UnloadScenes(SceneEntity scene)
        {
            //
        }

        private static SceneEntity AppendScene(string scenePath, bool useSubScene) => (SceneEntity) null;

        private static string GetFullPath(string sceneName) => (string) null;

        private static void RequestScene(SceneEntity scene)
        {
            //
        }

        private static SceneEntity Open(string scenePath, bool noHistory, bool navigate, bool useSubScene = true)
        {
            return (SceneEntity) null;
        }

        public static SceneEntity Navigate(string scenePath, bool noHistory = false) => (SceneEntity) null;

        public static bool CanBack() => new bool();

        public static bool GoBack() => new bool();

        private static void OnSceneUnloaded(Scene scene)
        {
            //
        }

        public static GameObject InstantiateTo(Scene scene, UnityEngine.Object asset) => (GameObject) null;

        public static SceneEntity GetEntity(string path) => (SceneEntity) null;

        public static SceneEntity GetEntity(Component compoent) => (SceneEntity) null;

        public SceneBrowser()
        {
            //
        }

        public delegate void ChangeSceneCallback(SceneEntity currentScene, SceneEntity targetScene);
        public delegate IEnumerator PrepareForSceneSwitching(
        SceneEntity currentScene,
        SceneEntity targetScene);
    }
}
