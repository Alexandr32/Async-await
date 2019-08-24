using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTestApp
{
	public class TPLParallel
	{
		public void Main(params object[] arg)
		{
			//Parallel.Invoke(TestAction, TestAction, TestAction, 
			//	() => Console.WriteLine("Lamda process"));

			//Parallel.For(0, 25, ForAction);

			//var data = Enumerable.Range(0, 25).Select(d => d * 2);

			//Parallel.ForEach(data, ForAction);
		}

		private void ForAction(int value)
		{
			Thread.Sleep(1000);
			Console.WriteLine(value);
		}

		private void TestAction()
		{
			Console.WriteLine("Thread id {0} started", Thread.CurrentThread.ManagedThreadId);
			Thread.Sleep(1000);
			Console.WriteLine("Thread id {0} end", Thread.CurrentThread.ManagedThreadId);
		}

	}
}