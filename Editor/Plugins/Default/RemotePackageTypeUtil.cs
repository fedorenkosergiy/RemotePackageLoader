using System;

namespace RemotePackageLoader.Editor
{
    public static class RemotePackageTypeUtil
    {
        private const string Tgz = "tgz";
        private const string Zip = "zip";
        
        public static string TypeToString(RemotePackageType value) => value switch
        {
            RemotePackageType.Tgz => Tgz,
            RemotePackageType.Zip => Zip,
            _ => throw new NotSupportedException()
        };

        public static RemotePackageType StringToType(string value) => value switch
        {
            Tgz => RemotePackageType.Tgz,
            Zip => RemotePackageType.Zip,
            _ => throw new NotSupportedException()
        };

        public static string GetAssociatedExtension(RemotePackageType value)
        {
            return "." + TypeToString(value);
        }
    }
}