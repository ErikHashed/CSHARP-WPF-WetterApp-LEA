using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetterApp
{
    public class AppSettings : INotifyPropertyChanged
    {
        private string _apiLanguage = "de";
        private string _measureUnit = "metric";
        private bool _windspeed = true;

        public string ApiLanguage
        {
            get { return _apiLanguage; }
            set
            {
                if (_apiLanguage != value)
                {
                    _apiLanguage = value;
                    OnPropertyChanged(nameof(ApiLanguage));
                }
            }
        }

        public string MeasureUnit
        {
            get { return _measureUnit; }
            set
            {
                if (_measureUnit != value)
                {
                    _measureUnit = value;
                    OnPropertyChanged(nameof(MeasureUnit));
                }
            }
        }

        public bool Windspeed
        {
            get { return _windspeed; }
            set
            {
                if (_windspeed != value)
                {
                    _windspeed = value;
                    OnPropertyChanged(nameof(Windspeed));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
