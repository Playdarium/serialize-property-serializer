using System;
using UnityEditor;

namespace Package.Serializer
{
	public interface IPropertySerializer
	{
		bool CanSerialize(Type type);

		void Serialize(object value, SerializedProperty property);
	}
}