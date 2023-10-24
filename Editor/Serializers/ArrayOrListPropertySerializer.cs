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
			=> SerializedPropertySerializer.SerializeArrayProperty((IEnumerable) value, property);
	}
}