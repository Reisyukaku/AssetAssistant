using System;
using System.IO;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public static class StringExtensions
    {
        public static string ToDivisionSlash(this string self) => self.Replace('/', '\\');

        public static string ToSlash(this string self) => self.Replace('\\', '/');

        public static string RemoveStart(this string self, string value) => self.Remove(self.IndexOf(value), value.Length);

        public static void ToLowerSelf(this string self) => self.ToLower();

        public static bool IsNullOrEmpty(this string self) => self.IsNullOrEmpty();

        public static bool IsUrl(this string self) {
            var uri = new Uri(self);
            return (uri.Scheme == Uri.UriSchemeHttp) | (uri.Scheme == Uri.UriSchemeHttp);
        }

        public static string RemoveEnd(this string self, string value) {
            return self.Remove(self.LastIndexOf(value), value.Length);
        }

        public static string CombinePath(this string self, string value) {
            var p = Path.Combine(self, value);
            return p.Replace('\\', '/');
        }

        public static bool Contains(this string self, string value, StringComparison comparisionType) => self.Contains(value, comparisionType);
    }
}
