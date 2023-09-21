﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using System.Data;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Markup;
using System.Device.Location;
using Microsoft.Toolkit.Uwp.Notifications;
using System.IO;

namespace WetterApp
{
    public partial class MainWindow : Window
    {
        private static string selectedCity = null;
        public static string name = null;

        public static string city = null;
		private const string apiKey = "79270c12757b499a9d0e1ecfad188c3a";
        private string citiesFilePath = $"../../files/cities.txt";



        public MainWindow()
        {
            InitializeComponent();
            
            LoadData();
        }

        public async void openAddWindow(object sender, RoutedEventArgs e)
        {
            InputDialog inputDialog = new InputDialog();
            inputDialog.ShowDialog();

            name = inputDialog.UserInput;
            string apiUrl = $"https://api.weatherbit.io/v2.0/current?city={name}&key={apiKey}&lang={Properties.Settings.Default.language}";
            string forecastUrl = $"https://api.weatherbit.io/v2.0/forecast/daily?city={name}&key={apiKey}&lang={Properties.Settings.Default.language}";

			try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    HttpResponseMessage responseForecast = await client.GetAsync(forecastUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        if (!string.IsNullOrEmpty(name))
                        {
							string json = await response.Content.ReadAsStringAsync();
                            string forecastJson = await responseForecast.Content.ReadAsStringAsync();
							dynamic data = JObject.Parse(json);
                            dynamic forecastData = JObject.Parse(forecastJson);

							Rectangle newRectangle = new Rectangle
                            {
                                Width = 200,
                                Height = 280,
                                Fill = Brushes.LightBlue,
                                HorizontalAlignment = HorizontalAlignment.Right,
                                Name = name,
                            };

                            Image weatherIcon = new Image
                            {
                                Source = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[0].weather.icon}.png")),
                                Width = 120,
                                Height = 120,
                            };

                            Label nameLabel = new Label
                            {
                                Content = name,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Top, // Oben ausrichten
                                FontSize = 20,
                                IsHitTestVisible = false
                            };

                            Label temperature = new Label
                            {
                                Content = $"{data.data[0].temp}°",
                                FontSize = 24,
                                Width = 65,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Height = 232,
                                IsHitTestVisible = false
                            };

                            Label description = new Label
                            {
                                Content = $"{data.data[0].weather.description} {forecastData.data[0].min_temp}° / {forecastData.data[0].max_temp}°",
                                Width = 150,
                                
                                Height = 172,
                                IsHitTestVisible=false
                            };

                            Grid grid = new Grid();
                            grid.Children.Add(newRectangle);
                            grid.Children.Add(nameLabel);
                            grid.Children.Add(weatherIcon);
                            grid.Children.Add(temperature);
                            grid.Children.Add(description);

                            StackPanel stackPanel = new StackPanel
                            {
                                Orientation = Orientation.Vertical
                            };

                            stackPanel.Children.Add(grid);

                            rectangleList.Items.Add(stackPanel);

                            // Fügen Sie das Click-Ereignis zum Rechteck hinzu

                            newRectangle.MouseDown += Rectangle_Click;
                            rectangleList.Items.Add(stackPanel);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
		}


		void Rectangle_Click(object sender, RoutedEventArgs e)
		{
			Rectangle clickedRectangle = (Rectangle)sender;
			//Label nameLabel = ((Grid)clickedRectangle.Parent).Children[1] as Label;

			data window = new data(clickedRectangle.Name);
			window.Show();

		}

        async void LoadData()
        {
            string[] lines = File.ReadAllLines(citiesFilePath);


            for (int i = 0; i < lines.Length; i++)
            {

                string url = $"https://api.weatherbit.io/v2.0/current?city={lines[i]}&key={apiKey}&lang={Properties.Settings.Default.language}";
                string forecastUrl = $"https://api.weatherbit.io/v2.0/forecast/daily?city={lines[i]}&key={apiKey}&lang={Properties.Settings.Default.language}";

                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        HttpResponseMessage forecastResponse = await client.GetAsync(forecastUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            string forecastJson = await forecastResponse.Content.ReadAsStringAsync();
                            dynamic data = JObject.Parse(json);
                            dynamic forecastData = JObject.Parse(forecastJson);

                            Rectangle newRectangle = new Rectangle
                            {
                                Width = 200,
                                Height = 280,
                                Fill = Brushes.LightBlue,
                                HorizontalAlignment = HorizontalAlignment.Right,
                                Name = lines[i],
                            };

                            Image weatherIcon = new Image
                            {
                                Source = new BitmapImage(new Uri($"pack://application:,,,/images/{data.data[0].weather.icon}.png")),
                                Width = 120,
                                Height = 120,
                            };

                            Label nameLabel = new Label
                            {
                                Content = lines[i],
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Top, // Oben ausrichten
                                FontSize = 20,
                                IsHitTestVisible = false
                            };

                            Label temperature = new Label
                            {
                                Content = $"{data.data[0].temp}°",
                                FontSize = 24,
                                Width = 70,
                                Height = 222,
                                IsHitTestVisible = false
                            };

                            Label description = new Label
                            {
                                Content = $"{data.data[0].weather.description} {forecastData.data[0].min_temp}° / {forecastData.data[0].max_temp}°",
                                //Width = 100,
                                Height = 172,
                                IsHitTestVisible = false
                            };

                            Grid grid = new Grid();
                            grid.Children.Add(newRectangle);
                            grid.Children.Add(nameLabel);
                            grid.Children.Add(weatherIcon);
                            grid.Children.Add(temperature);
                            grid.Children.Add(description);

                            StackPanel stackPanel = new StackPanel
                            {
                                Orientation = Orientation.Vertical
                            };

                            stackPanel.Children.Add(grid);

                            // Add the stackPanel to your UI container once
                            rectangleList.Items.Add(stackPanel);

                            // Attach the event handler to the newRectangle
                            newRectangle.MouseDown += Rectangle_Click;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

		private void settingsButton_Click(object sender, RoutedEventArgs e)
		{
            Settings settingsWindow = new Settings();
            settingsWindow.ShowDialog();
		}
	}
}