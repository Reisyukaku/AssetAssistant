using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SmartPoint.Mathematics
{
    public class FastMath
    {
        public static Quaternion RotationAxis([In] ref Vector3 V, float angle) {
            float f = 1f / (float)Math.Sqrt((V.x * V.x) + (V.y * V.y) + (V.z * V.z));
            float x = V.x * f;
            float y = V.y * f;
            float z = V.z * f;
            float a = (float)Math.Sin(0.5 * angle);
            return new Quaternion(x * a, y * a, z * a, (float)Math.Cos(0.5 * angle));
        }

        public static Quaternion RotateZLocal([In] ref Quaternion Q, float Angle) {
            float x = (Q.x * (float)Math.Cos(Angle)) + (Q.y * (float)Math.Sin(Angle));
            float y = (Q.y * (float)Math.Cos(Angle)) - (Q.x * (float)Math.Sin(Angle));
            float z = (Q.w * (float)Math.Sin(Angle)) + (Q.z * (float)Math.Cos(Angle));
            float w = (Q.w * (float)Math.Cos(Angle)) - (Q.z * (float)Math.Sin(Angle));
            return new Quaternion(x, y, z, w);
        }

        public static Vector3 GetForwardVector([In] ref Quaternion Q) => new Vector3();

        public static Vector3 GetUpVector([In] ref Quaternion Q) => new Vector3();

        public static Vector3 GetRightVector([In] ref Quaternion Q) => new Vector3();

        public static Quaternion LookRotation([In] ref Vector3 forward) => new Quaternion();

        public static Quaternion LookRotation([In] ref Vector3 forward, [In] ref Vector3 up) => new Quaternion();

        public static float Dot([In] ref Vector2 V1, [In] ref Vector2 V2) => new float();

        public static float IntersectLine([In] ref Vector2 P1, [In] ref Vector2 V1, [In] ref Vector2 P2, [In] ref Vector2 V2)
        {
            return new float();
        }

        public static float Dot([In] ref Vector3 V1, [In] ref Vector3 V2) => new float();

        public static Vector3 Cross([In] ref Vector3 V1, [In] ref Vector3 V2) => new Vector3();

        public static Vector3 Normalize([In] ref Vector3 V) => new Vector3();

        public static Vector3 CrossNormalize([In] ref Vector3 V1, [In] ref Vector3 V2) => new Vector3();

        public static Vector3 CalculateFaceNormal([In] ref Vector3 V1, [In] ref Vector3 V2, [In] ref Vector3 V3)
        {
            return new Vector3();
        }

        public static Vector3 CalculateCentroid([In] ref Vector3 V1, [In] ref Vector3 V2, [In] ref Vector3 V3) => new Vector3();

        public static Matrix4x4 Reflection(float a, float b, float c, float d) => new Matrix4x4();

        public FastMath()
        {
        }
    }
}
