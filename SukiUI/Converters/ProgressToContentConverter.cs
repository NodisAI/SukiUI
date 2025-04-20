using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using SukiUI.Controls;

namespace SukiUI.Converters
{
    public class ProgressToContentConverter : IValueConverter
    {
        public static ProgressToContentConverter Instance { get; } = new();

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is true) return new Loading { LoadingStyle = LoadingStyle.Simple };

            return new Panel();
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}