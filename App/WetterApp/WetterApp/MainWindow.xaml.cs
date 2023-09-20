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
        private string selectedCity = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void temporärSearch(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            selectedCity = button.Tag.ToString();
            data window = new data(selectedCity);
            window.Show();
        }

        public void openAddWindow(object sender, RoutedEventArgs e)
        {
            InputDialog inputDialog = new InputDialog();
            inputDialog.ShowDialog();

            string name = inputDialog.UserInput;

            if (!string.IsNullOrEmpty(name))
            {
                Rectangle newRectangle = new Rectangle
                {
                    Width = 200,
                    Height = 280,
                    Fill = Brushes.LightBlue,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    
                };

                Label nameLabel = new Label
                {
                    Content = name,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top // Oben ausrichten
                };

                Grid grid = new Grid();
                grid.Children.Add(newRectangle);
                grid.Children.Add(nameLabel);

                StackPanel stackPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical
                };

                stackPanel.Children.Add(grid);

                rectangleList.Items.Add(stackPanel);



                // Fügen Sie das Click-Ereignis zum Rechteck hinzu
                try
                {

                    newRectangle.MouseDown += Rectangle_Click;

                    rectangleList.Items.Add(stackPanel);

                }
                catch (Exception ex)
                {
                   
                    
                }
               

            }

            

        }
        void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            Rectangle clickedRectangle = (Rectangle)sender;
            //Label nameLabel = ((Grid)clickedRectangle.Parent).Children[1] as Label;
            



            data window = new data(selectedCity);
                window.Show();


            
        }

    }
}

