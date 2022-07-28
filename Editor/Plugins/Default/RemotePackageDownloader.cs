using System;
using System.Net;
using UnityEditor;
using UnityEngine.Windows;
using static RemotePackageLoader.Editor.RemotePackageTypeUtil;
using File = System.IO.File;

namespace RemotePackageLoader.Editor
{
    public class RemotePackageDownloader
    {
        public void Download(RemotePackageInfo info)
        {
            using var client = new WebClient();
            Uri uri = new Uri(info.RemotePath);
            string tempPath = FileUtil.GetUniqueTempPathInProject();
            Directory.CreateDirectory(tempPath);
            tempPath += "/archive.tgz";
            client.DownloadFile(uri, tempPath);
            File.Move(tempPath, info.GetLocalPath());
        }
    }
}