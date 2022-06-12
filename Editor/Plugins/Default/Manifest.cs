using System;
using System.Collections.Generic;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
	[Serializable]
	public class Manifest: ISerializationCallbackReceiver
	{
		[SerializeField] private Settings settings;
		[SerializeField] private List<RemotePackageInfo> packages = new List<RemotePackageInfo>();

		public Settings Settings => settings;
		public List<RemotePackageInfo> Packages => packages;
		public void OnBeforeSerialize()
		{
			throw new NotImplementedException();
		}

		public void OnAfterDeserialize()
		{
			for (int i = 0; i < packages.Count; ++i)
			{
				packages[i].Inject(settings);
			}
		}
	}
}