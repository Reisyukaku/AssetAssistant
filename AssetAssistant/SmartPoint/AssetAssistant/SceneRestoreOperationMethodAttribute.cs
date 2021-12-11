using System;

namespace SmartPoint.AssetAssistant
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SceneRestoreOperationMethodAttribute : Attribute
    {
        public SceneRestoreOperationMethodAttribute()
        {
            //
        }
    }
}
