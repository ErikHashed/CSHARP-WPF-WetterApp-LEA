using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

public class Viewmodel : INotifyPropertyChanged
{
    private string _apiString;
    private Dictionary<string, string> _imagePaths;
    private ImageSource _selectedImage;

    public Viewmodel()
    {
        _imagePaths = new Dictionary<string, string>
        {
            { "a01d", "../../icons/a01d.png" },
            { "a01n", "../../icons/a01d.png" },
            { "a02d", "../../icons/a01d.png" },
            { "a02n", "../../icons/a01d.png" },
            { "a03d", "../../icons/a01d.png" },
            { "a03n", "../../icons/a01d.png" },
            { "a04d", "../../icons/a01d.png" },
            { "a04n", "../../icons/a01d.png" },
            { "a05d", "../../icons/a01d.png" },
            { "a05n", "../../icons/a01d.png" },
            { "a06d", "../../icons/a01d.png" },
            { "a06n", "../../icons/a01d.png" },

            { "c01d", "../../icons/a01d.png" },
            { "c01n", "../../icons/a01d.png" },
            { "c02d", "../../icons/a01d.png" },
            { "c02n", "../../icons/a01d.png" },
            { "c03d", "../../icons/a01d.png" },
            { "c03n", "../../icons/a01d.png" },
            { "c04d", "../../icons/a01d.png" },
            { "c04n", "../../icons/a01d.png" },

            { "d01d", "../../icons/a01d.png" },
            { "d01n", "../../icons/a01d.png" },
            { "d02d", "../../icons/a01d.png" },
            { "d02n", "../../icons/a01d.png" },
            { "d03d", "../../icons/a01d.png" },
            { "d03n", "../../icons/a01d.png" },

            { "f01d", "../../icons/a01d.png" },
            { "f01n", "../../icons/a01d.png" },

            { "r01d", "../../icons/a01d.png" },
            { "r01n", "../../icons/a01d.png" },
            { "r02d", "../../icons/a01d.png" },
            { "r02n", "../../icons/a01d.png" },
            { "r03d", "../../icons/a01d.png" },
            { "r03n", "../../icons/a01d.png" },
            { "r04d", "../../icons/a01d.png" },
            { "r04n", "../../icons/a01d.png" },
            { "r05d", "../../icons/a01d.png" },
            { "r05n", "../../icons/a01d.png" },
            { "r06d", "../../icons/a01d.png" },
            { "r06n", "../../icons/a01d.png" },

            { "s01d", "../../icons/a01d.png" },
            { "s01n", "../../icons/a01d.png" },
            { "s02d", "../../icons/a01d.png" },
            { "s02n", "../../icons/a01d.png" },
            { "s03d", "../../icons/a01d.png" },
            { "s03n", "../../icons/a01d.png" },
            { "s04d", "../../icons/a01d.png" },
            { "s04n", "../../icons/a01d.png" },
            { "s05d", "../../icons/a01d.png" },
            { "s05n", "../../icons/a01d.png" },
            { "s06d", "../../icons/a01d.png" },
            { "s06n", "../../icons/a01d.png" },

            { "t01d", "../../icons/a01d.png" },
            { "t01n", "../../icons/a01d.png" },
            { "t02d", "../../icons/a01d.png" },
            { "t02n", "../../icons/a01d.png" },
            { "t03d", "../../icons/a01d.png" },
            { "t03n", "../../icons/a01d.png" },
            { "t04d", "../../icons/a01d.png" },
            { "t04n", "../../icons/a01d.png" },
            { "t05d", "../../icons/a01d.png" },
            { "t05n", "../../icons/a01d.png" },

            { "u00d", "../../icons/a01d.png" },
            { "u00n", "../../icons/a01d.png" },
            

            // Fügen Sie hier weitere Bildpfade hinzu
        };
    }

    public string ApiString
    {
        get { return _apiString; }
        set
        {
            if (_apiString != value)
            {
                _apiString = value;
                LoadImage();
                OnPropertyChanged();
            }
        }
    }

    public ImageSource SelectedImage
    {
        get { return _selectedImage; }
        set
        {
            if (_selectedImage != value)
            {
                _selectedImage = value;
                OnPropertyChanged();
            }
        }
    }

    private void LoadImage()
    {
        if (_imagePaths.ContainsKey(_apiString))
        {
            string imagePath = _imagePaths[_apiString];
            SelectedImage = new System.Windows.Media.Imaging.BitmapImage(new Uri(imagePath));
        }
        else
        {
            // Fallback, wenn kein passender Bildpfad gefunden wurde
            SelectedImage = null;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
