using System;
using UnityEditor;

namespace Playdarium.Serializer.Serializers
{
	public class EnumPropertySerializer : IPropertySerializer
	{
		public bool CanSerialize(Type type) => type.IsEnum;

		public void Serialize(object value, SerializedProperty property)
		{
			var type = value.GetType();
			var values = Enum.GetValues(type);
			var enumIndex = Array.IndexOf(values, value);
			property.enumValueIndex = enumIndex;
		}
	}
}