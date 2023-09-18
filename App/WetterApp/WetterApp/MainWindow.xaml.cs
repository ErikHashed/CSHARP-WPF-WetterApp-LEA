using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace WetterApp
{
    public partial class MainWindow : Window
    {
        private const string apiKey = "79270c12757b499a9d0e1ecfad188c3a";

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Suchen_Click(object sender, RoutedEventArgs e)
        {
            
            string stadt = txtStadt.Text;
            string apiUrl = $"https://api.weatherbit.io/v2.0/current?city={stadt}&key={apiKey}&lang=de";

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

                        txtErgebnis.Text = $"Beschreibung: {beschreibung}\nTemperatur: {temperatur}°C";
                    }
                    else
                    {
                        txtErgebnis.Text = "Fehler beim Abrufen der Daten.";
                    }
                }
            }
            catch (Exception ex)
            {
                txtErgebnis.Text = "Fehler beim Abrufen der Daten.";
                Console.WriteLine(ex.Message);
            }
        }
    }
}
