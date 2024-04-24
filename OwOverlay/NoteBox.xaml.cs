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
	/// Interaction logic for AutoCompleteNoteBox.xaml
	/// </summary>
	public partial class NoteBox : UserControl
	{
		public NoteBox()
		{
			InitializeComponent();
		}

		public void Clear()
		{
			lineStackPane.Children.Clear();
			lineStackPane.Children.Add(new AutoCompleteTextBox());
		}
	}
}
