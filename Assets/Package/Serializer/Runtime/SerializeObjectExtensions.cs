#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Package.Serializer.Runtime
{
	public static partial class SerializeObjectExtensions
	{
		public static SerializedObjectFluent<T> Modify<T>(this T obj)
			where T : Object
			=> new(obj);

		public static SerializedObjectFluent<Object> Modify(this SerializedObject obj)
			=> new(obj);

		public partial class SerializedObjectFluent<T>
			where T : Object
		{
			private readonly List<Action> _modifications = new();
			private readonly SerializedObject _serializedObject;
			private readonly T _obj;

			public SerializedObjectFluent(T obj)
			{
				_obj = obj;
				_serializedObject = new SerializedObject(obj);
			}

			public SerializedObjectFluent(SerializedObject serializedObject)
			{
				_serializedObject = serializedObject;
			}

			public SerializedProperty Get(string propertyName)
				=> _serializedObject.FindProperty(propertyName);

			public SerializedObjectFluent<T> Set(string propertyName, bool value)
			{
				Get(propertyName).boolValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, int value)
			{
				Get(propertyName).intValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, long value)
			{
				Get(propertyName).longValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, float value)
			{
				Get(propertyName).floatValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, double value)
			{
				Get(propertyName).doubleValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, string value)
			{
				Get(propertyName).stringValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Vector2 value)
			{
				Get(propertyName).vector2Value = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Vector3 value)
			{
				Get(propertyName).vector3Value = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Vector4 value)
			{
				Get(propertyName).vector4Value = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Vector2Int value)
			{
				Get(propertyName).vector2IntValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Vector3Int value)
			{
				Get(propertyName).vector3IntValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Quaternion value)
			{
				Get(propertyName).quaternionValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Rect value)
			{
				Get(propertyName).rectValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, RectInt value)
			{
				Get(propertyName).rectIntValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Bounds value)
			{
				Get(propertyName).boundsValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, BoundsInt value)
			{
				Get(propertyName).boundsIntValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Color value)
			{
				Get(propertyName).colorValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Hash128 value)
			{
				Get(propertyName).hash128Value = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, AnimationCurve value)
			{
				Get(propertyName).animationCurveValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Gradient value)
			{
				const BindingFlags bf = BindingFlags.Default | BindingFlags.NonPublic | BindingFlags.Instance;
				var type = typeof(SerializedProperty);
				var propertyInfo = type.GetProperty("gradientValue", bf);
				var serializedProperty = Get(propertyName);
				propertyInfo.SetValue(serializedProperty, value);
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, Object value)
			{
				var property = Get(propertyName);
				property.objectReferenceValue = value;
				return this;
			}

			public SerializedObjectFluent<T> Set<TEnum>(string propertyName, TEnum value)
				where TEnum : Enum
			{
				var values = Enum.GetValues(typeof(TEnum));
				var enumIndex = Array.IndexOf(values, value);
				Get(propertyName).enumValueIndex = enumIndex;
				return this;
			}

			public SerializedObjectFluent<T> Set(string propertyName, IEnumerable<Object> array)
			{
				var property = Get(propertyName);
				property.ClearArray();
				foreach (var item in array)
				{
					var i = property.arraySize++;
					var elementAtIndex = property.GetArrayElementAtIndex(i);
					elementAtIndex.objectReferenceValue = item;
				}

				return this;
			}

			public SerializedObjectFluent<T> Push(string propertyName, Object obj)
			{
				var property = Get(propertyName);
				var index = property.arraySize;
				property.arraySize++;
				var elementAtIndex = property.GetArrayElementAtIndex(index);
				elementAtIndex.objectReferenceValue = obj;
				return this;
			}

			public SerializedObjectFluent<T> ClearArray(string propertyName)
			{
				var property = Get(propertyName);
				property.arraySize = 0;
				return this;
			}

			public SerializedObjectFluent<T> ClearMissingFromArray(string propertyName)
			{
				var property = Get(propertyName);
				var size = property.arraySize;

				var index = 0;
				for (var i = 0; i < size; i++, index++)
				{
					var elementAtIndex = property.GetArrayElementAtIndex(index);
					if (elementAtIndex.objectReferenceValue == null)
						property.DeleteArrayElementAtIndex(index--);
				}

				return this;
			}

			public SerializedObjectFluent<T> Component(
				string property,
				Action<SerializedObjectFluent<Object>> modify
			)
			{
				var obj = Get(property).objectReferenceValue;

				void Modify()
				{
					var serializedObjectFluent = obj.Modify();
					modify(serializedObjectFluent);
					serializedObjectFluent.Apply();
				}

				_modifications.Add(Modify);
				return this;
			}

			public T Apply()
			{
				foreach (var modification in _modifications)
					modification();

				_serializedObject.ApplyModifiedProperties();
				if (_obj != null)
					return _obj;

				return (T)_serializedObject.targetObject;
			}
		}
	}
}

#endif