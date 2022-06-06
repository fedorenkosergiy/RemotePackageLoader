namespace RemotePackageLoader.Editor
{
    public class Resolver
    {
        public void Resolve()
        {
            ManifestReader reader = new ManifestReader();
            Manifest manifest = reader.Read();
            for (int i = 0; i < manifest.Packages.Count; ++i)
            {
                RemotePackageInfo info = manifest.Packages[i];
                PackagesUpdater updater = new PackagesUpdater();
                if (!updater.RequiresResolve(info, out ResolutionType resolutionType))
                {
	                continue;
                }

                if (resolutionType.IsDownload())
                {
	                RemotePackageDownloader downloader = new RemotePackageDownloader();
	                string archivePath = downloader.Download(info);
	                Unpacker unpacker = new Unpacker();
	                unpacker.Unpack(info, archivePath);
                }

                if (resolutionType.IsAddToManifest())
                {
	                updater.Add(info);
                }
            }
        }
    }
}