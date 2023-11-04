#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Playdarium.Serializer.Runtime.Fluent.Impls
{
	public abstract class ASerializedFluent<T> : ISerializedFluent<T>
	{
		private readonly List<Action> _modifications = new();

		public abstract SerializedProperty GetProperty(string propertyName);

		public ISerializedFluent<T> Set(string propertyName, bool value)
		{
			GetProperty(propertyName).boolValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, int value)
		{
			GetProperty(propertyName).intValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, long value)
		{
			GetProperty(propertyName).longValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, float value)
		{
			GetProperty(propertyName).floatValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, double value)
		{
			GetProperty(propertyName).doubleValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, string value)
		{
			GetProperty(propertyName).stringValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Vector2 value)
		{
			GetProperty(propertyName).vector2Value = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Vector3 value)
		{
			GetProperty(propertyName).vector3Value = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Vector4 value)
		{
			GetProperty(propertyName).vector4Value = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Vector2Int value)
		{
			GetProperty(propertyName).vector2IntValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Vector3Int value)
		{
			GetProperty(propertyName).vector3IntValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Quaternion value)
		{
			GetProperty(propertyName).quaternionValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Rect value)
		{
			GetProperty(propertyName).rectValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, RectInt value)
		{
			GetProperty(propertyName).rectIntValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Bounds value)
		{
			GetProperty(propertyName).boundsValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, BoundsInt value)
		{
			GetProperty(propertyName).boundsIntValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Color value)
		{
			GetProperty(propertyName).colorValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Hash128 value)
		{
			GetProperty(propertyName).hash128Value = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, AnimationCurve value)
		{
			GetProperty(propertyName).animationCurveValue = value;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Gradient value)
		{
			const BindingFlags bf = BindingFlags.Default | BindingFlags.NonPublic | BindingFlags.Instance;
			var type = typeof(SerializedProperty);
			var propertyInfo = type.GetProperty("gradientValue", bf);
			var serializedProperty = GetProperty(propertyName);
			propertyInfo.SetValue(serializedProperty, value);
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, Object value)
		{
			var property = GetProperty(propertyName);
			property.objectReferenceValue = value;
			return this;
		}

		public ISerializedFluent<T> Set<TEnum>(string propertyName, TEnum value)
			where TEnum : Enum
		{
			var values = Enum.GetValues(typeof(TEnum));
			var enumIndex = Array.IndexOf(values, value);
			GetProperty(propertyName).enumValueIndex = enumIndex;
			return this;
		}

		public ISerializedFluent<T> Set(string propertyName, IEnumerable<Object> array)
		{
			var property = GetProperty(propertyName);
			property.ClearArray();
			foreach (var item in array)
			{
				var i = property.arraySize++;
				var elementAtIndex = property.GetArrayElementAtIndex(i);
				elementAtIndex.objectReferenceValue = item;
			}

			return this;
		}

		public ISerializedFluent<T> Push(string propertyName, Object obj)
		{
			var property = GetProperty(propertyName);
			var index = property.arraySize;
			property.arraySize++;
			var elementAtIndex = property.GetArrayElementAtIndex(index);
			elementAtIndex.objectReferenceValue = obj;
			return this;
		}

		public ISerializedFluent<T> ClearArray(string propertyName)
		{
			var property = GetProperty(propertyName);
			property.arraySize = 0;
			return this;
		}

		public ISerializedFluent<T> ClearMissingFromArray(string propertyName)
		{
			var property = GetProperty(propertyName);
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

		public ISerializedFluent<T> Component<TComponent>(
			string propertyName,
			Action<ISerializedFluent<TComponent>> modify
		)
			where TComponent : Object
		{
			var obj = GetProperty(propertyName).objectReferenceValue;

			void Modify()
			{
				var serializedObjectFluent = ((TComponent)obj).Modify();
				modify(serializedObjectFluent);
				serializedObjectFluent.Apply();
			}

			_modifications.Add(Modify);
			return this;
		}

		public ISerializedFluent<T> Property<TObject>(
			string propertyName,
			Action<ISerializedFluent<TObject>> modify
		)
		{
			var property = GetProperty(propertyName);

			void Modify()
			{
				var propertyFluent = new SerializedPropertyFluent<TObject>(property);
				modify(propertyFluent);
				propertyFluent.Apply();
			}

			_modifications.Add(Modify);
			return this;
		}

		public virtual void Apply()
		{
			foreach (var modification in _modifications)
				modification();
		}
	}
}
#endif