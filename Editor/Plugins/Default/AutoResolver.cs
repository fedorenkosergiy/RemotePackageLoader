using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace RemotePackageLoader.Editor
{
    [InitializeOnLoad]
    public class AutoResolver
    {
        static AutoResolver()
        {
            return;
            Resolve();
        }

        [MenuItem("rpl/resolve")]
        private static void Resolve()
        {
            Resolver resolver = new Resolver();
            resolver.Resolve();

            return;
            string name = "moqunity-0.2.1";
            string project = Application.dataPath.Remove(Application.dataPath.Length - 6, 6);
            string tgz = project + "Packages/" + name + ".tgz";
            
            string tempTar = FileUtil.GetUniqueTempPathInProject();
            
            ArchiveExtractorCreator extractorCreator = new ArchiveExtractorCreator();
            ArchiveExtractor extractor = extractorCreator.Create();
            extractor.Extract(tgz, tempTar);

            string tar = tempTar + "/" + name + ".tar";
            string content = project + name;
            
            extractor.Extract(tar, content);
        }
    }
}