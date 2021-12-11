using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace SmartPoint.AssetAssistant
{
    internal static class StreamExtensions
    {
        public static void SerializeBinaryFormatter(this Stream stream, object content)
        {
            var bf = new BinaryFormatter();
            bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
            bf.Serialize(stream, content);
        }

        public static object DeserializeBinaryFormatter(this Stream stream) 
        {
            var bf = new BinaryFormatter();
            bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
            bf.Binder = new IgnoreVersionBinder();
            return bf.Deserialize(stream);
        }

        private static Assembly ResolveAssembly(object sender, ResolveEventArgs args) 
        {
            return Assembly.GetAssembly(Type.GetTypeFromHandle(typeof(Sequencer).TypeHandle));
        }
    }
}
