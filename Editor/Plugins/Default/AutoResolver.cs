using UnityEditor;

namespace RemotePackageLoader.Editor
{
    [InitializeOnLoad]
    public class AutoResolver
    {
        static AutoResolver()
        {
	        Resolve();
        }

        [MenuItem("resolver/resolve")]
        public static void Resolve()
        {
	        Resolver resolver = new Resolver();
	        resolver.Resolve();
        }
    }
}