using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for AutoCompleteTextBox.xaml
    /// </summary>
    public partial class AutoCompleteTextBox : UserControl
    {
        private static List<String> hints = new () {
            "Unlocked Strongbox",
            "Goal Strongbox",
            "Heirloom Chest",
            "Eldritch Altar",
            "Altar of Light",
            "Stack of Books",
            "Pile of Bones",
            "Discarded Pack",
            "Sconce",
            "Crate",
            "Sack",
            "Iron Maiden",
            "Suit of Armor",
            "Dinner Cart",
            "Decorative Urn",
            "Locked Display Cabinet",
            "Confession Booth",
            "Holy Fountain",
            "Bookshelf",
            "Alchemy Table",
            "Knife Rack",
            "Sarcophagus",
            "Mummified Remains",
            "Sacrificial Stone",
            "Skull Altar",
            "Occult Scrawlings",
            "Moonshine Barrel",
            "Locked Sarcophagus",
            "Makeshift Dining Table",
            "Pile of Scrolls",
            "Ancient Coffin",
            "Old Tree",
            "Beast Carcass",
            "Pristine Fountain",
            "Travellers Tent",
            "Cosmic Spiderweb",
            "Lost Luggage",
            "Shallow Grave",
            "Troubling Effigy",
            "Travellers Tent Tutorial",
            "Bandits Trapped Chest",
            "Shamblers Altar",
            "Shipment Crates",
            "Protective Ward",
            "Barnacle Crusted Chest",
            "Brackish Tidepool",
            "Fish Idol",
            "Giant Oyster",
            "Giant Fish Carcass",
            "Ships Figurehead",
            "Eerie Coral",
            "Bas Relief",
            "Secret Stash",
            "Ancestors Knapsack",
            "Incursion Knapsack",
            "Open Grave",
			"Bloodflowers",
            "Damned Fountain",
            "Disturbing Diversion",
            "Forgotten Delicacies",
            "Hooded Shrew",
            "Wizened Shrew",
            "Pile of Strange Bones",
            "Throbbing Coccoons",
            "Thronging Hive",
            "Wine Crate"
		};

        private String hint = "";

        public AutoCompleteTextBox()
        {
            InitializeComponent();
        }

        private void userTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = userTextBox.Text;

            if (text.Equals(""))
            {
                hintTextBox.Text = "";
                return;
            }

            hint = hints.Find(h => h.ToLower().StartsWith(text.ToLower())) ?? "";

            hintTextBox.Text = hint;
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e) => userTextBox.Focus();

		private void userTextBox_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
            if (Parent is StackPanel sp && sp.Children.Count > 1) 
            {
                sp.Children.Remove(this);            
            }
		}

		private void userTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (Parent is not StackPanel sp) return;

			switch (e.Key)
			{
				case Key.Enter:
					if (hint != "")
					{
						userTextBox.Text = hint;
						hintTextBox.Text = "";
					}

					var actb = new AutoCompleteTextBox();

					actb.Loaded += (s, e) => actb.Focus();

					sp.Children.Insert(sp.Children.IndexOf(this) + 1, actb);
					break;

				case Key.Back:
					if (userTextBox.Text.Length == 0 && sp.Children.Count > 1)
						sp.Children.Remove(this);
					break;

                case Key.Escape:
                    hint = hintTextBox.Text = "";
                    break;
			}
		}
	}
}
