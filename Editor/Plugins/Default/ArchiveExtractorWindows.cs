using UnityEditor;

namespace RemotePackageLoader.Editor
{
    public class ArchiveExtractorWindows : ArchiveExtractor
    {
        protected override string Get7ZipPath()
        {
            return EditorApplication.applicationContentsPath + "/Data/Tools/7z.exe";
        }
    }
}