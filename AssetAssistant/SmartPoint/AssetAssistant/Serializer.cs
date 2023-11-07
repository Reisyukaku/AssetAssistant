using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace SmartPoint.AssetAssistant
{
    public class Serializer
    {
        public Serializer()
        {
            if(UnityEngine.Application.platform == UnityEngine.RuntimePlatform.IPhonePlayer)
                Environment.SetEnvironmentVariable("MONO_COLLATION_QUICK_CHECK_DISABLED", "yes");
        }

        public static string ToBase64String(object content)
        { 
            var bf = new BinaryFormatter();
            bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
            var mem = new MemoryStream();
            bf.Serialize(mem, content);
            var ret = Convert.ToBase64String(mem.ToArray());
            mem.Close();
            return ret;
        }

        public static object FromBase64String(string base64string) 
        {
            var bts = Convert.FromBase64String(base64string);
            var bf = new BinaryFormatter();
            bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
            var mem = new MemoryStream(bts);
            return bf.Deserialize(mem);
        }
    }
}
