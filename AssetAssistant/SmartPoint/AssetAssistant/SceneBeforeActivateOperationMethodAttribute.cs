using System;

namespace SmartPoint.AssetAssistant
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SceneBeforeActivateOperationMethodAttribute : Attribute
    {
        public SceneBeforeActivateOperationMethodAttribute()
        {
            //
        }
    }
}
