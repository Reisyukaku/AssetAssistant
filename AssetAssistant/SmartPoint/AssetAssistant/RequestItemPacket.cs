using System.Collections.Generic;

namespace SmartPoint.AssetAssistant
{
    public class RequestItemPacket
    {
        public List<IAssetRequestItem> packet;
        public RequestEventCallback callback;

        public RequestItemPacket()
        {
            //
        }

        public void Clear()
        {
            //
        }
    }
}
