using System.Runtime.InteropServices;
using UnityEngine;

namespace SmartPoint.Mathematics 
{ 
    public static class Vector2Ext {
        public static float FastLengthSq(ref this Vector2 self) {
            return (self.x * self.x) + (self.y * self.y);
        }
        public static float FastCross([In] ref this Vector2 self, [In] ref Vector2 V) {
            return (self.x * V.y) - (self.y * V.x);
        }
    }
}
