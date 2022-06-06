using System;

namespace RemotePackageLoader.Editor
{
	[Flags]
	public enum ResolutionType : int
	{
		All = -1,
		None = 0,
		Download = 1 << 0,
		AddToManifest = 1 << 1,
	}
}