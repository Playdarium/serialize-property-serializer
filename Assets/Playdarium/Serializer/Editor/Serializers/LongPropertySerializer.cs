using System;
using UnityEditor;

namespace Playdarium.Serializer.Serializers {
	public class LongPropertySerializer : IPropertySerializer
	{
		public bool CanSerialize(Type type) => type == typeof(long);

		public void Serialize(object value, SerializedProperty property) 
			=> property.longValue = (long) value;
	}
}