using System;
using UnityEngine;

namespace SmartPoint.Mathematics
{
    public static class QuaternionExt
    {
        public static Quaternion FastNormalizeAxis(ref this Quaternion self) {
            var f = 1f / (float)Math.Sqrt((self.x * self.x) + (self.y * self.y) + (self.z * self.z));
            self.x *= f;
            self.y *= f;
            self.z *= f;
            return self;
        }

        public static Quaternion FastNormalize(ref this Quaternion self) {
            var f = 1f / (float)Math.Sqrt((self.x * self.x) + (self.y * self.y) + (self.z * self.z) + (self.w * self.w));
            self.x *= f;
            self.y *= f;
            self.z *= f;
            self.w *= f;
            return self;
        }

        public static Quaternion FastRotateY(ref this Quaternion self, float angle) {
            var c = (float)Math.Cos(0.5 * angle);
            var s = (float)Math.Sin(0.5 * angle);
            self.x = (self.x * c) + (self.z * s);
            self.y = (self.x * self.y) + (self.w * s);
            self.z = (self.z * c) - (self.x * s);
            self.w = (self.w * c) - (self.w * s);
            return self;
        }

        public static Quaternion FastRotationArc(ref this Quaternion self, Vector3 V1, Vector3 V2) {
            return new Quaternion();
        }
    }
}
