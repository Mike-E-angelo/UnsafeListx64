using System;
using System.Diagnostics;

namespace UnsafeListx64
{
	class Program
	{
		static void Main()
		{
			var testsCount    = 5;
			var elementsCount = 20 * 500 * 1000;

			Console.WriteLine("------------------------");
			for (int i = 0; i < testsCount; ++i)
			{
				TestArray(elementsCount);
			}

			GC.Collect();
			GC.WaitForPendingFinalizers();

			Console.WriteLine("------------------------");
			for (int i = 0; i < testsCount; ++i)
			{
				TestUnsafeList(elementsCount);
			}
		}

		static void TestArray(int elementsCount)
		{
			Console.WriteLine("Array");
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			var array = new Poco[elementsCount];

			for (int i = 0; i < elementsCount; ++i)
			{
				array[i] = CreatePoco(i);
			}

			stopwatch.Stop();
			Console.WriteLine($"Insertion time: {stopwatch.ElapsedMilliseconds}");
			int sum = 0;

			stopwatch.Restart();

			for (int i = 0; i < elementsCount; ++i)
			{
				var poco = array[i];
				sum += poco.Field1;
				sum += poco.Field2;
				sum += poco.Field3;
				sum += poco.Field4;
				sum += poco.Field5;
				sum += poco.Field6;
				sum += poco.Field7;
				sum += poco.Field8;
				sum += poco.Field9;
				sum += poco.Field10;
				sum += poco.Field11;
				sum += poco.Field12;
				sum += poco.Field13;
				sum += poco.Field14;
				sum += poco.Field15;
				sum += poco.Field16;
			}

			stopwatch.Stop();

			Console.WriteLine($"Sum: {sum}");
			Console.WriteLine($"Calculation time: {stopwatch.ElapsedMilliseconds}");
		}

		static void TestUnsafeList(int elementsCount)
		{
			Console.WriteLine("UnsafeList");
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			var unsafeList = new UnsafeList<Poco>(elementsCount, 18);
			for (int i = 0; i < elementsCount; ++i)
			{
				unsafeList.Add(CreatePoco(i));
			}

			stopwatch.Stop();
			Console.WriteLine($"Insertion time: {stopwatch.ElapsedMilliseconds}");
			var sum = 0;

			stopwatch.Restart();

			for (int i = 0; i < elementsCount; ++i)
			{
				var poco = unsafeList[i];
				sum += poco.Field1;
				sum += poco.Field2;
				sum += poco.Field3;
				sum += poco.Field4;
				sum += poco.Field5;
				sum += poco.Field6;
				sum += poco.Field7;
				sum += poco.Field8;
				sum += poco.Field9;
				sum += poco.Field10;
				sum += poco.Field11;
				sum += poco.Field12;
				sum += poco.Field13;
				sum += poco.Field14;
				sum += poco.Field15;
				sum += poco.Field16;
			}

			stopwatch.Stop();

			Console.WriteLine($"Sum: {sum}");
			Console.WriteLine($"Calculation time: {stopwatch.ElapsedMilliseconds}");
		}

		static Poco CreatePoco(int i) => new Poco
		{
			Field1  = i,
			Field2  = i - 1,
			Field3  = i - 2,
			Field4  = i - 3,
			Field5  = i - 4,
			Field6  = i - 5,
			Field7  = i - 6,
			Field8  = i - 7,
			Field9  = i - 7,
			Field10 = i - 6,
			Field11 = i - 5,
			Field12 = i - 4,
			Field13 = i - 3,
			Field14 = i - 2,
			Field15 = i - 1,
			Field16 = i
		};
	}
}