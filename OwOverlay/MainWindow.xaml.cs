using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Diagnostics;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OwOverlayDD
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var desktopWorkingArea = SystemParameters.WorkArea;
			Left = desktopWorkingArea.Right - Width;
			Top = 0;
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e) => Close();

		private void HideButton_Click(object sender, RoutedEventArgs e)
		{
			if (contentPanel.Visibility == Visibility.Visible)
				contentPanel.Visibility = Visibility.Hidden;
			else
				contentPanel.Visibility = Visibility.Visible;
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
            foreach (var item in counterStackPanel.Children)
				if (item is ItemCounter)
					((ItemCounter)item).ResetCounter();

			noteBox.Clear();
		}
	}
}