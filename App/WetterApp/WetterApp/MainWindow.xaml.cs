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


namespace WetterApp
{
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

		private void temporärSearch(object sender, RoutedEventArgs e)
		{
            data window = new data("Paderborn");
            window.Show();
		}
	}
}

