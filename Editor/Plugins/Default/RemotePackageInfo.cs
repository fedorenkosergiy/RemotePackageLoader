using System;
using Unity.Properties;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
    [Serializable, GeneratePropertyBag]
    public class RemotePackageInfo
    {
        [SerializeField] private string remotePath;
        [SerializeField] private string localPath;
        [SerializeField] private string internalPath;
        [SerializeField] private string name;
        [CreateProperty] private RemotePackageType type;

        public string RemotePath => remotePath;
        public string LocalPath => localPath;
        public string InternalPath => internalPath;
        public string Name => name;
        public RemotePackageType Type => type;
    }
}
