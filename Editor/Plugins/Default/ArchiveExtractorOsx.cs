using UnityEditor;

namespace RemotePackageLoader.Editor
{
    public class ArchiveExtractorOsx : ArchiveExtractor
    {
        protected override string Get7ZipPath()
        {
            return EditorApplication.applicationContentsPath + "/Tools/7za";
        }
    }
}