using System;
using UnityEditor;

namespace Package.Serializer.Serializers {
	public class BooleanPropertySerializer : IPropertySerializer
	{
		public bool CanSerialize(Type type) => type == typeof(bool);

		public void Serialize(object value, SerializedProperty property) 
			=> property.boolValue = (bool) value;
	}
}