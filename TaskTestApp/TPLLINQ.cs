using System;
using System.Linq;
using System.Threading;

namespace TaskTestApp
{
	public class TPLLINQ
	{
		public void Main()
		{
			var data = Enumerable.Range(0, 25).Select(p => p * 2).ToList();
			var temp = data.AsParallel()
				.WithCancellation(new CancellationToken()) // экстренное прерывание
				.WithDegreeOfParallelism(3) // количество задач
				.WithExecutionMode(ParallelExecutionMode.ForceParallelism)// последовательно или паралельно
				.Max();
			Console.WriteLine(temp);
		}
	}
}