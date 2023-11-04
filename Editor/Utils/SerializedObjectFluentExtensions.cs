using System;
using System.Collections;
using System.Linq.Expressions;
using Playdarium.Serializer.Runtime.Fluent;

namespace Playdarium.Serializer.Utils
{
	public static class SerializedObjectFluentExtensions
	{
		public static ISerializedFluent<T> Set<T>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, IEnumerable>> expression,
			IEnumerable obj
		)
			=> serialized.Set(expression.GetPropertyName(), obj);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			TProperty obj
		)
		{
			var propertyName = expression.GetPropertyName();
			return serialized.Set(propertyName, obj);
		}

		public static ISerializedFluent<TSerialized> Set<TSerialized, TSerializable>(
			this ISerializedFluent<TSerialized> serialized,
			string config,
			TSerializable obj
		)
		{
			var property = serialized.GetProperty(config);
			SerializedPropertySerializer.SerializeValueProperty(obj, property);
			return serialized;
		}
	}
}