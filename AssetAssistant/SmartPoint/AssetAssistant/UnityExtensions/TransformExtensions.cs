using System.Collections.Generic;
using UnityEngine;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public static class TransformExtensions
    {
        public static Bounds TransformBounds(this Matrix4x4 self, Bounds bounds) => new Bounds();

        public static Bounds InverseTransformBounds(this Transform self, Bounds bounds) => new Bounds();

        public static List<Vector3> GetCorners(this Bounds obj, bool includePosition = true) => (List<Vector3>) null;

        public static Vector3 Times(this Vector3 self, Vector3 other) => new Vector3();
    }
}
