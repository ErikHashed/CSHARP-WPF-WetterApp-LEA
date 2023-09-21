﻿using Newtonsoft.Json.Linq;
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
using Microsoft.Toolkit.Uwp.Notifications;


namespace WetterApp
{
	public class WeatherForecast
	{
		public string Temperature { get; set; }
		public string IconPath { get; set; }
	}

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
			string forecastUrl = $"https://api.weatherbit.io/v2.0/forecast/daily?city={city}&key={apiKey}";

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
						int temperatur = data.data[0].temp;
						string wettername = data.data[0].weather.name;
						string uhrzeit = data.data[0].ob_time;
						string latte = data.data[0].lat;       //insider Variable
						string longschlong = data.data[0].lon; //insider Variable
						double windgeschwindigkeit = data.data[0].wind_spd;
						string icon = data.data[0].weather.icon;

						
						ImageBrush imgBrush = new ImageBrush();

						imgBrush.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{icon}.png"));
						weatherImage.Fill = imgBrush;



                        List<WeatherForecast> forecasts = new List<WeatherForecast>();

                      
                        forecasts.Add(new WeatherForecast
                        {
                            Temperature = $"{data.data[0].min_temp} / {data.data[0].max_temp}",
                            IconPath = $"pack://application:,,,/images/{data.data[0].weather.icon}.png"
                        });


                       // weatherforecastList.ItemsSource = forecasts;



                        txtTemp.Text = temperatur + "°C";

                        //txtErgebnis.Text = $"Stadt: {city} \nBeschreibung: {beschreibung}\nTemperatur: {temperatur}°C \nWettername: {wettername} " +
                        //$"\nUhrzeit: {uhrzeit} Längengrad: {longschlong} Breitengrad: {latte} \n Windgeschwindigkeit: {windgeschwindigkeit} \n";
                    }
					else
					{
						//txtErgebnis.Text = "Fehler beim Abrufen der Stadt.";
					}

				}
				
				using (HttpClient client = new HttpClient())
				{
					HttpResponseMessage responseForecast = await client.GetAsync(forecastUrl);
					if (responseForecast.IsSuccessStatusCode)
					{
						string json = await responseForecast.Content.ReadAsStringAsync();
						dynamic data = JObject.Parse(json);

						List<WeatherForecast> forecasts = new List<WeatherForecast>();

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{data.data[0].min_temp} / {data.data[0].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[0].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{data.data[1].min_temp} / {data.data[1].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[1].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{data.data[2].min_temp} / {data.data[2].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[2].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{data.data[3].min_temp} / {data.data[3].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[3].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{data.data[4].min_temp} / {data.data[4].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[4].weather.icon}.png"
						});

						weatherforecastList.ItemsSource = forecasts;

						try
                        {
								ImageBrush img1 = new ImageBrush();
								ImageBrush img2 = new ImageBrush();
								ImageBrush img3 = new ImageBrush();
								ImageBrush img4 = new ImageBrush();
								ImageBrush img5 = new ImageBrush();

								img1.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[0].weather.icon}.png"));
								img2.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[1].weather.icon}.png"));
								img3.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[2].weather.icon}.png"));
								img4.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[3].weather.icon}.png"));
								img5.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[4].weather.icon}.png"));
								weatherIcon1.Fill = img1;
								weatherIcon2.Fill = img2;
								weatherIcon3.Fill = img3;
								weatherIcon4.Fill = img4;
								weatherIcon5.Fill = img5;
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
				}               
            }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private async Task servereWeatherWarning(string city)
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

		private void unwetterClickTemp(object sender, RoutedEventArgs e)
		{
			//new ToastContentBuilder()
			//.AddArgument("action", "viewConversation")
			//.AddArgument("conversationId", 9813)
			//.AddHeader("1","UNWETTER!", "awiodzuawzgdzg")
			//.AddText("Ich hab nen Steifen")
			//.AddText("Ich bin gail!")
			//.Show();
		}
	}

	
}
			
