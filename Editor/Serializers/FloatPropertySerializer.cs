using System;
using UnityEditor;

namespace Package.Serializer.Serializers
{
	public class FloatPropertySerializer : IPropertySerializer
	{
		public bool CanSerialize(Type type) => type == typeof(float);

		public void Serialize(object value, SerializedProperty property)
			=> property.floatValue = (float) value;
	}
}