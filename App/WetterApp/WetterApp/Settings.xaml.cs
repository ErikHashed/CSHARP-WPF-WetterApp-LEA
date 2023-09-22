using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using Newtonsoft.Json;

namespace WetterApp
{
	public partial class Settings : Window
	{
		private static string settingsFilePath = $"../../files/settings.txt";
		public static string SettingsFilePath { get { return settingsFilePath; } }


		public static string ApiLanguage { get; set; }
		public static string MeasureUnit { get; set; }
		public static bool Windspeed { get; set; }



		public Settings()
		{
			InitializeComponent();
		}

		private void languageList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (languageListComboBox.SelectedItem != null)
			{
				string selectedOption = ((System.Windows.Controls.ComboBoxItem)languageListComboBox.SelectedItem).Tag.ToString();
				MessageBox.Show($"Ausgewählt: {selectedOption}");
				ApiLanguage = selectedOption;
			}
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void ApplyButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string[] lines = new string[]
				{
					"lang=" + ApiLanguage,
					"units=" + MeasureUnit,
					"windspeed=" + Windspeed,
				};

				File.WriteAllLines(settingsFilePath, lines);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error saving settings: {ex.Message}");
			}
		}

		private void temperatureUnitList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (temperatureUnitComboList.SelectedItem != null)
			{
				string selectedOption = ((System.Windows.Controls.ComboBoxItem)temperatureUnitComboList.SelectedItem).Tag.ToString();
				MessageBox.Show($"Ausgewählt: {selectedOption}");
				MeasureUnit = selectedOption;
			}
		}

		private void windspeedCheckBox_Click(object sender, RoutedEventArgs e)
		{
			if(windspeedCheckBox.IsChecked == true)
			{
				bool selectedOption = true;
				MessageBox.Show($"Ausgewählt: {selectedOption}");
				Windspeed = selectedOption;
			}
			else
			{
				bool selectedOption = false;
				MessageBox.Show($"Ausgewählt: {selectedOption}");
				Windspeed = selectedOption;
			}
		}
	}
}
