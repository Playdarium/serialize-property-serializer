#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Package.Serializer.Runtime
{
	public static partial class SerializeObjectExtensions
	{
		public partial class SerializedObjectFluent<T>
		{
			public SerializedProperty Get<TProperty>(Expression<Func<T, TProperty>> expression)
				=> Get(expression.GetPropertyName());

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				bool value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				int value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				long value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				float value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				double value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				string value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Vector2 value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Vector3 value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Vector4 value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Vector2Int value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Vector3Int value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Quaternion value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Rect value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				RectInt value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Bounds value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				BoundsInt value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Color value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Hash128 value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				AnimationCurve value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Gradient value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Object value
			)
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty, TEnum>(
				Expression<Func<T, TProperty>> expression,
				TEnum value
			)
				where TEnum : Enum
				=> Set(expression.GetPropertyName(), value);

			public SerializedObjectFluent<T> Set<TProperty>(
				Expression<Func<T, TProperty>> expression,
				IEnumerable<Object> array
			)
				=> Set(expression.GetPropertyName(), array);

			public SerializedObjectFluent<T> Push<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Object obj
			)
				=> Push(expression.GetPropertyName(), obj);

			public SerializedObjectFluent<T> ClearArray<TProperty>(
				Expression<Func<T, TProperty>> expression
			)
				=> ClearArray(expression.GetPropertyName());

			public SerializedObjectFluent<T> ClearMissingFromArray<TProperty>(
				Expression<Func<T, TProperty>> expression
			)
				=> ClearMissingFromArray(expression.GetPropertyName());

			public SerializedObjectFluent<T> Component<TProperty>(
				Expression<Func<T, TProperty>> expression,
				Action<SerializedObjectFluent<Object>> modify
			)
				where TProperty : Object
				=> Component(expression.GetPropertyName(), modify);
		}

		public static string GetPropertyName<T, TProperty>(this Expression<Func<T, TProperty>> expression)
		{
			if (expression.Body is MemberExpression memberExpression)
				return memberExpression.Member.Name;

			throw new ArgumentException("Invalid expression, it should be a member access expression.");
		}
	}
}
#endif