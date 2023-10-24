using System;
using UnityEditor;

namespace Playdarium.Serializer.Serializers
{
    public class BytePropertySerializer : IPropertySerializer
    {
        public bool CanSerialize(Type type) => type == typeof(byte);

        public void Serialize(object value, SerializedProperty property)
            => property.intValue = (byte) value;
    }
}