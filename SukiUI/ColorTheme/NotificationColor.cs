using Avalonia;
using Avalonia.Media;

namespace SukiUI.ColorTheme;

public static class NotificationColor
{
    public static LinearGradientBrush InfoIconForeground { get; } = new()
    {
        EndPoint = new RelativePoint(0, 0, RelativeUnit.Relative),
        StartPoint = new RelativePoint(1, 1, RelativeUnit.Relative),
        GradientStops =
        [
            new GradientStop { Color = Color.FromRgb(89, 126, 247), Offset = 0.3 },
            new GradientStop { Color = Color.FromRgb(47, 84, 235), Offset = 1 },
        ]
    };

    public static LinearGradientBrush SuccessIconForeground { get; } = new()
    {
        EndPoint = new RelativePoint(0, 0, RelativeUnit.Relative),
        StartPoint = new RelativePoint(1, 1, RelativeUnit.Relative),
        GradientStops =
        [
            new GradientStop { Color = Color.FromRgb(82, 196, 26), Offset = 0.3 },
            new GradientStop { Color = Color.FromRgb(56, 158, 13), Offset = 1 },
        ]
    };

    public static LinearGradientBrush WarningIconForeground { get; } = new()
    {
        EndPoint = new RelativePoint(0, 0, RelativeUnit.Relative),
        StartPoint = new RelativePoint(1, 1, RelativeUnit.Relative),
        GradientStops =
        [
            new GradientStop { Color = Color.FromRgb(255, 169, 64), Offset = 0.3 },
            new GradientStop { Color = Color.FromRgb(250, 140, 22), Offset = 1 },
        ]
    };

    public static LinearGradientBrush ErrorIconForeground { get; } = new()
    {
        EndPoint = new RelativePoint(0, 0, RelativeUnit.Relative),
        StartPoint = new RelativePoint(1, 1, RelativeUnit.Relative),
        GradientStops =
        [
            new GradientStop { Color = Color.FromRgb(255, 77, 79), Offset = 0.3 },
            new GradientStop { Color = Color.FromRgb(245, 34, 45), Offset = 1 },
        ]
    };
}