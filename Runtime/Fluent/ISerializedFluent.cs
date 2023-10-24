#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Playdarium.Serializer.Runtime.Fluent
{
	public interface ISerializedFluent<out T>
	{

		SerializedProperty GetProperty(string propertyName);
		
		ISerializedFluent<T> Set(string propertyName, bool value);
		ISerializedFluent<T> Set(string propertyName, int value);
		ISerializedFluent<T> Set(string propertyName, long value);
		ISerializedFluent<T> Set(string propertyName, float value);
		ISerializedFluent<T> Set(string propertyName, double value);
		ISerializedFluent<T> Set(string propertyName, string value);
		ISerializedFluent<T> Set(string propertyName, Vector2 value);
		ISerializedFluent<T> Set(string propertyName, Vector3 value);
		ISerializedFluent<T> Set(string propertyName, Vector4 value);
		ISerializedFluent<T> Set(string propertyName, Vector2Int value);
		ISerializedFluent<T> Set(string propertyName, Vector3Int value);
		ISerializedFluent<T> Set(string propertyName, Quaternion value);
		ISerializedFluent<T> Set(string propertyName, Rect value);
		ISerializedFluent<T> Set(string propertyName, RectInt value);
		ISerializedFluent<T> Set(string propertyName, Bounds value);
		ISerializedFluent<T> Set(string propertyName, BoundsInt value);
		ISerializedFluent<T> Set(string propertyName, Color value);
		ISerializedFluent<T> Set(string propertyName, Hash128 value);
		ISerializedFluent<T> Set(string propertyName, AnimationCurve value);
		ISerializedFluent<T> Set(string propertyName, Gradient value);
		ISerializedFluent<T> Set(string propertyName, Object value);

		ISerializedFluent<T> Set<TEnum>(string propertyName, TEnum value)
			where TEnum : Enum;

		ISerializedFluent<T> Set(string propertyName, IEnumerable<Object> array);

		ISerializedFluent<T> Push(string propertyName, Object obj);
		ISerializedFluent<T> ClearArray(string propertyName);
		ISerializedFluent<T> ClearMissingFromArray(string propertyName);

		ISerializedFluent<T> Component<TComponent>(
			string propertyName,
			Action<ISerializedFluent<TComponent>> modify
		)
			where TComponent : Object;

		ISerializedFluent<T> Property<TObject>(
			string propertyName,
			Action<ISerializedFluent<TObject>> modify
		);

		T Apply();
	}
}
#endif