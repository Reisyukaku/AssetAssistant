using System;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    [Serializable]
    public struct SerializedMethod
    {
        [SerializeField]
        private string _assemblyQualifiedName;
        [SerializeField]
        private string _methodName;
        [SerializeField]
        private bool _isStatic;

        public string assemblyQualifiedName
        {
            get => _assemblyQualifiedName;
            set => _assemblyQualifiedName = value;
        }

        public string methodName
        {
            get => _methodName;
            set => _methodName = value;
        }

        public bool isStatic
        {
            get => _isStatic;
            set => _isStatic = value;
        }

        public SerializedMethod(string assemblyQualifiedName, string methodName, bool isStatic)
        {
            _assemblyQualifiedName = assemblyQualifiedName;
            _methodName = methodName;
            _isStatic = isStatic;
        }

        public SerializedMethod(MethodInfo methodInfo)
        {
            _assemblyQualifiedName = methodInfo.Name;
            _methodName = methodInfo.Name;
            _isStatic = methodInfo.IsStatic;
        }

        public void Invoke()
        {
            GetMethodInfo()?.Invoke(null, null);
        }

        public void Invoke(object obj, object[] parameters)
        {
            GetMethodInfo()?.Invoke(obj, parameters);
        }

        public MethodInfo GetMethodInfo() {
            if (string.IsNullOrEmpty(assemblyQualifiedName)) return null;
            var t = Type.GetType(assemblyQualifiedName);
            if (t == null || string.IsNullOrEmpty(methodName)) return null;
            return t.GetMethod(methodName, isStatic ? BindingFlags.Static : BindingFlags.Instance);
        }

        public RuntimeMethodHandle GetMethod() => (RuntimeMethodHandle)(GetMethodInfo()?.MethodHandle);

        public T GetDelegate<T>() where T : class, ICloneable, ISerializable => (T) null;
    }
}
