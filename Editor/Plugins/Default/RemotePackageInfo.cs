using System;
using System.IO;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
	[Serializable]
	public class RemotePackageInfo : ISerializationCallbackReceiver
	{
		[SerializeField] private string remotePath;
		[SerializeField] private string localPath;
		[SerializeField] private string internalPath;
		[SerializeField] private string name;
		[SerializeField] private string type;
		[SerializeField] private string version;
		[SerializeField] private string[] dependencies;
		[NonSerialized] private Settings settings;

		private RemotePackageType convertedType;

		public string RemotePath => remotePath;
		public string LocalPath => localPath;
		public string InternalPath => internalPath;
		public string Name => name;
		public Version Version { get; private set; }
		public RemotePackageType ConvertedType => convertedType;
		public string[] Dependencies => dependencies;

		public void OnBeforeSerialize()
		{
			type = RemotePackageTypeUtil.TypeToString(convertedType);
			version = Version.ToString();
		}

		public void OnAfterDeserialize()
		{
			convertedType = RemotePackageTypeUtil.StringToType(type);
			type = null;
			Version = new Version(version);
			version = null;
		}

		internal void Inject(Settings settings)
		{
			this.settings = settings;
		}

		public string GetInProjectDirPath()
		{
			return Path.Combine(Application.dataPath.Substring(0, Application.dataPath.Length - 7),
				settings.PackageDirPath, localPath, internalPath);
		}
	}
}