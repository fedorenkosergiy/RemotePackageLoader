using System;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
    public class ArchiveExtractorCreator
    {
        public ArchiveExtractor Create()
        {
            return Application.platform switch
            {
                RuntimePlatform.WindowsEditor => new ArchiveExtractorWindows(),
                RuntimePlatform.OSXEditor => new ArchiveExtractorOsx(),
                _ => throw new NotSupportedException()
            };
        }
    }
}