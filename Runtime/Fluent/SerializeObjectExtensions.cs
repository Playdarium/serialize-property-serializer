#if UNITY_EDITOR

using Playdarium.Serializer.Runtime.Fluent.Impls;
using UnityEditor;
using UnityEngine;

namespace Playdarium.Serializer.Runtime.Fluent
{
	public static partial class SerializeObjectExtensions
	{
		public static ISerializedFluent<T> Modify<T>(this T obj)
			where T : Object
			=> new SerializedObjectFluent<T>(obj);

		public static ISerializedFluent<Object> Modify(this SerializedObject obj)
			=> new SerializedObjectFluent<Object>(obj);
	}
}

#endif