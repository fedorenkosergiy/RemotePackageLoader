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
        private RemotePackageType convertedType;
        private string type;

        public string RemotePath => remotePath;
        public string LocalPath => localPath;
        public string InternalPath => internalPath;
        public string Name => name;
        public RemotePackageType ConvertedType => convertedType;
        public void OnBeforeSerialize()
        {
            type = RemotePackageTypeUtil.TypeToString(convertedType);
        }

        public void OnAfterDeserialize()
        {
            convertedType = RemotePackageTypeUtil.StringToType(type);
            type = null;
        }
    }
}
