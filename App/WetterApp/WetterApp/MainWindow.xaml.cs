using System;
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


namespace WetterApp
{
    public partial class MainWindow : Window
    {
        private static string selectedCity = null;
        public static string name = null;

        public static string city = null;
		private const string apiKey = "79270c12757b499a9d0e1ecfad188c3a";
        private string apiUrl;

        public MainWindow()
        {
            InitializeComponent();
        }

        public async void openAddWindow(object sender, RoutedEventArgs e)
        {
            InputDialog inputDialog = new InputDialog();
            inputDialog.ShowDialog();

            name = inputDialog.UserInput;
            apiUrl = $"https://api.weatherbit.io/v2.0/current?city={name}&key={apiKey}&lang=de";

			try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);


                    if (response.IsSuccessStatusCode)
                    {
                        if (!string.IsNullOrEmpty(name))
                        {
                            Rectangle newRectangle = new Rectangle
                            {
                                Width = 200,
                                Height = 280,
                                Fill = Brushes.LightBlue,
                                HorizontalAlignment = HorizontalAlignment.Right,
                                Name = name,
                            };


                            string json = await response.Content.ReadAsStringAsync();
                            dynamic data = JObject.Parse(json);

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
                                IsHitTestVisible = false,
							};

                            Label temperature = new Label
                            {
                                Content = $"{data.data[0].temp}",
                                FontSize = 22,
                                Width = 120,
                                IsHitTestVisible = false,
							};

                            Grid grid = new Grid();
                            grid.Children.Add(newRectangle);
                            grid.Children.Add(nameLabel);
                            grid.Children.Add(weatherIcon);
                            grid.Children.Add(temperature);

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

	}
}