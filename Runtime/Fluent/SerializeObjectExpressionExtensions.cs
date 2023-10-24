#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Playdarium.Serializer.Runtime.Fluent
{
	public static class SerializeObjectExpressionExtensions
	{
		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			bool value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			int value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			long value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			float value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			double value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			string value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Vector2 value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Vector3 value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Vector4 value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Vector2Int value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Vector3Int value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Quaternion value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Rect value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			RectInt value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Bounds value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			BoundsInt value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Color value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Hash128 value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			AnimationCurve value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Gradient value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Object value
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty, TEnum>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			TEnum value
		)
			where T : Object
			where TEnum : Enum
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			IEnumerable<Object> array
		) where T : Object
			=> serialized.Set(expression.GetPropertyName(), array);

		public static ISerializedFluent<T> Push<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Object obj
		) where T : Object
			=> serialized.Push(GetPropertyName(expression), obj);

		public static ISerializedFluent<T> ClearArray<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression
		) where T : Object
			=> serialized.ClearArray(GetPropertyName(expression));

		public static ISerializedFluent<T> ClearMissingFromArray<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression
		) where T : Object
			=> serialized.ClearMissingFromArray(expression.GetPropertyName());

		public static ISerializedFluent<T> Component<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Action<ISerializedFluent<TProperty>> modify
		)
			where T : Object
			where TProperty : Object
			=> serialized.Component(GetPropertyName(expression), modify);

		public static string GetPropertyName<T, TProperty>(this Expression<Func<T, TProperty>> expression)
		{
			if (expression.Body is MemberExpression memberExpression)
				return memberExpression.Member.Name;

			throw new ArgumentException("Invalid expression, it should be a member access expression.");
		}
	}
}
#endif