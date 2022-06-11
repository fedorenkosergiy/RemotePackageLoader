using System;

namespace RemotePackageLoader.Editor
{
    [Flags]
    public enum RequiredActions : byte
    {
        None = 0,
        Download = 1 << 0,
        AddToManifest = 1 << 1,
        HandleDependencies = 1 << 2,
    }
}