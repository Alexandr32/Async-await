using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTestApp
{
	public class TPLTask
	{
		public void Main()
		{
			var value = 123;

			#region 1 акт

			//var task = new Task(TaskAction); // Создание "холодной" задачи. Что бы её запустить надо вызвать метод Start()
			//task.Start();

			#endregion

			#region 2 акт

			//var task = new Task(() => TaskActionWithParameters(value)); // Создание задачи с параметрами
			//task.RunSynchronously();                                    // Запуск задачи в синхронном режиме

			#endregion

			#region 3 акт

			//var task = Task.Run(() => TaskActionWithParameters(value));                       // Создание и запуск "горячей" задач

			#endregion

			#region 4 акт

			//var task = Task.Factory.StartNew(o => TaskActionWithParameters((int)o), value);   // Тоже через фабрику

			#endregion

			#region 5 акт

			//Action asyncAction = TaskAction;    // Здесь должен быть какой-то объект, который предоставляет пару методов BeginXXX EndXXX
			//var task = Task.Factory.FromAsync(asyncAction.BeginInvoke, asyncAction.EndInvoke, null);
			//Console.WriteLine("Задача создана и запущена");
			//task.Wait();      // ТАк можно дождаться завершения выполнения задачи

			#endregion

			#region 6 акт

			////Задачи с результатом
			//var valueTask = new Task<int>(() => GetStrLength(value.ToString()));
			//valueTask.Start();             // Создаём "холодную" задачи и запускаем её на выполнение, делая её "горячей"
			//							   //valueTask = Task.Run(() => GetStrLength(value.ToString()));                                   // Создаём и запускаем задачу в одно действие
			//valueTask.ContinueWith(t => Console.WriteLine("Task result = {0}", t.Result));             // К любой задаче можно прикрепить "продолжение". В результате тоже получается задача, к которой можно прикрепить ещё одно продолжение... и так сколько угодно.

			//Console.WriteLine("Task result = {0}", valueTask.Result);

			#endregion
		}

		private int GetStrLength(string str)
		{
			Console.WriteLine("Task id {0}; thread id {1} started - data: {2}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, str);
			Thread.Sleep(3000);
			Console.WriteLine("Task id {0}; thread id {1} end - data: {2}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, str);
			return str.Length;
		}

		private void TaskActionWithParameters(int data)
		{
			Console.WriteLine("Task id {0}; thread id {1} started - data {2}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, data);
			Thread.Sleep(3000);
			Console.WriteLine("Task id {0}; thread id {1} end - data {2}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, data);
		}

		private static void TaskAction()
		{
			Console.WriteLine("Task id {0}; thread id {1} started", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
			Thread.Sleep(3000);
			Console.WriteLine("Task id {0}; thread id {1} end", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
		}
	}
}