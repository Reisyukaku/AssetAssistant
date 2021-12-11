using System;

namespace SmartPoint.AssetAssistant
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SceneDeactivatedOperationMethodAttribute : Attribute
    {
        public SceneDeactivatedOperationMethodAttribute()
        {
            //
        }
    }
}
