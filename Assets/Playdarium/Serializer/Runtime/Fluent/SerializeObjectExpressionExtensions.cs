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
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			int value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			long value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			float value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			double value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			string value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Vector2 value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Vector3 value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Vector4 value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Vector2Int value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Vector3Int value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Quaternion value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Rect value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			RectInt value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Bounds value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			BoundsInt value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Color value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Hash128 value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			AnimationCurve value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Gradient value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Object value
		)
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty, TEnum>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			TEnum value
		)
			where TEnum : Enum
			=> serialized.Set(expression.GetPropertyName(), value);

		public static ISerializedFluent<T> Set<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			IEnumerable<Object> array
		)
			=> serialized.Set(expression.GetPropertyName(), array);

		public static ISerializedFluent<T> Push<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Object obj
		)
			=> serialized.Push(GetPropertyName(expression), obj);

		public static ISerializedFluent<T> ClearArray<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression
		)
			=> serialized.ClearArray(GetPropertyName(expression));

		public static ISerializedFluent<T> ClearMissingFromArray<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression
		)
			=> serialized.ClearMissingFromArray(expression.GetPropertyName());

		public static ISerializedFluent<T> Component<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Action<ISerializedFluent<TProperty>> modify
		)
			where TProperty : Object
			=> serialized.Component(GetPropertyName(expression), modify);

		public static ISerializedFluent<T> Property<T, TProperty>(
			this ISerializedFluent<T> serialized,
			Expression<Func<T, TProperty>> expression,
			Action<ISerializedFluent<TProperty>> modify
		)
			=> serialized.Property(GetPropertyName(expression), modify);

		public static string GetPropertyName<T, TProperty>(this Expression<Func<T, TProperty>> expression)
		{
			if (expression.Body is MemberExpression memberExpression)
				return memberExpression.Member.Name;

			throw new ArgumentException("Invalid expression, it should be a member access expression.");
		}
	}
}
#endif