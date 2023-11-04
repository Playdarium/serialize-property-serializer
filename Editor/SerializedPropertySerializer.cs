using System;
using System.Collections.Generic;
using System.Linq;
using Playdarium.Serializer.Serializers;
using Playdarium.Serializer.Utils;
using UnityEditor;

namespace Playdarium.Serializer
{
	public static class SerializedPropertySerializer
	{
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
			new ObjectPropertySerializer(),
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