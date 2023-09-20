using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WetterApp
{
	/// <summary>
	/// Interaction logic for data.xaml
	/// </summary>
	public partial class data : Window
	{
		public data(string city)
		{
			InitializeComponent();

			GetInformation(city);
		}

		private const string apiKey = "79270c12757b499a9d0e1ecfad188c3a";

		private async void GetInformation(string city)
		{

			string apiUrl = $"https://api.weatherbit.io/v2.0/current?city={city}&key={apiKey}&lang=de";


			try
			{
				using (HttpClient client = new HttpClient())
				{
					HttpResponseMessage response = await client.GetAsync(apiUrl);

					if (response.IsSuccessStatusCode)
					{
						string json = await response.Content.ReadAsStringAsync();
						dynamic data = JObject.Parse(json);

						string beschreibung = data.data[0].weather.description;
						double temperatur = data.data[0].temp;
						string wettername = data.data[0].weather.name;
						string uhrzeit = data.data[0].ob_time;
						string latte = data.data[0].lat;       //insider Variable
						string longschlong = data.data[0].lon; //insider Variable
						double windgeschwindigkeit = data.data[0].wind_spd;
						string icon = data.data[0].weather.icon;





						//Viewmodel viewmodel = new Viewmodel();
						//viewmodel.ApiString = $"{icon}";
						//DataContext = viewmodel;
						try
						{


							ImageBrush sexxen = new ImageBrush();

							sexxen.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{icon}.png"));
							weatherImage.Fill = sexxen;
						}
						catch (Exception ex)
						{

							MessageBox.Show(ex.Message);
						}


						//MessageBox.Show(icon);
						//Icons(icon);



						txtErgebnis.Text = $"Stadt: {city} \nBeschreibung: {beschreibung}\nTemperatur: {temperatur}°C \nWettername: {wettername} " +
							$"\nUhrzeit: {uhrzeit} Längengrad: {longschlong} Breitengrad: {latte} \n Windgeschwindigkeit: {windgeschwindigkeit} \n";
					}
					else
					{
						txtErgebnis.Text = "Fehler beim Abrufen der Stadt.";
					}

				}
			}
			catch (Exception ex)
			{
				txtErgebnis.Text = "Fehler beim Abrufen der Daten.";
				Console.WriteLine(ex.Message);
			}


		}

		private async Task Unwetter(string city)
		{

			string url = $"https://api.weatherbit.io/v2.0/alerts?city={city}&key={apiKey}";

			try
			{
				using (HttpClient client = new HttpClient())
				{
					HttpResponseMessage response = await client.GetAsync(url);

					if (response.IsSuccessStatusCode)
					{
						string jsonn = await response.Content.ReadAsStringAsync();
						dynamic data = JObject.Parse(jsonn);


						if (data?.dataa != null && data.Count > 0)
						{
							string unweatherName = data[0].title;
							//unweatherTextBox.Text = unweatherName;
							MessageBox.Show("Wir haben DAAAATEEEEEN");
						}



						//string unweatherName = data.data[0].title;
						//unweatherTextBox.Text = unweatherName;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}



		}
				}
			}
			
