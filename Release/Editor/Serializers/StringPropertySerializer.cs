using System;
using UnityEditor;

namespace Playdarium.Serializer.Serializers
{
	public class StringPropertySerializer : IPropertySerializer
	{
		public bool CanSerialize(Type type) => type == typeof(string);

		public void Serialize(object value, SerializedProperty property)
			=> property.stringValue = (string) value;
	}
}