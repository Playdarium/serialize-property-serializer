using System;
using System.Collections;
using System.Linq.Expressions;
using Playdarium.Serializer.Runtime.Fluent;
using Object = UnityEngine.Object;

namespace Playdarium.Serializer.Utils
{
	public static class SerializedObjectFluentExtensions
	{
		public static ISerializedFluent<T> Set<T>(
			this ISerializedFluent<T> so,
			Expression<Func<T, IEnumerable>> expression,
			IEnumerable obj
		)
			where T : Object
			=> so.Set(expression.GetPropertyName(), obj);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> so,
			Expression<Func<T, TProperty>> expression,
			TProperty obj
		)
			where T : Object
		{
			var propertyName = expression.GetPropertyName();
			if (obj is IEnumerable enumerable)
				return so.Set(propertyName, enumerable);

			return so.Set(propertyName, obj);
		}

		public static ISerializedFluent<TSerialized> Set<TSerialized, TSerializable>(
			this ISerializedFluent<TSerialized> so,
			string config,
			TSerializable obj
		)
			where TSerialized : Object
		{
			var property = so.GetProperty(config);
			if (obj is IEnumerable enumerable)
				SerializedPropertySerializer.SerializeArrayProperty(enumerable, property);
			else
				SerializedPropertySerializer.SerializeClassType(obj, property);

			return so;
		}
	}
}