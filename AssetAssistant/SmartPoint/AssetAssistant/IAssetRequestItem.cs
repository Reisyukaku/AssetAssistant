// Decompiled with JetBrains decompiler
// Type: SmartPoint.AssetAssistant.IAssetRequestItem
// Assembly: AssetAssistant, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E2A3435D-0E5D-4C3A-A449-AA2AC83479AC
// Assembly location: C:\Users\Rei\Desktop\cpp2il_out\AssetAssistant.dll

using Cpp2IlInjected;

namespace SmartPoint.AssetAssistant
{
    public interface IAssetRequestItem
  {
        RequestStatus status {  set; }

        string uri {  set; }

        AssetBundleDownloadManifest manifest {  set; }

        bool isComplete {  get; }

        RequestEventCallback callback {  set; }

        string error {  set; }
  }
}
