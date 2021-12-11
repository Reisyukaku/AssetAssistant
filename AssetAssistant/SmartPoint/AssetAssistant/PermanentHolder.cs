using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class PermanentHolder : MonoBehaviour
    {
        private static PermanentHolder _instance;
        public static Object[] _objects;

        private void Awake()
        {
            //
        }

        public static Object[] objects
        {
            get => _objects;
            set => _objects = value;
        }

        public PermanentHolder()
        {
            //
        }
    }
}
