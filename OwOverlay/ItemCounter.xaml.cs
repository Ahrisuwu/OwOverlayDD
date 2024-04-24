using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OwOverlayDD
{
    /// <summary>
    /// Interaction logic for ItemCounter.xaml
    /// </summary>
    public partial class ItemCounter : UserControl
    {
        public static DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(ItemCounter));
        public ImageSource Source { get => (ImageSource)GetValue(SourceProperty); set => SetValue(SourceProperty, value); }

        private int _count = 0;

        public ItemCounter()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void ResetCounter()
        {
			counter.Text = (_count = 0).ToString();
		}

		private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			counter.Text = (++_count).ToString();
		}

		private void image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
            if (_count > 0)
			    counter.Text = (--_count).ToString();
		}

		private void image_MouseDown(object sender, MouseButtonEventArgs e)
		{
            if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Pressed)
                ResetCounter();
		}
	}
}
