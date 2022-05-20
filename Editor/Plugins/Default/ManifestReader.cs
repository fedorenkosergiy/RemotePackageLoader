using UnityEngine;
using System.IO;

namespace RemotePackageLoader.Editor
{
    public class ManifestReader
    {
        private const string ManifestPath = "Packages/remote-package-loader-manifest.json";
        
        public Manifest Read()
        {
            string projectPath = Path.Combine(Application.dataPath, "..");
            string manifestPath = Path.Combine(projectPath, ManifestPath);
            if (!File.Exists(manifestPath)) return new Manifest();
            string content = File.ReadAllText(manifestPath);
            return JsonUtility.FromJson<Manifest>(content);
        }
    }
}