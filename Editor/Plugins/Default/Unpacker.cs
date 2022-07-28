using System;
using System.IO;
using UnityEditor;

namespace RemotePackageLoader.Editor
{
    public class Unpacker
    {
        public void Unpack(RemotePackageInfo info, string path)
        {
            switch (info.Type)
            {
                case RemotePackageType.Zip:
                    UnpackZip(info, path);
                    break;
                case RemotePackageType.Tgz:
                    UnpackTgz(info, path);
                    break;
                case RemotePackageType.Undefined:
                default: throw new NotSupportedException();
            }
        }

        private void UnpackZip(RemotePackageInfo info, string path)
        {
            ArchiveExtractorCreator extractorCreator = new ArchiveExtractorCreator();
            ArchiveExtractor extractor = extractorCreator.Create();
            Directory.CreateDirectory(info.GetInProjectDirPath());
            extractor.Extract(path, info.GetInProjectDirPath());
        }

        private void UnpackTgz(RemotePackageInfo info, string path)
        {
            ArchiveExtractorCreator extractorCreator = new ArchiveExtractorCreator();
            ArchiveExtractor extractor = extractorCreator.Create();
            string tarDir = FileUtil.GetUniqueTempPathInProject();
            Directory.CreateDirectory(tarDir);
            extractor.Extract(path, tarDir);
            string tarPath = tarDir + "/" + Path.GetFileNameWithoutExtension(path) + ".tar";
            Directory.CreateDirectory(info.GetInProjectDirPath());
            extractor.Extract(tarPath, info.GetInProjectDirPath());
        }
    }
}