using System;
using System.Collections;
using System.Linq.Expressions;
using Package.Serializer.Runtime;
using Object = UnityEngine.Object;

namespace Package.Serializer.Utils
{
	public static class SerializedObjectFluentExtensions
	{
		public static SerializeObjectExtensions.SerializedObjectFluent<T> Set<T>(
			this SerializeObjectExtensions.SerializedObjectFluent<T> so,
			Expression<Func<T, IEnumerable>> expression,
			IEnumerable obj
		)
			where T : Object
			=> so.Set(expression.GetPropertyName(), obj);

		public static SerializeObjectExtensions.SerializedObjectFluent<T> Set<T, TProperty>(
			this SerializeObjectExtensions.SerializedObjectFluent<T> so,
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

		public static SerializeObjectExtensions.SerializedObjectFluent<TSerialized> Set<TSerialized, TSerializable>(
			this SerializeObjectExtensions.SerializedObjectFluent<TSerialized> so,
			string config,
			TSerializable obj
		)
			where TSerialized : Object
		{
			var property = so.Get(config);
			if (obj is IEnumerable enumerable)
				SerializedPropertySerializer.SerializeArrayProperty(enumerable, property);
			else
				SerializedPropertySerializer.SerializeClassType(obj, property);

			return so;
		}
	}
}