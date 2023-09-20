﻿using System;
using System.Collections.Generic;
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

namespace WetterApp
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class InputDialog : Window
    {
        public string UserInput { get; private set; }

        public InputDialog()
        {
            InitializeComponent();
        }

        private void okClick(object sender, RoutedEventArgs e)
        {
            UserInput = inputTextBox.Text;
            this.Close();
        }

        
    }
}
