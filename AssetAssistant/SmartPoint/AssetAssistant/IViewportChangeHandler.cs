using UnityEngine.EventSystems;

namespace SmartPoint.AssetAssistant
{
    public interface IViewportChangeHandler : IEventSystemHandler
    {
        void OnViewportChange(int screenWidth, int screenHeight);
    }
}
