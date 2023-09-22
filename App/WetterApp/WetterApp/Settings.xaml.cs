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
using System.Windows.Shapes;
using Windows.UI.Xaml.Controls;

namespace WetterApp
{
	public partial class Settings : Window
	{
		public static string ApiLanguage { get; set; }


		public Settings()
		{
			InitializeComponent();
		}

		private void languageList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (languageListComboBox.SelectedItem != null)
			{
				string selectedOption = ((System.Windows.Controls.ComboBoxItem)languageListComboBox.SelectedItem).Tag.ToString();
				MessageBox.Show($"AUsgewählt: {selectedOption}");
				Properties.Settings.Default.language = selectedOption;
				Properties.Settings.Default.Save();
			}
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
