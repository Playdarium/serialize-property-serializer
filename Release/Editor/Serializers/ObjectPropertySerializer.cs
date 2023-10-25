using System;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Playdarium.Serializer.Serializers
{
	public class ObjectPropertySerializer : IPropertySerializer
	{
		public bool CanSerialize(Type type) => type == typeof(Object) || type.IsSubclassOf(typeof(Object));

		public void Serialize(object value, SerializedProperty property)
		{
			property.objectReferenceValue = (Object)value;
		}
	}
}