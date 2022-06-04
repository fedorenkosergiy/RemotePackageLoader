using System;
using System.IO;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;

namespace RemotePackageLoader.Editor
{
    public class PackagesUpdater
    {
        public bool Exists(RemotePackageInfo info)
        {
            ListRequest request = Client.List(true);
            while (!request.IsCompleted)
            {
            }

            if (request.Error != null)
            {
                throw new Exception(request.Error.message);
            }

            foreach (PackageInfo packageInfo in request.Result)
            {
                if (packageInfo.name == info.Name)
                {
                    return true;
                }
            }

            return false;
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