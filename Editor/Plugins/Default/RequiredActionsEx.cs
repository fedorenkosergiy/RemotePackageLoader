namespace RemotePackageLoader.Editor
{
	public static class RequiredActionsEx
	{
		public static bool ContainsAddToManifest(this RequiredActions value)
		{
			return (value & RequiredActions.AddRecordToManifest) != 0;
		}

		public static bool ContainsDownload(this RequiredActions value)
		{
			return (value & RequiredActions.DownloadArchive) != 0;
		}

		public static bool ContainsHandleDependencies(this RequiredActions value)
		{
			return (value & RequiredActions.HandleDependencies) != 0;
		}

		public static bool ContainsDeletePackage(this RequiredActions value)
		{
			return (value & RequiredActions.DeletePackageFile) != 0;
		}

		public static bool ContainsDeleteFromManifest(this RequiredActions value)
		{
			return (value & RequiredActions.DeleteRecordFromManifest) != 0;
		}
	}
}