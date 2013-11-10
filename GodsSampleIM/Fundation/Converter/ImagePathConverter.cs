using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Gods.Fundation
{
    [ValueConversion(typeof(string), typeof(ImageSource))]
    public class ImagePathConverter : IValueConverter
    {
        private string _imageDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public string ImageDirectory
        {
            get { return _imageDirectory; }
            set { _imageDirectory = value; }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string imageFileName = value as string;
            if (!string.IsNullOrEmpty(ImageDirectory) && !string.IsNullOrEmpty(imageFileName))
            {
                string imagePath = Path.Combine(ImageDirectory, (string)value);
                if (File.Exists(imagePath))
                {
                    return new BitmapImage(new Uri(imagePath));
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
