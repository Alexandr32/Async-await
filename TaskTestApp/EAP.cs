using System;
using System.ComponentModel;
using System.Threading;

namespace TaskTestApp
{
	public class EAP
	{
		public void Main()
		{
			var worker = new BackgroundWorker(); // Объект, занимающийся асинхронной фоновой работой
			worker.DoWork += DownloadAsync;      // Устанавливаем метод, который должен быть вызван асинхронно
			worker.RunWorkerAsync();             // Запускаем процесс
		}

		private void DownloadAsync(object sender, DoWorkEventArgs e)
		{
			Thread.Sleep(3000); // Тяжелая операция
			Console.Write("Данные скачались");
		}

	}
}