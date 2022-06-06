using System;

namespace RemotePackageLoader.Editor
{
    [Flags]
    public enum ResolutionType : byte
    {
        None = 0,
        Download = 1 << 0,
        AddToManifest = 1 << 1,
        All = Download | AddToManifest,
    }
}