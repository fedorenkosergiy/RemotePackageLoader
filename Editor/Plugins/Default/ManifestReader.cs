using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.Serialization.Json;

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
            JsonSerializationParameters parameters = new JsonSerializationParameters();
            parameters.UserDefinedAdapters = new List<IJsonAdapter>();
            parameters.UserDefinedAdapters.Add(new RemotePackageTypeJsonAdapter());
            return JsonSerialization.FromJson<Manifest>(content, parameters);
        }
    }
}