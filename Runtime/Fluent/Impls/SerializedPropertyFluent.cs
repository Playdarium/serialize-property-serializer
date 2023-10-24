#if UNITY_EDITOR
using UnityEditor;

namespace Playdarium.Serializer.Runtime.Fluent.Impls
{
	public class SerializedPropertyFluent<T> : ASerializedFluent<T>
	{
		private readonly SerializedProperty _serializedProperty;

		public SerializedPropertyFluent(SerializedProperty serializedProperty)
		{
			_serializedProperty = serializedProperty;
		}

		public override SerializedProperty GetProperty(string propertyName)
			=> _serializedProperty.FindPropertyRelative(propertyName);

		protected override T GetModified() => (T)_serializedProperty.managedReferenceValue;
	}
}
#endif