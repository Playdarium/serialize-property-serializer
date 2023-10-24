#if UNITY_EDITOR
using UnityEditor;
using Object = UnityEngine.Object;

namespace Playdarium.Serializer.Runtime.Fluent.Impls
{
	public class SerializedObjectFluent<T> : ASerializedFluent<T> where T : Object
	{
		
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

		public override SerializedProperty GetProperty(string propertyName) 
			=> _serializedObject.FindProperty(propertyName);

		protected override T GetModified()
		{
			_serializedObject.ApplyModifiedProperties();
			if (_obj != null)
				return _obj;

			return (T)_serializedObject.targetObject;
		}
	}
}
#endif