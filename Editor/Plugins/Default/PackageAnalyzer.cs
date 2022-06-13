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
				actions |= RequiredActions.DeletePackageDirectory;
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
			string packageFilePath = info.GetPackageFilePath();

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

		private bool IsNeedToHandleDependencies(RemotePackageInfo info)
		{
			if (info.Dependencies == null || info.Dependencies.Length == 0)
			{
				return false;
			}

			ListRequest request = Client.List(true);
			while (!request.IsCompleted) { }

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
			string packageFilePath = info.GetPackageFilePath();
			if (File.Exists(packageFilePath))
			{
				string metaInfoContent = File.ReadAllText(packageFilePath);
				PackageMetaInfo metaInfo = JsonUtility.FromJson<PackageMetaInfo>(metaInfoContent);
				if (metaInfo.Version != info.Version)
				{
					return true;
				}
			}

			return false;
		}
	}
}