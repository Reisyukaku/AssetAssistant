using System;
using System.Runtime.InteropServices;

namespace SmartPoint.AssetAssistant
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
    public struct AssetBundlePackHeader
    {
        public int count;
        public int dataSize;
    }
}
