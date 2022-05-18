using JetBrains.Annotations;
using Unity.Serialization.Json;

namespace RemotePackageLoader.Editor
{
    [UsedImplicitly]
    public class RemotePackageInfoMigration : IJsonMigration<RemotePackageInfo>
    {
        public RemotePackageInfo Migrate(in JsonMigrationContext context)
        {
            return context.Read<RemotePackageInfo>(context.SerializedObject);
        }
        public int Version => 0;
    }
}