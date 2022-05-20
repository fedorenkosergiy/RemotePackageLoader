using System.IO;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;

namespace RemotePackageLoader.Editor
{
    public class PackagesUpdater
    {
        public bool Exists(RemotePackageInfo info)
        {
            SearchRequest request = Client.Search(info.Name);
            while (!request.IsCompleted)
            {
            }

            return request.Result != null;
        }
        
        public void Add(RemotePackageInfo info)
        {
            string identifier = GenerateIdentifier(info);
            AddRequest request = Client.Add(identifier);
            while (!request.IsCompleted)
            {
            }
        }

        private string GenerateIdentifier(RemotePackageInfo info)
        {
            if (Path.IsPathRooted(info.LocalPath))
            {
                return "file:" + info.LocalPath + "/" + info.InternalPath;
            }
            return "file:../" + info.LocalPath + "/" + info.InternalPath;
        }
    }
}