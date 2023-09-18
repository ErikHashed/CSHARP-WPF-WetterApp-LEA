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

namespace WetterApp
{
    public partial class MainWindow : Window

    {
       
        private const string apiKey = "79270c12757b499a9d0e1ecfad188c3a";
        private Timer timer;

        public MainWindow()
        {
            InitializeComponent();
            IrgendeineMethode();
            
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
                            Bild.Fill = sexxen;
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }


                        //MessageBox.Show(icon);
                        //Icons(icon);



                        txtErgebnis.Text = $"Stadt: {stadt} \nBeschreibung: {beschreibung}\nTemperatur: {temperatur}°C \nWettername: {wettername} " +
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

        public async void IrgendeineMethode()
        {
            UnwetterWarnung manager = new UnwetterWarnung();
            List<UnwetterWarnung> warnungen = await manager.GetUnwetterWarnungen();
            // Jetzt hast du die Unwetterwarnungen und kannst damit weiterarbeiten
        }

        public void TimerBeispiel()
        {
            // Initialisiere den Timer. Der TimerCallback ist die Methode, die aufgerufen wird.
            timer = new Timer(TimerCallback, null, 0, 5000); // 5000 Millisekunden = 5 Sekunden
        }

        private void TimerCallback(object o)
        {
            // Diese Methode wird alle 5 Sekunden aufgerufen
            Console.WriteLine("Timer ausgelöst!");

            // Hier kannst du deine eigene Methode aufrufen
            IrgendeineMethode();
        }


        //public void Icons(string icon)
        //{
        //   Dictionary<string,string> imagePaths = new Dictionary<string, string>
        //{
        //    { "a01d", "../../icons/a01d.png" },
        //    { "a01n", "../../icons/a01n.png" },
        //    { "a02d", "../../icons/a02d.png" },
        //    { "a02n", "../../icons/a01d.png" },
        //    { "a03d", "../../icons/a01d.png" },
        //    { "a03n", "../../icons/a01d.png" },
        //    { "a04d", "../../icons/a01d.png" },
        //    { "a04n", "../../icons/a01d.png" },
        //    { "a05d", "../../icons/a01d.png" },
        //    { "a05n", "../../icons/a01d.png" },
        //    { "a06d", "../../icons/a01d.png" },
        //    { "a06n", "../../icons/a01d.png" },

        //    { "c01d", "../../icons/a01d.png" },
        //    { "c01n", "../../icons/a01d.png" },
        //    { "c02d", "../../icons/a01d.png" },
        //    { "c02n", "../../icons/a01d.png" },
        //    { "c03d", "../../icons/a01d.png" },
        //    { "c03n", "../../icons/a01d.png" },
        //    { "c04d", "../../icons/a01d.png" },
        //    { "c04n", "../../icons/a01d.png" },

        //    { "d01d", "../../icons/a01d.png" },
        //    { "d01n", "../../icons/a01d.png" },
        //    { "d02d", "../../icons/a01d.png" },
        //    { "d02n", "../../icons/a01d.png" },
        //    { "d03d", "../../icons/a01d.png" },
        //    { "d03n", "../../icons/a01d.png" },

        //    { "f01d", "../../icons/a01d.png" },
        //    { "f01n", "../../icons/a01d.png" },

        //    { "r01d", "../../icons/a01d.png" },
        //    { "r01n", "../../icons/a01d.png" },
        //    { "r02d", "../../icons/a01d.png" },
        //    { "r02n", "../../icons/a01d.png" },
        //    { "r03d", "../../icons/a01d.png" },
        //    { "r03n", "../../icons/a01d.png" },
        //    { "r04d", "../../icons/a01d.png" },
        //    { "r04n", "../../icons/a01d.png" },
        //    { "r05d", "../../icons/a01d.png" },
        //    { "r05n", "../../icons/a01d.png" },
        //    { "r06d", "../../icons/a01d.png" },
        //    { "r06n", "../../icons/a01d.png" },

        //    { "s01d", "../../icons/a01d.png" },
        //    { "s01n", "../../icons/a01d.png" },
        //    { "s02d", "../../icons/a01d.png" },
        //    { "s02n", "../../icons/a01d.png" },
        //    { "s03d", "../../icons/a01d.png" },
        //    { "s03n", "../../icons/a01d.png" },
        //    { "s04d", "../../icons/a01d.png" },
        //    { "s04n", "../../icons/a01d.png" },
        //    { "s05d", "../../icons/a01d.png" },
        //    { "s05n", "../../icons/a01d.png" },
        //    { "s06d", "../../icons/a01d.png" },
        //    { "s06n", "../../icons/a01d.png" },

        //    { "t01d", "../../icons/a01d.png" },
        //    { "t01n", "../../icons/a01d.png" },
        //    { "t02d", "../../icons/a01d.png" },
        //    { "t02n", "../../icons/a01d.png" },
        //    { "t03d", "../../icons/a01d.png" },
        //    { "t03n", "../../icons/a01d.png" },
        //    { "t04d", "../../icons/a01d.png" },
        //    { "t04n", "../../icons/a01d.png" },
        //    { "t05d", "../../icons/a01d.png" },
        //    { "t05n", "../../icons/a01d.png" },

        //    { "u00d", "../../icons/a01d.png" },
        //    { "u00n", "../../icons/a01d.png" },


        //    // Fügen Sie hier weitere Bildpfade hinzu
        //};
        //    string imagepath = $"../../icons/{icon}.png";

        //    //if (imagePaths.ContainsKey(icon))
        //    //{
        //    //    string ausgabe = imagePaths[icon];   
        //    //    Bild.Source = new BitmapImage(new Uri(ausgabe, UriKind.Relative));
        //    //}
        //    //else
        //    //{
        //    //    // Fallback, wenn kein passender Bildpfad gefunden wurde
        //    //    Bild = null;
        //    //}

        //}



    }
}

