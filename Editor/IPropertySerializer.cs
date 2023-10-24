using System;
using UnityEditor;

namespace Playdarium.Serializer
{
	public interface IPropertySerializer
	{
		bool CanSerialize(Type type);

		void Serialize(object value, SerializedProperty property);
	}
}