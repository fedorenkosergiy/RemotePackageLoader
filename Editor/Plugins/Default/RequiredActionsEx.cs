namespace RemotePackageLoader.Editor
{
	public static class RequiredActionsEx
	{
		public static bool ContainsAddToManifest(this RequiredActions value)
		{
			return (value & RequiredActions.AddToManifest) != 0;
		}

		public static bool ContainsDownload(this RequiredActions value)
		{
			return (value & RequiredActions.Download) != 0;
		}

		public static bool ContainsHandleDependencies(this RequiredActions value)
		{
			return (value & RequiredActions.HandleDependencies) != 0;
		}
	}
}