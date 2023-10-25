using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Playdarium.Serializer.Serializers
{
	public class ClassOrStructPropertySerializer : IPropertySerializer
	{
		private const BindingFlags FIELD_BINDING = BindingFlags.Instance
		                                           | BindingFlags.Public
		                                           | BindingFlags.NonPublic;
		
		public bool CanSerialize(Type type) => type.IsClass || type.IsValueType;

		public void Serialize(object value, SerializedProperty property)
		{
			var type = value.GetType();
			var fieldsInfo = type.GetFields(FIELD_BINDING);
			var serializedFields = fieldsInfo.Where(field =>
				field.IsPublic || field.IsPrivate && field.IsDefined(typeof(SerializeField)));
			foreach (var serializedField in serializedFields)
			{
				var fieldValue = serializedField.GetValue(value);
				var propertyRelative = property.FindPropertyRelative(serializedField.Name);
				try
				{
					SerializedPropertySerializer.SerializeValueProperty(fieldValue, propertyRelative);
				}
				catch (Exception e)
				{
					Debug.Log(
						$"[{nameof(SerializedPropertySerializer)}] Can't serialize property {serializedField.FieldType} Name: {serializedField.Name}");
					throw e;
				}
			}
		}
	}
}