using System;
using System.Collections.Generic;
//using System.Drawing;
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

		//public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();
		public static string ApiLanguage { get; set; } = "de"; // Standardwert ist Deutsch
		public static string MeasureUnit { get; set; } = "M"; // Standardwert für metrische Einheiten
		public static bool Windspeed { get; set; } = true; // Standardwert für Windspeed


		//private int currentThemeIndex = 0;
		//private List<ResourceDictionary> themes = new List<ResourceDictionary>();

		public Settings()
		{
            InitializeComponent();

			#region themes
			//themes.Add(new ResourceDictionary() { Source = new Uri("Theme1.xaml", UriKind.Relative) });
			//themes.Add(new ResourceDictionary() { Source = new Uri("Theme2.xaml", UriKind.Relative) });
			//themes.Add(new ResourceDictionary() { Source = new Uri("Theme3.xaml", UriKind.Relative) });
			//themes.Add(new ResourceDictionary() { Source = new Uri("Theme4.xaml", UriKind.Relative) });

			//ApplyTheme(themes[currentThemeIndex]);
			#endregion
		}
		#region themes2
		//private void ToggleTheme_Click(object sender, RoutedEventArgs e)
		//{
		//	// Wechsele zwischen den Themes
		//	if ((Brush)this.Resources["BackgroundColor"] == Brushes.White)
		//	{
		//		this.Resources["BackgroundColor"] = new SolidColorBrush(Colors.Black);
		//		this.Resources["ForegroundColor"] = new SolidColorBrush(Colors.Red);
		//	}
		//	else
		//	{
		//		this.Resources["BackgroundColor"] = new SolidColorBrush(Colors.White);
		//		this.Resources["ForegroundColor"] = new SolidColorBrush(Colors.Blue);
		//	}
		//}

		//private void ApplyTheme(ResourceDictionary theme)
		//{
		//	// Entferne alle bisherigen Themes
		//	Application.Current.Resources.MergedDictionaries.Clear();

		//	// Füge das ausgewählte Theme hinzu
		//	Application.Current.Resources.MergedDictionaries.Add(theme);
		//}
		#endregion


		private void LoadContent()
		{
			
		}

		private void languageList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (languageListComboBox.SelectedItem != null)
			{
				string selectedOption = ((System.Windows.Controls.ComboBoxItem)languageListComboBox.SelectedItem).Tag.ToString();
				//MessageBox.Show($"Ausgewählt: {selectedOption}");
				ApiLanguage = selectedOption;
                
            }
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			SaveSetting();
			
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            Close();
        }

		private void SaveSetting()
		{
			try
			{
				string[] lines = new string[]
				{
					"lang=" + ApiLanguage,
					"units=" + MeasureUnit,
					"windspeed=" + Windspeed
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
