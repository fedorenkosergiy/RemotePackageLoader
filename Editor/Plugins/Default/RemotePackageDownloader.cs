using System;
using System.Net;
using UnityEditor;
using UnityEngine.Windows;
using static RemotePackageLoader.Editor.RemotePackageTypeUtil;

namespace RemotePackageLoader.Editor
{
    public class RemotePackageDownloader
    {
        private const string FileName = "archive";
        public string Download(RemotePackageInfo info)
        {
            using var client = new WebClient();
            Uri uri = new Uri(info.RemotePath);
            string tempPath = FileUtil.GetUniqueTempPathInProject();
            Directory.CreateDirectory(tempPath);
            tempPath += "/" + FileName + GetAssociatedExtension(info.ConvertedType);
            client.DownloadFile(uri, tempPath);
            return tempPath;
        }
    }
}