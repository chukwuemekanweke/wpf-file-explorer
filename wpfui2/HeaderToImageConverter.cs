
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using wpfui2.IODirectory;
using wpfui2.IODirectory.Data;

namespace wpfui2
{
    /// <summary>
    /// COnverts a full oath to a specific image of a drive, folder or file 
    /// </summary>
    /// 

        [ValueConversion(typeof(DirectoryItemType),typeof(BitmapImage))]
    public  class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DirectoryItemType directoryItemType = (DirectoryItemType)value;
            string image = "";
            switch (directoryItemType)
            {
                case DirectoryItemType.Drive:
                    image = "drive.png";
                    break;
                case DirectoryItemType.File:
                     image = "file.png";

                    break;
                case DirectoryItemType.Folder:
                    image = "closed-folder-1.png";

                    break;
                default:
                    break;
            }
                       
            Uri uri = new Uri($"pack://application:,,,/Images/{image}");
            return new BitmapImage(uri);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
