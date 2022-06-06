namespace RemotePackageLoader.Editor
{
	public static class ResolutionTypeEx
	{
		public static bool IsAddToManifest(this ResolutionType value)
		{
			return (value & ResolutionType.AddToManifest) != 0;
		}

		public static bool IsDownload(this ResolutionType value)
		{
			return (value & ResolutionType.Download) != 0;
		}
	}
}