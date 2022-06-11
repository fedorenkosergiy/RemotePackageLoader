namespace RemotePackageLoader.Editor
{
    public class Resolver
    {
        public void Resolve()
        {
            ManifestReader reader = new ManifestReader();
            Manifest manifest = reader.Read();
            bool needsToHandleDependencies;
            bool handledAtLeastOnePackage;
            bool NeedsOneMorePass() => needsToHandleDependencies && handledAtLeastOnePackage;
            do
            {
                needsToHandleDependencies = false;
                handledAtLeastOnePackage = false;
                for (int i = 0; i < manifest.Packages.Count; ++i)
                {
                    RemotePackageInfo info = manifest.Packages[i];
                    PackageAnalyzer analyzer = new PackageAnalyzer();
                    RequiredActions requiredActions = analyzer.GetRequiredActions(info);
                    if (requiredActions == RequiredActions.None)
                    {
                        continue;
                    }

                    if (requiredActions.ContainsHandleDependencies())
                    {
                        needsToHandleDependencies = true;
                        continue;
                    }

                    handledAtLeastOnePackage = true;

                    if (requiredActions.ContainsDownload())
                    {
                        RemotePackageDownloader downloader = new RemotePackageDownloader();
                        string archivePath = downloader.Download(info);
                        Unpacker unpacker = new Unpacker();
                        unpacker.Unpack(info, archivePath);
                    }

                    if (requiredActions.ContainsAddToManifest())
                    {
                        PackagesUpdater updater = new PackagesUpdater();
                        updater.Add(info);
                    }
                }
            } while (NeedsOneMorePass());
        }
    }
}