using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public static class Reflection
    {
        public static MethodInfo[] FindDelegateMethods<T>() where T : class, ICloneable, ISerializable {
            List<MethodInfo> info = new List<MethodInfo>();
            var invoke = typeof(T).GetMethod("Invoke");
            if(invoke == null)
                return ArrayHelper.Empty<MethodInfo>();
            var inv = invoke.MakeGenericMethod(invoke.GetGenericArguments().GetType()).Invoke(invoke, invoke.GetGenericArguments());
            //TODO
            return info.ToArray();
        }
    }
}
