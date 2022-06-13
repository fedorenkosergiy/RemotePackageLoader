using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;

namespace RemotePackageLoader.Editor
{
	public class PackagesUpdater
	{
		public void Add(RemotePackageInfo info)
		{
			string identifier = info.GenerateIdentifier();
			AddRequest request = Client.Add(identifier);
			while (!request.IsCompleted) { }
		}

		public void Delete(RemotePackageInfo info)
		{
			RemoveRequest request = Client.Remove(info.Name);
			while (!request.IsCompleted) { }
		}
	}
}