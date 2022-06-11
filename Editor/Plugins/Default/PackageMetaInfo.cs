using System;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
    [Serializable]
    public class PackageMetaInfo : ISerializationCallbackReceiver
    {
        [SerializeField] private string name;

        [SerializeField] private string displayName;

        [SerializeField] private string description;

        [SerializeField] private string version;

        [SerializeField] private string unity;

        public string Name => name;
        public string DisplayName => displayName;
        public string Description => description;
        public Version Version { get; private set; }
        public Version UnityVersion { get; private set; }

        public void OnBeforeSerialize()
        {
            version = Version.ToString();
            unity = UnityVersion.ToString();
        }

        public void OnAfterDeserialize()
        {
            Version = new Version(version);
            version = null;
            UnityVersion = new Version(unity);
            unity = null;
        }
    }
}