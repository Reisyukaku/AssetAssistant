using System.IO;
using UnityEngine.Networking;

namespace SmartPoint.AssetAssistant
{
    public class InstallHandler : DownloadHandlerScript
    {
        private ulong _contentLength;
        private FileStream _fileStream;
        private int _offsetInBytes;
        private string _installFileName;
        private static string _installPath;

        public static string installPath
        {
            get => _installPath;
            set => _installPath = value;
        }

        public InstallHandler(string fileName, byte[] preallocatedBuffer) : base(preallocatedBuffer)
        {
            _installFileName = fileName;
        }

        public InstallHandler(string fileName, int cacheSize) : base(new byte[cacheSize])
        {
            _installFileName = fileName;
        }

        public InstallHandler(string fileName) : base()
        {
            _installFileName = fileName;
        }

        protected override bool ReceiveData(byte[] data, int bytesToRead) {
            var file = Path.Combine(_installPath, _installFileName).Replace('\\', '/');
            if (!Directory.Exists(Path.GetDirectoryName(file))) 
                Directory.CreateDirectory(Path.GetDirectoryName(file));
            _fileStream = new FileStream(file, FileMode.Create, FileAccess.Write);
            _fileStream.Write(data, _offsetInBytes, bytesToRead);
            _offsetInBytes += bytesToRead;
            return true;
        }

        protected override void ReceiveContentLengthHeader(ulong contentLength)
        {
            _contentLength = contentLength;
        }

        protected override void CompleteContent()
        {
            if (_fileStream != null) {
                _fileStream.Flush();
                _fileStream.Close();
            }
            _fileStream = null;
        }

        private void CloseStream()
        {
            CompleteContent();
        }

        protected override float GetProgress() {
            if (_contentLength == 0) return 0f;
            return (float)_offsetInBytes / (float)_contentLength;
        }
    }
}
