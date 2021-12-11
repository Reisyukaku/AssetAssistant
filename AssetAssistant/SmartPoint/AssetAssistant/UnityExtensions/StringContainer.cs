using System.Collections.Generic;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public class StringContainer
    {
        private HashSet<string> _container;

        public void Add(string text)
        {
            _container.Add(text);
        }

        public void Clear()
        {
            _container.Clear();
        }

        public string[] ToArray() {
            string[] set = new string[_container.Count];
            _container.CopyTo(set, 0);
            return set;
        }

        public StringContainer()
        {
            _container = new HashSet<string>();
        }
    }
}
