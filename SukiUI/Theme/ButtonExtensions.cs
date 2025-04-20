using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;

namespace SukiUI.Theme
{
    public static class ButtonExtensions
    {
        public static readonly AttachedProperty<bool> ShowProgressProperty =
            AvaloniaProperty.RegisterAttached<Button, bool>("ShowProgress", typeof(Button), defaultValue: false);

        public static bool GetShowProgress(Button textBox)
        {
            return textBox.GetValue(ShowProgressProperty);
        }

        public static void SetShowProgress(Button textBox, bool value)
        {
            textBox.SetValue(ShowProgressProperty, value);
        }

        public static void ShowProgress(this Button textBox)
        {
            textBox.SetValue(ShowProgressProperty, true);
        }

        public static void HideProgress(this Button textBox)
        {
            textBox.SetValue(ShowProgressProperty, false);
        }

        public static readonly AttachedProperty<object?> IconProperty =
            AvaloniaProperty.RegisterAttached<Button, object?>("Icon", typeof(Button), defaultValue: null);

        public static object? GetIcon(Button textBox)
        {
            return textBox.GetValue(IconProperty);
        }

        public static void SetIcon(Button textBox, object? value)
        {
            textBox.SetValue(IconProperty, value);
        }
    }

    public class ButtonExtensionBoolToWidthConverter : IValueConverter
    {
        public static ButtonExtensionBoolToWidthConverter Instance { get; } = new();

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;

            return (bool)value ? 40 : 0;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}