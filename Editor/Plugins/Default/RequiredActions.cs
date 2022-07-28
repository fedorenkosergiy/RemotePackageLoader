using System;

namespace RemotePackageLoader.Editor
{
	[Flags]
	public enum RequiredActions : byte
	{
		None = 0,
		DownloadArchive = 1 << 0,
		AddRecordToManifest = 1 << 1,
		HandleDependencies = 1 << 2,
		DeletePackageFile = 1 << 3,
		DeleteRecordFromManifest = 1 << 4,
	}
}