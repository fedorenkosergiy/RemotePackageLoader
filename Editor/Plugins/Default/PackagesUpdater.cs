using System;
using System.IO;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
	public class PackagesUpdater
	{
		public void Add(RemotePackageInfo info)
		{
			string identifier = GenerateIdentifier(info);
			AddRequest request = Client.Add(identifier);
			while (!request.IsCompleted) { }
		}

		private string GenerateIdentifier(RemotePackageInfo info)
		{
			if (Path.IsPathRooted(info.LocalPath))
			{
				return "file:" + info.LocalPath + "/" + info.InternalPath;
			}

			return "file:../" + info.LocalPath + "/" + info.InternalPath;
		}

		public void Delete(RemotePackageInfo info)
		{
			RemoveRequest request = Client.Remove(info.Name);
			while (!request.IsCompleted) { }
		}
	}
}