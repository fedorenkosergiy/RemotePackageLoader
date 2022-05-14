using System;
using RemotePackageLoader.Editor.Abstract;
using Unity.Properties;

namespace RemotePackageLoader.Editor
{
    [Serializable]
    public class DefaultRemotePackageInfo : RemotePackageInfo
    {
        [CreateProperty]
        public string RemotePath { get; set; }
        [CreateProperty]
        public string LocalPath { get; set; }
    }
}
