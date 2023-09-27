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
using Microsoft.Toolkit.Uwp.Notifications;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using Windows.Media.Protection.PlayReady;
using System.Globalization;

namespace WetterApp
{

	public class WeatherForecast
	{

		public string Temperature { get; set; }
		public string IconPath { get; set; }
	}

	public partial class data : Window
	{
		string city = null;
        
        public data(string cityName)
		{
			InitializeComponent();

			city = cityName;

            GetInformation(city);

			WeatherAlert(city);

			LoadIcon();
		}
        private const string apiKey = "79270c12757b499a9d0e1ecfad188c3a";
        private HttpClient client = new HttpClient();
       
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
						Sunrise.Content = data.data[0].sunrise;
						Sunset.Content = data.data[0].sunset;
						
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

						DateTime dayOne = DateTime.Today;
						int day1 = dayOne.Day;
						int month1 = dayOne.Month;
						DateTime dayTwo = dayOne.AddDays(1);
						int day2 = dayTwo.Day;
						int month2 = dayTwo.Month;
						DateTime dayThree = dayOne.AddDays(2);
						int day3 = dayThree.Day;
						int month3 = dayThree.Month;
						DateTime dayFour = dayOne.AddDays(3);
						int day4 = dayFour.Day;
						int month4 = dayFour.Month;
						DateTime dayFive = dayOne.AddDays(4);
						int day5 = dayFive.Day;
						int month5 = dayFive.Month;
						DateTime daySix = dayOne.AddDays(5);
						int day6 = daySix.Day;
						int month6 = daySix.Month;
						DateTime daySeven = dayOne.AddDays(6);
						int day7 = daySeven.Day;
						int month7 = daySeven.Month;

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{day1}/{month1}   {data.data[0].min_temp} / {data.data[0].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[0].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{day2}/{month2}   {data.data[1].min_temp} / {data.data[1].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[1].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{day3}/{month3}   {data.data[2].min_temp} / {data.data[2].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[2].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{day4}/{month4}   {data.data[3].min_temp} / {data.data[3].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[3].weather.icon}.png"
						});

						forecasts.Add(new WeatherForecast
						{
							Temperature = $"{day5}/{month5}   {data.data[4].min_temp} / {data.data[4].max_temp}",
							IconPath = $"pack://application:,,,/images/{data.data[4].weather.icon}.png"
						});

                        forecasts.Add(new WeatherForecast
                        {
                            Temperature = $"{day6}/{month6}   {data.data[5].min_temp} / {data.data[5].max_temp}",
                            IconPath = $"pack://application:,,,/images/{data.data[5].weather.icon}.png"
                        });

                        forecasts.Add(new WeatherForecast
                        {
                            Temperature = $"{day7}/{month7}   {data.data[6].min_temp} / {data.data[6].max_temp}",
                            IconPath = $"pack://application:,,,/images/{data.data[6].weather.icon}.png"
                        });

                        
                        weatherforecastList.ItemsSource = forecasts;

						try
                        {
								ImageBrush img1 = new ImageBrush();
								ImageBrush img2 = new ImageBrush();
								ImageBrush img3 = new ImageBrush();
								ImageBrush img4 = new ImageBrush();
								ImageBrush img5 = new ImageBrush();
								ImageBrush img6 = new ImageBrush();
								ImageBrush img7 = new ImageBrush();

								img1.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[0].weather.icon}.png"));
								img2.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[1].weather.icon}.png"));
								img3.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[2].weather.icon}.png"));
								img4.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[3].weather.icon}.png"));
								img5.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[4].weather.icon}.png"));
								img6.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[5].weather.icon}.png"));
								img7.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[6].weather.icon}.png"));

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
			string weatherAlertApi = $"https://api.weatherbit.io/v2.0/alerts?city={city}&key={apiKey}&lang={Settings.ApiLanguage}&units={Settings.MeasureUnit}";
			try
			{
				using (HttpClient client = new HttpClient())
				{
					HttpResponseMessage response = await client.GetAsync(weatherAlertApi);

					if (response.IsSuccessStatusCode)
					{
						string json = await response.Content.ReadAsStringAsync();
						dynamic data = JObject.Parse(json);

						if (data.alerts != null)
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
			catch (Exception)
			{ }
		}

		void LoadIcon()
		{
			try
			{
				BitmapImage source;
				if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour <= 8)
				{
					source = new BitmapImage(new Uri("pack://application:,,,/images/sunrise.png"));
				}
				else if(DateTime.Now.Hour > 8 && DateTime.Now.Hour <= 18)
				{
					source = new BitmapImage(new Uri("pack://application:,,,/images/normalSun.png"));
				}
				else
				{
					source = new BitmapImage(new Uri("pack://application:,,,/images/sunset.png"));
				}
				sunIcon.Source = source;


				//DateTime time = DateTime.Now;
				//int currentHour = time.Hour;

				//if (currentHour >= 6 && currentHour <= 8)
				//{
				//	sunIcon.Source = sunrise;
				//}
				//else if (currentHour > 8 && currentHour <= 18)
				//{
				//	sunIcon.Source = normalSun;
				//}
				//else if (currentHour >= 19 && currentHour <= 24)
				//{
				//	sunIcon.Source = sunset;
				//}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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
			
