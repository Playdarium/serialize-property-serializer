using System;
using UnityEditor;

namespace Package.Serializer.Serializers
{
	public class ShortPropertySerializer : IPropertySerializer
	{
		public bool CanSerialize(Type type) => type == typeof(short);

		public void Serialize(object value, SerializedProperty property) 
			=> property.intValue = (short) value;
	}
}