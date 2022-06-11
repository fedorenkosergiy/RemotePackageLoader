using System;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
    [Serializable]
    public class RemotePackageInfo : ISerializationCallbackReceiver
    {
        [SerializeField] private string remotePath;
        [SerializeField] private string localPath;
        [SerializeField] private string internalPath;
        [SerializeField] private string name;
        [SerializeField] private string type;
        [SerializeField] private string version;
        [SerializeField] private string[] dependencies;
        
        private RemotePackageType convertedType;

        public string RemotePath => remotePath;
        public string LocalPath => localPath;
        public string InternalPath => internalPath;
        public string Name => name;
        public Version Version { get; private set; }
        public RemotePackageType ConvertedType => convertedType;
        public string [] Dependencies => dependencies;
        public void OnBeforeSerialize()
        {
            type = RemotePackageTypeUtil.TypeToString(convertedType);
            version = Version.ToString();
        }

        public void OnAfterDeserialize()
        {
            convertedType = RemotePackageTypeUtil.StringToType(type);
            type = null;
            Version = new Version(version);
            version = null;
        }
    }
}
