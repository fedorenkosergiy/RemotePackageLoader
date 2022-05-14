using NUnit.Framework;

namespace RemotePackageLoader.Editor.Tests
{
    public class DefaultRemotePackageInfoTests
    {
        [TestCase("https://example.com")]
        public void CheckPropertyRemotePathSetGet(string path)
        {
            var info = new DefaultRemotePackageInfo
            {
                RemotePath = path
            };
            Assert.AreEqual(info.RemotePath, path);
        }

        [TestCase("directory/filename")]
        public void CheckPropertyLocalPathSetGet(string path)
        {
            var info = new DefaultRemotePackageInfo()
            {
                LocalPath = path
            };
            Assert.AreEqual(info.LocalPath, path);
        }
    }
}