using System.Diagnostics;

namespace RemotePackageLoader.Editor
{
    public abstract class ArchiveExtractor
    {
        public void Extract(string sourcePath, string targetPath)
        {
            Process process = new Process();
            process.StartInfo.FileName = Get7ZipPath();
            process.StartInfo.Arguments = $"x {sourcePath} -o{targetPath}";
            process.Start();
            process.WaitForExit();
            process.Close();    
        }
        
        protected abstract string Get7ZipPath();
    }
}