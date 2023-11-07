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
