﻿#pragma checksum "..\..\data.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8E3F8C9B4BD55A7E9DFCA9146248BDFE43BBE2B48340BB1D7171C197C6013530"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WetterApp;


namespace WetterApp {
    
    
    /// <summary>
    /// data
    /// </summary>
    public partial class data : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle weatherImage;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtErgebnis;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTemp;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtMinMax;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox weatherforecastList;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nameLabel;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Sunrise;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image sunIcon;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\data.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Sunset;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WetterApp;component/data.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\data.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.weatherImage = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 2:
            this.txtErgebnis = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txtTemp = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtMinMax = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.weatherforecastList = ((System.Windows.Controls.ListBox)(target));
            
            #line 55 "..\..\data.xaml"
            this.weatherforecastList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.weatherforecastList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.nameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\data.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.CloseButtonClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Sunrise = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.sunIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.Sunset = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

