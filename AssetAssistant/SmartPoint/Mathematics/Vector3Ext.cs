using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SmartPoint.Mathematics
{
    public static class Vector3Ext {
        public static Vector3 FastClear(ref this Vector3 self) => new Vector3();

        public static Vector3 FastNegate(ref this Vector3 self) {
            return -self;
        }

        public static Vector3 FastReciprocal(ref this Vector3 self) {
            self.x = 1f / self.x;
            self.y = 1f / self.y;
            self.z = 1f / self.z;
            return self;
        }

        public static Vector3 FastSet(ref this Vector3 self, float s) => new Vector3(s, s, s);

        public static Vector3 FastSet(ref this Vector3 self, float x, float y, float z) => new Vector3(x, y, z);

        public static Vector3 FastAdd(ref this Vector3 self, [In] ref Vector3 V) {
            return self + V;
        }

        public static Vector3 FastScale(ref this Vector3 self, float s) {
            return self * s;
        }

        public static Vector3 FastMul(ref this Vector3 self, [In] ref Vector3 V) {
            self.x *= V.x;
            self.y *= V.y;
            self.z *= V.z;
            return self;
        }

        public static Vector3 FastScaleAdd(ref this Vector3 self, [In] ref Vector3 V, float s) {
            self.x += (V.x * s);
            self.y += (V.y * s);
            self.z += (V.z * s);
            return self;
        }

        public static Vector3 FastLerp(ref this Vector3 self, [In] ref Vector3 V, float s) {
            self.x += ((V.x - self.x) * s);
            self.y += ((V.y - self.y) * s);
            self.z += ((V.z - self.z) * s);
            return self;
        }

        public static float FastLengthSq([In] ref this Vector3 self) {
            return ((self.x * self.x) + (self.y * self.y) + (self.z * self.z));
        }

        public static float FastDistanceSq([In] ref this Vector3 self, [In] ref Vector3 V) {
            var dx = self.x - V.x;
            var dy = self.y - V.y;
            var dz = self.z - V.z;
            return dx * dx + dy * dy + dz * dz;
        }

        public static float FastLength([In] ref this Vector3 self) {
            return (float)Math.Sqrt((self.x * self.x) + (self.y * self.y) + (self.z * self.z));
        }

        public static float FastDot([In] ref this Vector3 self, [In] ref Vector3 V) {
            return ((self.x * V.x) + (self.y * V.y) + (self.z * V.z));
        }

        public static Vector3 FastCross(ref this Vector3 self, [In] ref Vector3 V) {
            self.x = (self.y * V.z) - (self.z * V.y);
            self.y = (self.z * V.x) - (V.z * self.x);
            self.z = (V.y * self.x) - (self.y * V.x);
            return self;
        }

        public static Vector3 FastCrossNormalize(ref this Vector3 self, [In] ref Vector3 V) {
            var x = (V.y * self.x) - (self.y * V.x);
            var y = (self.y * V.z) - (self.z * V.y);
            var z = (self.z * V.x) - (V.z * self.x);
            float f = 1f / (float)Math.Sqrt((x*x)+(y*y)+(z*z));
            self.x = ((self.y * V.z) - (self.z * V.y)) * f;
            self.y = ((self.z * V.x) - (V.z * self.x)) * f;
            self.z = ((V.y * self.x) - (self.y * V.x)) * f;
            return self;
        }

        public static float FastNormalize(ref this Vector3 self) {
            float g = (self.x * self.x) + (self.y * self.y) + (self.z * self.z);
            float f = 0;
            if (g >= 0.00001)
            {
                f = (float)Math.Sqrt(g);
                self.x *= (1f / f);
                self.y *= (1f / f);
                self.z *= (1f / f);
            }
            else {
                self = new Vector3();
            }
            return f;
        }

        public static Vector3 FastRotateX(ref this Vector3 self, float angle) {
            self.y = (self.y * (float)Math.Cos(angle)) - (self.z * (float)Math.Sin(angle));
            self.z = (self.y * (float)Math.Sin(angle)) + (self.z * (float)Math.Cos(angle));
            return self;
        }

        public static Vector3 FastRotateY(ref this Vector3 self, float angle) {
            self.x = (self.x * (float)Math.Cos(angle)) + (self.z * (float)Math.Sin(angle));
            self.z = (self.z * (float)Math.Cos(angle)) - (self.x * (float)Math.Sin(angle));
            return self;
        }

        public static Vector3 FastRotateZ(ref this Vector3 self, float angle) {
            self.x = (self.y * (float)Math.Sin(angle)) + (self.x * (float)Math.Cos(angle));
            self.y = (self.y * (float)Math.Cos(angle)) - (self.x * (float)Math.Sin(angle));
            return self;
        }
    }
}
