// Decompiled with JetBrains decompiler
// Type: SmartPoint.AssetAssistant.AssetBundleInstantiator
// Assembly: AssetAssistant, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E2A3435D-0E5D-4C3A-A449-AA2AC83479AC
// Assembly location: C:\Users\Rei\Desktop\cpp2il_out\AssetAssistant.dll

using Cpp2IlInjected;
using System.Collections;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class AssetBundleInstantiator : MonoBehaviour
    {
        [SerializeField]
        public string assetBundleName;

        [SceneRestoreOperationMethod]
        private IEnumerator RestoreOperation(SceneEntity entity) => (IEnumerator) null;

        public virtual void OnFinished()
        {
        }

        public AssetBundleInstantiator()
        {
        }
    }
}
