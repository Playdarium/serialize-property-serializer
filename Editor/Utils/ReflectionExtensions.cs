using System;

namespace Playdarium.Serializer.Utils
{
	public static class ReflectionExtensions
	{
		public static bool HasInterface<T>(this Type type) 
			=> type.GetInterface(typeof(T).Name) != null;
	}
}