using System;
using System.IO;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
    [Serializable]
    public class RemotePackageInfo : ISerializationCallbackReceiver
    {
        [SerializeField] private string remotePath;
        [SerializeField] private string localDir;
        [SerializeField] private string name;
        [SerializeField] private string type;
        [SerializeField] private string[] dependencies;
        [SerializeField] private string hash;

        public string RemotePath => remotePath;
        public string LocalDir => localDir;
        public string Name => name;
        public RemotePackageType Type { get; private set; }
        public string Hash => hash;

        public string[] Dependencies => dependencies;

        public void OnBeforeSerialize()
        {
            type = RemotePackageTypeUtil.TypeToString(Type);
        }

        public void OnAfterDeserialize()
        {
            Type = RemotePackageTypeUtil.StringToType(type);
            type = null;
        }

        public string GetInProjectDirPath()
        {
            return Path.Combine(GetPackagesDirPath(), LocalDir);
        }

        private string GetPackagesDirPath()
        {
            string project = GetProjectPath();
            string candidate = Path.Combine(project, "packages");
            return Directory.Exists(candidate) ? candidate : Path.Combine(project, "Packages");
        }

        private static string GetProjectPath()
        {
            return Application.dataPath.Substring(0, Application.dataPath.Length - 7);
        }

        public string GenerateIdentifier()
        {
            return "file:" + LocalDir + "/" + Name + ".tgz";
        }

        public string GetLocalPath()
        {
            return Path.Combine(GetPackagesDirPath(), LocalDir, Name) + ".tgz";
        }
    }
}