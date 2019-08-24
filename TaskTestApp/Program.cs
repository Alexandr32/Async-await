using System.Collections.Concurrent;
using static System.Console;

namespace TaskTestApp
{
	class Program
	{
		private static void Main()
		{
			WriteLine("Асинхронная работа началась.");

			var example = new TPLAsyncAwait();
			example.Main();

			WriteLine("Асинхронная работа закончилась.");

			ReadKey();
		}
	}
}
