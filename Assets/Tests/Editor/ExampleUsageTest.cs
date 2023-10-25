using System;
using System.Linq;
using NUnit.Framework;
using Playdarium.Serializer.Runtime.Fluent;
using Playdarium.Serializer.Utils;
using UnityEngine;

namespace Tests.Editor
{
	public class ExampleUsageTest
	{
		private Database _database;

		[SetUp]
		public void SetUp()
		{
			_database = ScriptableObject.CreateInstance<Database>();
		}

		[Test]
		public void ClassSerializeInPublicField()
		{
			var value = new Data { value = 457 };
			_database.Modify().Set(f => f.dataSingle, value).Apply();
			Assert.AreEqual(value, _database.dataSingle);
		}

		[Test]
		public void ClassSerializeInPrivateField()
		{
			var value = new Data { value = 457 };
			_database.Modify().Set("dataSinglePrivate", value).Apply();
			Assert.AreEqual(value, _database.DataSinglePrivate);
		}

		[Test]
		public void ArraySerializeInPublicField()
		{
			var values = Enumerable.Repeat(new Data { value = 457 }, 10).ToList();
			_database.Modify().Set(f => f.dataArray, values).Apply();
			Assert.True(values.SequenceEqual(_database.dataArray), "values.SequenceEqual(_database.dataArray)");
		}

		[Test]
		public void ArraySerializeInPrivateField()
		{
			var values = Enumerable.Repeat(new Data { value = 457 }, 10).ToList();
			_database.Modify().Set("dataArrayPrivate", values).Apply();
			Assert.True(values.SequenceEqual(_database.DataArrayPrivate),
				"values.SequenceEqual(_database.DataArrayPrivate)");
		}

		[Test]
		public void UnityObjectSerializePublicField()
		{
			var instance = ScriptableObject.CreateInstance<UnityObject>();
			_database.Modify().Set(f => f.objectSingle, instance).Apply();
			Assert.AreEqual(instance, _database.objectSingle);
		}

		[Serializable]
		public class Data
		{
			public int value;

			protected bool Equals(Data other) => value == other.value;

			public override bool Equals(object obj)
			{
				if (ReferenceEquals(null, obj)) return false;
				if (ReferenceEquals(this, obj)) return true;
				if (obj.GetType() != this.GetType()) return false;
				return Equals((Data)obj);
			}

			public override int GetHashCode() => value;

			public override string ToString() => $"{nameof(value)}: {value}";
		}

		public class UnityObject : ScriptableObject
		{
		}

		public class Database : ScriptableObject
		{
			public Data dataSingle;
			public Data[] dataArray;

			[SerializeField] private Data dataSinglePrivate;
			public Data DataSinglePrivate => dataSinglePrivate;

			[SerializeField] private Data[] dataArrayPrivate;
			public Data[] DataArrayPrivate => dataArrayPrivate;

			public UnityObject objectSingle;
			public UnityObject[] objectArray;

			[SerializeField] private UnityObject objectSinglePrivate;
			public UnityObject ObjectSinglePrivate => objectSinglePrivate;

			[SerializeField] private UnityObject[] objectArrayPrivate;
			public UnityObject[] ObjectArrayPrivate => objectArrayPrivate;
		}
	}
}