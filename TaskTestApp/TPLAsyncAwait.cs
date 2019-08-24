using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTestApp
{
	public class TPLAsyncAwait
	{
		public async void Main()
		{
			var result = await GetStrLengthAsync("123");
			Console.WriteLine("Task result = {0}", result);
		}

		private async Task<int> GetStrLengthAsync(string str)
		{
			Console.WriteLine("Создаём задачу thread id {0}", Thread.CurrentThread.ManagedThreadId);
			var valueTask = Task.Run(() => GetStrLength(str));
			Console.WriteLine("Задача запущена thread id {0}", Thread.CurrentThread.ManagedThreadId);
			
			var result = await valueTask;
			return result;
		}

		private int GetStrLength(string str)
		{
			Thread.Sleep(3000);
			return str.Length;
		}
	}
}