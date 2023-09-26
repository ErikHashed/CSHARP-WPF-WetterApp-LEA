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
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Threading;


namespace WetterApp
{

	public class WeatherForecast
	{

		public string Temperature { get; set; }
		public string IconPath { get; set; }
	}

	public partial class data : Window
	{
       
        
    public string ApiLanguage { get; set; }
        public data(string city)
		{
			InitializeComponent();
           
        

        GetInformation(city);

			WeatherAlert(city);
		}
        private const string apiKey = "79270c12757b499a9d0e1ecfad188c3a";


		private async void GetInformation(string city)
		{

			string apiUrl = $"https://api.weatherbit.io/v2.0/current?city={city}&key={apiKey}&lang={Settings.ApiLanguage}&{Settings.MeasureUnit}";
			string forecastUrl = $"https://api.weatherbit.io/v2.0/forecast/daily?city={city}&key={apiKey}&lang={Settings.ApiLanguage}&{Settings.MeasureUnit}";

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
						string icon = data.data[0].weather.icon;
						nameLabel.Content = city;
						
						ImageBrush imgBrush = new ImageBrush();

						imgBrush.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{icon}.png"));
						weatherImage.Fill = imgBrush;

                        List<WeatherForecast> forecasts = new List<WeatherForecast>();

                        forecasts.Add(new WeatherForecast
                        {
                            Temperature = $"{data.data[0].min_temp} / {data.data[0].max_temp}",
                            IconPath = $"pack://application:,,,/images/{data.data[0].weather.icon}.png"
                        });

                        txtTemp.Text = temperatur + "°C";
						
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
							Temperature = $"{data.data[0].datetime}   {data.data[0].min_temp} / {data.data[0].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[0].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{data.data[1].datetime}   {data.data[1].min_temp} / {data.data[1].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[1].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{data.data[2].datetime}   {data.data[2].min_temp} / {data.data[2].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[2].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{data.data[3].datetime}   {data.data[3].min_temp} / {data.data[3].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[3].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{data.data[4].datetime}   {data.data[4].min_temp} / {data.data[4].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[4].weather.icon}.png"
						});

                        forecasts.Add(new WeatherForecast
                        {
                            Temperature = $"{data.data[5].datetime}   {data.data[5].min_temp} / {data.data[5].max_temp}",
                            IconPath = $"pack://application:,,,/images/{data.data[5].weather.icon}.png"
                        });

                        forecasts.Add(new WeatherForecast
                        {
                            Temperature = $"{data.data[6].datetime}   {data.data[6].min_temp} / {data.data[6].max_temp}",
                            IconPath = $"pack://application:,,,/images/{data.data[6].weather.icon}.png"
                        });

                        forecasts.Add(new WeatherForecast
                        {
                            Temperature = $"{data.data[7].datetime}   {data.data[7].min_temp} / {data.data[7].max_temp}",
                            IconPath = $"pack://application:,,,/images/{data.data[7].weather.icon}.png"
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

		async void WeatherAlert(string city)
		{
			string weatherAlertApi = $"https://api.weatherbit.io/v2.0/alerts?city={city}&key={apiKey}";
			try
			{
				using (HttpClient client = new HttpClient())
				{
					HttpResponseMessage response = await client.GetAsync(weatherAlertApi);

					if (response.IsSuccessStatusCode)
					{
						string json = await response.Content.ReadAsStringAsync();
						dynamic data = JObject.Parse(json);

						if(data.alerts != null)
						{
							string alerts = data.alerts[0].description;
							new ToastContentBuilder()
							.AddArgument("action", "viewConversation")
							.AddArgument("conversationId", 9813)
							.AddHeader("1", "UNWETTER!", "")
							.AddText(alerts)
							.Show();
						}
						
					}
				}
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message);
			}
		}

		

		private void CloseButtonClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void weatherforecastList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}

	
}
			
