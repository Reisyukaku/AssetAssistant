using UnityEngine;
using Object = UnityEngine.Object;

namespace SmartPoint.AssetAssistant
{
    public delegate void RequestEventCallback(RequestEventType requestEventType, string name, Object content);
}
