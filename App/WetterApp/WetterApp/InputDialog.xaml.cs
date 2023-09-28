using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Net.Http;




namespace WetterApp
{
    public partial class InputDialog : Window
    {
        public string UserInput { get; set; }
        private string citiesFilePath = $"../../files/cities.txt";


        public InputDialog()
        {

            InitializeComponent();
        }







        private void okClick(object sender, RoutedEventArgs e)
        {

            UserInput = inputTextBox.Text;

            File.AppendAllText(citiesFilePath, UserInput + "\n");



            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            Close();

        }



        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            Close();
        }
    }
}
