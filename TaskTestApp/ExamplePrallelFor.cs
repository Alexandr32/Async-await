using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TaskTestApp
{
	public class ExamplePrallelFor
	{
		public void Main()
		{
			Console.WriteLine("Start");

			var random = new Random();
			var stopwatch = new Stopwatch();
			var data = new int[99999999];

			stopwatch.Start();
			for (var i = 0; i < data.Length; i++)
			{
				data[i] = random.Next(10);
			}
			stopwatch.Stop();
			Console.WriteLine($"{stopwatch.Elapsed.TotalSeconds}");
			stopwatch.Reset();

			stopwatch.Start();
			Parallel.For(0, data.Length, i => data[i] = random.Next(10));
			stopwatch.Stop();
			Console.WriteLine($"{stopwatch.Elapsed.TotalSeconds}");
			stopwatch.Reset();

			Console.WriteLine("Stop");
		}
	}
}