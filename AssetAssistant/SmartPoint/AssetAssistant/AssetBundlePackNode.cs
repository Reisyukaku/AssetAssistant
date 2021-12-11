using System;
using System.Runtime.InteropServices;

namespace SmartPoint.AssetAssistant
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Size = 64, Pack = 4)]
    public struct AssetBundlePackNode
    {
        public int offsetInBytes;
        public int dataSize;
        public string name;
    }
}
