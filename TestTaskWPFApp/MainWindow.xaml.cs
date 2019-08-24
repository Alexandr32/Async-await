using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace TestTaskWPFApp
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			FirstNumber.Text = 5.ToString();
			SecondNumber.Text = 5.ToString();
			SetEnableUi(true);
		}
		private  CancellationTokenSource _tokenSource=new CancellationTokenSource();
		private IProgress<double> _progress;
		private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			if (!Int32.TryParse(FirstNumber.Text, out var x))
			{
				Sum.Text = "Первое число плохое";
				return;
			}
			if (!Int32.TryParse(SecondNumber.Text, out var y))
			{
				Sum.Text = "Второе число плохое";
				return;
			}
			SetEnableUi(false);
			try
			{
				if (_tokenSource.IsCancellationRequested)
				{
					_tokenSource = new CancellationTokenSource();
				}
				_progress = new Progress<double>(d => Title = $"Progress {d:P2}");
				var res = await CalcAsync(x, y);
				Sum.Text = res.ToString();
			}
			catch (Exception exception)
			{
				Sum.Text =  exception.Message;
			}

			finally
			{
				SetEnableUi(true);
			}
		}

		private Task<int> CalcAsync(int x, int y)
		{
			return Task.Run(() => Calc(x, y),_tokenSource.Token);
		}

		private int Calc(int x, int y)
		{
			for (int i = 0; i <= 100; i++)
			{
				_progress.Report((double)i/100);
				Thread.Sleep(100);
			}
			if(!_tokenSource.IsCancellationRequested)
			{
				return x + y;
			}

			MessageBox.Show("tokenSource");
			return 0;
		}

		private void ButtonCancle_OnClick(object sender, RoutedEventArgs e)
		{
			_tokenSource.Cancel();
		}

		private void SetEnableUi(bool value)
		{
			FirstNumber.IsEnabled = value;
			SecondNumber.IsEnabled = value;
			Sum.IsEnabled = value;
			ButtonBase.IsEnabled = value;
			ButtonCancle.IsEnabled = !value;
		}

	}
}
