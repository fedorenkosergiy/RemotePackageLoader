using System;
using System.IO;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
    public class PackageAnalyzer
    {
        public RequiredActions GetRequiredActions(RemotePackageInfo info)
        {
            RequiredActions actions = RequiredActions.None;
            if (IsNeedToBeAddedToManifest(info))
            {
                actions |= RequiredActions.AddToManifest;
            }

            if (IsNeedToBeDownloaded(info))
            {
                actions |= RequiredActions.Download;
            }
            
            return actions;
        }

        private bool IsNeedToBeAddedToManifest(RemotePackageInfo info)
        {
            ListRequest request = Client.List(true);
            while (!request.IsCompleted) { }

            if (request.Error != null)
            {
                throw new Exception(request.Error.message);
            }

            foreach (PackageInfo packageInfo in request.Result)
            {
                if (packageInfo.name == info.Name)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsNeedToBeDownloaded(RemotePackageInfo info)
        {
            string packageFilePath = Path.Combine(Application.dataPath.Substring(0, Application.dataPath.Length - 7),
                info.LocalPath, info.InternalPath, "package.json");
            
            if (File.Exists(packageFilePath))
            {
                string metaInfoContent = File.ReadAllText(packageFilePath);
                PackageMetaInfo metaInfo = JsonUtility.FromJson<PackageMetaInfo>(metaInfoContent);
                if (metaInfo.Version == info.Version)
                {
                    return false;
                }
            }

            return true;
        }
    }
}