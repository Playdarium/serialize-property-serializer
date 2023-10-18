using System;
using UnityEditor;

namespace Package.Serializer.Serializers
{
	public class ClassOrStructPropertySerializer : IPropertySerializer
	{
		public bool CanSerialize(Type type) => type.IsClass || type.IsValueType;

		public void Serialize(object value, SerializedProperty property)
		{
			SerializedPropertySerializer.SerializeClassType(value, value.GetType(), property);
		}
	}
}