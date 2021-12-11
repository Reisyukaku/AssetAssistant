using System;
using UnityEngine;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public static class GameObjectExtension
    {
        public static Component GetComponentInChildrenByName(this GameObject asset, Type type, string name)
        {
            Component cres = null;
            var comp = asset.GetComponentsInChildren(type, true);
            if (comp.Length < 1) return cres;

            foreach (var c in comp) {
                if (c.gameObject.name == name) {
                    cres = c;
                    break;
                }
            }
            return cres;
        }

        public static T GetComponentInChildrenByName<T>(this GameObject asset, string name) where T : Component {
            return (T)GetComponentInChildrenByName(asset, typeof(T), name);
        }

        public static bool IsValid(this MonoBehaviour self) => self.gameObject != null;
    }
}
