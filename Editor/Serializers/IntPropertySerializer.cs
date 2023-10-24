using System;
using UnityEditor;

namespace Playdarium.Serializer.Serializers
{
	public class IntPropertySerializer : IPropertySerializer
	{
		public bool CanSerialize(Type type) => type == typeof(int);

		public void Serialize(object value, SerializedProperty property) 
			=> property.intValue = (int) value;
	}
}