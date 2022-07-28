using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
                actions |= RequiredActions.AddRecordToManifest;
            }

            if (IsNeedToBeDownloaded(info))
            {
                actions |= RequiredActions.DownloadArchive;
            }

            if (IsNeedToHandleDependencies(info))
            {
                actions |= RequiredActions.HandleDependencies;
            }

            if (IsNeedToDeletePackageDirectory(info))
            {
                actions |= RequiredActions.DeletePackageFile;
            }

            return actions;
        }

        private bool IsNeedToBeAddedToManifest(RemotePackageInfo info)
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
                    return false;
                }
            }

            return true;
        }

        private bool IsNeedToBeDownloaded(RemotePackageInfo info)
        {
            if (!File.Exists(info.GetLocalPath()))
            {
                return true;
            }

            string hash = GetPackageHash(info);

            return info.Hash != hash;
        }

        private static string GetPackageHash(RemotePackageInfo info)
        {
            using MD5 md5 = MD5.Create();
            using FileStream file = File.OpenRead(info.GetLocalPath());
            byte[] hash = md5.ComputeHash(file);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            string hashString = sb.ToString();
            return hashString;
        }

        private bool IsNeedToHandleDependencies(RemotePackageInfo info)
        {
            if (info.Dependencies == null || info.Dependencies.Length == 0)
            {
                return false;
            }

            ListRequest request = Client.List(true);
            while (!request.IsCompleted)
            {
            }

            if (request.Error != null)
            {
                throw new Exception(request.Error.message);
            }


            for (int i = 0; i < info.Dependencies.Length; ++i)
            {
                bool found = false;
                foreach (PackageInfo packageInfo in request.Result)
                {
                    if (packageInfo.name == info.Dependencies[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    continue;
                }

                return true;
            }

            return false;
        }

        private bool IsNeedToDeletePackageDirectory(RemotePackageInfo info)
        {
            string packageFilePath = info.GetLocalPath();
            if (!File.Exists(packageFilePath))
            {
                return false;
            }
            
            string hash = GetPackageHash(info);
            return info.Hash != hash;
        }
    }
}