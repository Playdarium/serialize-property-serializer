using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Playdarium.Serializer.Serializers;
using Playdarium.Serializer.Utils;
using UnityEditor;
using UnityEngine;

namespace Playdarium.Serializer
{
	public static class SerializedPropertySerializer
	{
		private const BindingFlags FIELD_BINDING = BindingFlags.Instance
		                                           | BindingFlags.Public
		                                           | BindingFlags.NonPublic;

		private static readonly List<Type> PrimitiveTypes = new()
		{
			typeof(byte),
			typeof(ushort),
			typeof(short),
			typeof(uint),
			typeof(int),
			typeof(ulong),
			typeof(long),
			typeof(float),
			typeof(decimal),
			typeof(string),
			typeof(char)
		};

		private static readonly List<IPropertySerializer> CustomSerializers;

		private static readonly List<IPropertySerializer> Serializers = new()
		{
			new ShortPropertySerializer(),
			new IntPropertySerializer(),
			new LongPropertySerializer(),
			new BytePropertySerializer(),
			new BooleanPropertySerializer(),
			new StringPropertySerializer(),
			new FloatPropertySerializer(),
			new EnumPropertySerializer(),
			new ArrayOrListPropertySerializer(),
			new ClassOrStructPropertySerializer()
		};

		static SerializedPropertySerializer()
		{
			CustomSerializers = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(assembly => assembly.GetTypes())
				.Where(type => type.HasInterface<IPropertySerializer>())
				.Where(type => Serializers.All(instance => instance.GetType() != type))
				.Select(Activator.CreateInstance)
				.Cast<IPropertySerializer>()
				.ToList();
		}

		public static void SerializeArrayProperty(IEnumerable array, SerializedProperty arrayProperty)
		{
			var currentIndex = 0;
			arrayProperty.arraySize = 0;
			foreach (var item in array)
			{
				arrayProperty.arraySize++;
				var element = arrayProperty.GetArrayElementAtIndex(currentIndex++);
				var type = item.GetType();
				if (PrimitiveTypes.Contains(type))
					SerializeValueProperty(item, element);
				else
					SerializeNonPrimitiveType(item, type, element);
			}
		}

		public static void SerializeClassType<T>(T item, SerializedProperty element)
			=> SerializeClassType(item, typeof(T), element);

		public static void SerializeClassType(object item, Type type, SerializedProperty element)
		{
			var fieldsInfo = type.GetFields(FIELD_BINDING);
			var serializedFields = fieldsInfo.Where(field =>
				field.IsPublic || field.IsPrivate && field.IsDefined(typeof(SerializeField)));
			foreach (var serializedField in serializedFields)
			{
				var value = serializedField.GetValue(item);
				var property = element.FindPropertyRelative(serializedField.Name);
				try
				{
					SerializeValueProperty(value, property);
				}
				catch (Exception e)
				{
					Debug.Log(
						$"[{nameof(SerializedPropertySerializer)}] Can't serialize property {serializedField.FieldType} Name: {serializedField.Name}");
					throw e;
				}
			}
		}

		private static void SerializeNonPrimitiveType(object item, Type type, SerializedProperty element)
		{
			var fieldsInfo = type.GetFields(FIELD_BINDING);
			var serializedFields = fieldsInfo.Where(field => !field.IsNotSerialized || field.IsPublic);
			foreach (var serializedField in serializedFields)
			{
				var value = serializedField.GetValue(item);
				if (value == null)
				{
					Debug.LogError(
						$"[{nameof(SerializedPropertySerializer)}] Can't serialize \"{serializedField.Name}\", value is null");
					continue;
				}

				var property = element.FindPropertyRelative(serializedField.Name);
				SerializeValueProperty(value, property);
			}
		}

		public static void SerializeValueProperty(object value, SerializedProperty property)
		{
			var type = value.GetType();
			var serializer = FindSerializer(type);
			if (serializer == null)
				throw new Exception(
					$"[{nameof(SerializedPropertySerializer)}] Can't serialize property {type.Name} with type {type}");

			serializer.Serialize(value, property);
		}

		private static IPropertySerializer FindSerializer(Type type)
			=> CustomSerializers.Find(f => f.CanSerialize(type))
			   ?? Serializers.Find(f => f.CanSerialize(type));
	}
}