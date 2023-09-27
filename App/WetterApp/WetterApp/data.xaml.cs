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
        
    public string ApiLanguage { get; set; }
        public data(string cityName)
		{
			InitializeComponent();

			city = cityName;

            timeSlider.ValueChanged += TimeSlider_ValueChanged;

            GetInformation(city);

			WeatherAlert(city);





		}
        private const string apiKey = "79270c12757b499a9d0e1ecfad188c3a";
        private HttpClient client = new HttpClient();

		public string ConvertDateFormat(string inputDate)
		{
			try
			{
				DateTime date = DateTime.ParseExact(inputDate, "yyyy-MM-dd:06", CultureInfo.InvariantCulture);

				// Convert the DateTime object to the desired format
				string formattedDate = date.ToString("dd/MM");

				return formattedDate;
			}
			catch (FormatException)
			{
				// Handle the case where the input date is not in the expected format
				return "Invalid Date Format";
			}
		}

		private async void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            await UpdateSunriseSunsetTimes(e.NewValue);
        }

        private void timeSlider_Loaded(object sender, RoutedEventArgs e)
        {
            // Berechne die Position des weißen Punktes basierend auf der aktuellen Uhrzeit
            double currentValue = timeSlider.Value;
            double position = (currentValue / 24) * 300; // 300 ist die Breite des Sliders

            // Erstelle den weißen Punkt
            Ellipse whiteDot = new Ellipse();
            whiteDot.Width = 10;
            whiteDot.Height = 10;
            whiteDot.Fill = Brushes.White;

            // Setze die Position des weißen Punktes
            whiteDot.Margin = new Thickness(position, 0, 0, 0);

            // Füge den weißen Punkt zum Grid hinzu (das den Slider enthält)
            Grid grid = timeSlider.Template.FindName("PART_Track", timeSlider) as Grid;
            if (grid != null)
            {
                grid.Children.Add(whiteDot);
            }
        }
        private async Task UpdateSunriseSunsetTimes(double sliderValue)
        {
            try
            {

                string apiUrl = $"https://api.weatherbit.io/v2.0/forecast/daily?city={city}&key={apiKey}";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseBody);

                // Hole die Sonnenaufgangs- und Sonnenuntergangszeiten aus der API
                DateTime sunrise = json["data"][0]["sunrise"].ToObject<DateTime>();
                DateTime sunset = json["data"][0]["sunset"].ToObject<DateTime>();

                // Berechne die gewünschte Zeit basierend auf dem Slider-Wert
                DateTime selectedTime = sunrise.AddHours(sliderValue);

                // Aktualisiere die Anzeige
                sunriseText.Content = $"Sonnenaufgang: {sunrise.ToString("HH:mm tt")}";
                sunsetText.Content = $"Sonnenuntergang: {sunset.ToString("HH:mm tt")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Abrufen der Daten: " + ex.Message);
            }
        }
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
    //public class ValueToMarginConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (value is double sliderValue)
    //        {
    //            double position = (sliderValue / 24) * 300; // 300 ist die Breite des Sliders
    //            return new Thickness(position, 0, 0, 0);
    //        }
    //        return new Thickness(0);
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}
			
