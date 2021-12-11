using System;
using System.Runtime.Serialization;

namespace SmartPoint.AssetAssistant
{
    public class IgnoreVersionBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName) {
            return Type.GetType(typeName);
        }

        public IgnoreVersionBinder() : base() {}
    }
}
