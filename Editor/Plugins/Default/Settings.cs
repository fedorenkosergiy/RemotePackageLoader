using System;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
	[Serializable]
	public class Settings
	{
		[SerializeField] private string packagesDirPath;

		public string PackageDirPath => packagesDirPath;
	}
}