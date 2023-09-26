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

		public static string ApiLanguage { get; set; }
		public static string MeasureUnit { get; set; }

		public Settings()
		{
            InitializeComponent();

			LoadContent();

			Translation();
		}

		void LoadContent()
		{
			try
			{
				if (ApiLanguage == "de")
				{
					languageListComboBox.SelectedIndex = 0;
				}
				if (ApiLanguage == "en")
				{
					languageListComboBox.SelectedIndex = 1;

				}
				if (ApiLanguage == "fr")
				{
					languageListComboBox.SelectedIndex = 2;

				}
				if (ApiLanguage == "es")
				{
					languageListComboBox.SelectedIndex = 3;

				}
				if (MeasureUnit == "M")
				{
					temperatureUnitComboList.SelectedIndex = 0;
				}
				if (MeasureUnit == "I")
				{
					temperatureUnitComboList.SelectedIndex = 1;
				}
				if (MeasureUnit == "S")
				{
					temperatureUnitComboList.SelectedIndex = 2;
				}
			} catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
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
        }

		private void SaveSetting()
		{
			try
			{
				string[] lines = new string[]
				{
					"lang=" + ApiLanguage,
					"units=" + MeasureUnit,
				};

				File.WriteAllLines(settingsFilePath, lines);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error saving settings: {ex.Message}");
			}


			Settings newWindow = new Settings();
			newWindow.Show();
			Close();

		}

		private void temperatureUnitList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (temperatureUnitComboList.SelectedItem != null)
			{
				string selectedOption = ((System.Windows.Controls.ComboBoxItem)temperatureUnitComboList.SelectedItem).Tag.ToString();
				//MessageBox.Show($"Ausgewählt: {selectedOption}");
				MeasureUnit = selectedOption;
                
            }
		}

		

		private void CloseButtonClick(object sender, RoutedEventArgs e)
		{
			MainWindow newWindow = new MainWindow();
			newWindow.Show();
			Close();
		}

		void Translation()
		{
			if (ApiLanguage == "de")
			{
				languageLabel.Content = "Sprachen";
				measureUnitLabel.Content = "Messeinheiten";
			}
			if (ApiLanguage == "en")
			{
				languageLabel.Content = "Language";
				measureUnitLabel.Content = "Measuring Units";
			}
			if (ApiLanguage == "fr")
			{
				languageLabel.Content = "Langues";
				measureUnitLabel.Content = "unités de mesure";
			}
			if (ApiLanguage == "es")
			{
				languageLabel.Content = "Idiomas";
				measureUnitLabel.Content = "Unidades de medida";
			}


		}

	}
}
