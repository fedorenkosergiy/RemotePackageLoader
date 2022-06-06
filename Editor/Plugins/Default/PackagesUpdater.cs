using System;
using System.IO;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
    public class PackagesUpdater
    {
        public bool RequiresResolve(RemotePackageInfo info, out ResolutionType resolutionType)
        {
	        resolutionType = ResolutionType.All;
            ListRequest request = Client.List(true);
            while (!request.IsCompleted)
            {
            }

            if (request.Error != null)
            {
                throw new Exception(request.Error.message);
            }

            PackageInfo package = null;
            foreach (PackageInfo packageInfo in request.Result)
            {
                if (packageInfo.name == info.Name)
                {
	                package = packageInfo;
	                resolutionType &= ~ResolutionType.AddToManifest;
	                break;
                }
            }

            string hashFilePath = null;
            if (package != null)
            {
	             hashFilePath = Path.Combine(package.resolvedPath, ".hash");
            }
            else
            {
	            hashFilePath = Path.Combine(Application.dataPath, info.LocalPath, ".hash");
            }
            if (File.Exists(hashFilePath))
            {
	            resolutionType &= ~ResolutionType.Download;
            }

            return resolutionType != ResolutionType.None;
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