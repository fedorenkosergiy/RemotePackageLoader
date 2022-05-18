using System;
using Unity.Serialization.Json;
using static RemotePackageLoader.Editor.RemotePackageTypeUtil;

namespace RemotePackageLoader.Editor
{
    public class RemotePackageTypeJsonAdapter : IJsonAdapter<RemotePackageType>
    {
        public void Serialize(in JsonSerializationContext<RemotePackageType> context, RemotePackageType value)
        {
            context.Writer.WriteValue(TypeToString(value));
        }

        public RemotePackageType Deserialize(in JsonDeserializationContext<RemotePackageType> context)
        {
            return StringToType(context.SerializedValue.AsStringView().ToString());
        }
    }
}