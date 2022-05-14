using Unity.Serialization.Json;

namespace RemotePackageLoader.Editor
{
    public class DefaultRemotePackageInfoMigration : IJsonMigration<DefaultRemotePackageInfo>
    {
        public DefaultRemotePackageInfo Migrate(in JsonMigrationContext context)
        {
            return context.Read<DefaultRemotePackageInfo>(context.SerializedObject);
        }

        public int Version => 0;
    }
}