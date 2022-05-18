using UnityEditor;

namespace RemotePackageLoader.Editor
{
    [InitializeOnLoad]
    public class AutoResolver
    {
        static AutoResolver()
        {
            Resolver resolver = new Resolver();
            resolver.Resolve();
        }
    }
}