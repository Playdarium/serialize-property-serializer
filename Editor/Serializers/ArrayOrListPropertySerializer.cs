using System;
using System.Collections;
using Playdarium.Serializer.Utils;
using UnityEditor;

namespace Playdarium.Serializer.Serializers
{
	public class ArrayOrListPropertySerializer : IPropertySerializer
	{
		public bool CanSerialize(Type type) => type.IsArray || type.HasInterface<IList>();

		public void Serialize(object value, SerializedProperty property)
		{
			var array = (IEnumerable)value;
			var currentIndex = 0;
			property.arraySize = 0;
			foreach (var item in array)
			{
				property.arraySize++;
				var element = property.GetArrayElementAtIndex(currentIndex++);
				SerializedPropertySerializer.SerializeValueProperty(item, element);
			}
		}
	}
}