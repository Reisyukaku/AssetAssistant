using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public abstract class SequenceMonoBehaviour : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            //
        }

        protected virtual void OnDisable()
        {
            //
        }

        protected abstract void OnUpdate(float deltaTime);

        protected SequenceMonoBehaviour()
        {
            //
        }
    }
}
