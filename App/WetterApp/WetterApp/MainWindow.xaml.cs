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
using System.IO;
using System.Windows.Input;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Linq;

namespace WetterApp
{
    public partial class MainWindow : Window
    {
        public static string name = null;

        public static string city = null;
        private const string apiKey = "79270c12757b499a9d0e1ecfad188c3a";
        private string citiesFilePath = $"../../files/cities.txt";


        private const int HOTKEY_ID = 9000;
        private const uint MOD_CONTROL = 0x0002; // Control-Taste


        public MainWindow()
        {
            InitializeComponent();

            LoadData();

            Loaded += (s, e) =>
            {
                IntPtr handle = new WindowInteropHelper(this).Handle;
                RegisterHotKey(handle, HOTKEY_ID, MOD_CONTROL, (uint)KeyInterop.VirtualKeyFromKey(Key.W));
            };

            Unloaded += (s, e) =>
            {
                IntPtr handle = new WindowInteropHelper(this).Handle;
                UnregisterHotKey(handle, HOTKEY_ID);
            };
        }


        private void HotKeyPressed()
        {
            Settings newWindow = new Settings();
            Close();
            newWindow.Show();



        }

        // Überschreiben von WndProc, um Nachrichten abzufangen
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr handle = new WindowInteropHelper(this).Handle;
            HwndSource source = HwndSource.FromHwnd(handle);
            source.AddHook(HwndHook);
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    int id = wParam.ToInt32();
                    if (id == HOTKEY_ID)
                    {
                        HotKeyPressed();
                    }
                    handled = true;
                    break;
            }
            return IntPtr.Zero;
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        public async void openAddWindow(object sender, RoutedEventArgs e)
        {
            InputDialog inputDialog = new InputDialog();
            inputDialog.ShowDialog();

            name = inputDialog.UserInput;
            string apiUrl = $"https://api.weatherbit.io/v2.0/current?city={name}&key={apiKey}&lang={Settings.ApiLanguage}&units={Settings.MeasureUnit}";
            string forecastUrl = $"https://api.weatherbit.io/v2.0/forecast/daily?city={name}&key={apiKey}&lang={Settings.ApiLanguage}&units={Settings.MeasureUnit}";

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
                                Margin = new Thickness(0, 0, 0, 20),
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
                                Margin = new Thickness(0,100,0,0),
                                Height = 222,
                                IsHitTestVisible = false
                                
                            };

                            Label description = new Label
                            {
                                Content = $"{data.data[0].weather.description} {forecastData.data[0].min_temp}° / {forecastData.data[0].max_temp}°",
                                Width = 150,
                                Margin = new Thickness(0,70,0,0),
                                Height = 172,
                                IsHitTestVisible = false
                            };

                            Button removeButton = new Button
                            {
                                Content = "Entfernen",
                                Width = 80,
                                Height = 50,
                                Tag = newRectangle.Name,
                                Background = Brushes.LightBlue,
                                Margin = new Thickness(0, 0, 0, 100),
                                BorderBrush = Brushes.Black,
                            };

                            removeButton.Click += removeButton_Click;

                            Grid grid = new Grid();
                            grid.Children.Add(newRectangle);
                            grid.Children.Add(nameLabel);
                            grid.Children.Add(weatherIcon);
                            grid.Children.Add(temperature);
                            grid.Children.Add(description);
                            grid.Children.Add(removeButton);

                            grid.ColumnDefinitions.Add(new ColumnDefinition());
                            grid.RowDefinitions.Add(new RowDefinition());

                            

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
            rectangleList.Items.Clear();
            try
            {
                if (File.Exists(Settings.SettingsFilePath))
                {
                    string[] settingsLines = File.ReadAllLines(Settings.SettingsFilePath);
                    string[] parts;

                    // Parse the lines and populate the AppSettings object

                    parts = settingsLines[0].Split('=');
                    if (parts.Length == 2)
                    {
                        Settings.ApiLanguage = parts[1];
                    }
                    parts = settingsLines[1].Split('=');
                    if (parts.Length == 2)
                    {
                        Settings.MeasureUnit = parts[1];
                    }
                    parts = settingsLines[2].Split('=');
                    if (parts.Length == 2)
                    {
                        Settings.Windspeed = bool.Parse(parts[1]);
                    }
                }
                else
                {
                    MessageBox.Show("Settingsdatei nicht gefunden!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading settings: {ex.Message}");
            }

            string[] lines = File.ReadAllLines(citiesFilePath);


            for (int i = 0; i < lines.Length; i++)
            {

                string url = $"https://api.weatherbit.io/v2.0/current?city={lines[i]}&key={apiKey}&lang={Settings.ApiLanguage}&units={Settings.MeasureUnit}";
                string forecastUrl = $"https://api.weatherbit.io/v2.0/forecast/daily?city={lines[i]}&key={apiKey}&lang={Settings.ApiLanguage}&units={Settings.MeasureUnit}";

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
                                Height = 340,
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
                                IsHitTestVisible = false,
                                HorizontalAlignment= HorizontalAlignment.Center,
                                VerticalAlignment= VerticalAlignment.Top,
                                Margin = new Thickness(0,34,0,0),
                                
                                
                            };

                            Label description = new Label
                            {
                                Content = $"{data.data[0].weather.description} {forecastData.data[0].min_temp}° / {forecastData.data[0].max_temp}°",
                                //Width = 100,
                                Height = 172,
                                IsHitTestVisible = false,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                
                            };

                            Button removeButton = new Button
                            {
                                Content = "Entfernen",
                                Width = 70,
                                Height = 40,
                                Tag = newRectangle.Name,
                                Background = Brushes.LightBlue,
                                Margin = new Thickness(0,186,0,20),
                                BorderBrush = Brushes.Black,
                                VerticalAlignment= VerticalAlignment.Bottom,
                            };

                            removeButton.Click += removeButton_Click;

                            Grid grid = new Grid();
                            grid.Children.Add(newRectangle);
                            grid.Children.Add(nameLabel);
                            grid.Children.Add(weatherIcon);
                            grid.Children.Add(temperature);
                            grid.Children.Add(description);
                            grid.Children.Add(removeButton);

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
            settingsWindow.Show();
            Close();
        }
	    
        void removeButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            List<string> lines = File.ReadAllLines(citiesFilePath).ToList();

			int indexToRemove = -1;


			for (int i = 0; i < lines.Count; i++)
            {
                if(lines[i].Contains((string)btn.Tag))
                {
					indexToRemove = i;
					break;
				}

            }

			if (indexToRemove >= 0)
			{
				lines.RemoveAt(indexToRemove);

				// Write the updated lines back to the file
				File.WriteAllLines(citiesFilePath, lines);
				MessageBox.Show("Line containing the target string removed successfully.");
			}
            LoadData();
		}

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}