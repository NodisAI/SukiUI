using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using SukiUI.ColorTheme;
using SukiUI.Content;
using SukiUI.Helpers;

namespace SukiUI.Toasts
{
    public readonly ref struct SukiToastBuilder
    {
        public ISukiToastManager Manager { get; }
        public ISukiToast Toast { get; }

        public SukiToastBuilder(ISukiToastManager manager)
        {
            Manager = manager;
            Toast = ToastPool.Get();
            Toast.Manager = Manager;
        }

        public ISukiToast Queue()
        {
            Manager.Queue(Toast);
            return Toast;
        }

        public SukiToastBuilder SetTitle(string title)
        {
            Toast.Title = title;
            return this;
        }

        public SukiToastBuilder SetContent(object? content)
        {
            Toast.Content = content;
            return this;
        }

        public SukiToastBuilder SetCanDismissByClicking(bool canDismiss = true)
        {
            Toast.CanDismissByClicking = canDismiss;
            return this;
        }

        public SukiToastBuilder SetLoadingState(bool loading)
        {
            Toast.LoadingState = loading;
            return this;
        }

        public SukiToastBuilder SetType(NotificationType type)
        {
            Toast.Icon = type switch
            {
                NotificationType.Information => Icons.InformationOutline,
                NotificationType.Success => Icons.Check,
                NotificationType.Warning => Icons.AlertOutline,
                NotificationType.Error => Icons.AlertOutline,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
            Toast.Foreground = type switch
            {
                NotificationType.Information => NotificationColor.InfoIconForeground,
                NotificationType.Success => NotificationColor.SuccessIconForeground,
                NotificationType.Warning => NotificationColor.WarningIconForeground,
                NotificationType.Error => NotificationColor.ErrorIconForeground,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
            return this;
        }

        public SukiToastBuilder Delay(TimeSpan delay, Action<ISukiToast> action)
        {
            Toast.DelayDismissAction = action;
            var toast = Toast;
            Task.Delay(delay).ContinueWith(
                _ =>
                {
                    if (toast.DelayDismissAction != action) return;
                    toast.DelayDismissAction.Invoke(toast);
                },
                TaskScheduler.FromCurrentSynchronizationContext());
            return this;
        }

        public SukiToastBuilder SetOnDismiss(Action<ISukiToast> action)
        {
            Toast.OnDismissed = action;
            return this;
        }

        public SukiToastBuilder SetOnClicked(Action<ISukiToast> action)
        {
            Toast.OnClicked = action;
            return this;
        }

        public SukiToastBuilder AddActionButton(object buttonContent, Action<ISukiToast> action, bool dismissOnClick, bool flatStyle = true)
        {
            var btn = new Button
            {
                Content = buttonContent,
                Classes = { flatStyle ? "Flat" : "Basic" },
                Margin = flatStyle ? new Thickness(14, 9, 0, 12) : new Thickness(14, -3, 0, 2)
            };

            var (toast, manager) = (Toast, Manager);
            btn.Click += (_, _) =>
            {
                action(toast);
                if (dismissOnClick) manager.Dismiss(toast);
            };
            Toast.ActionButtons.Add(btn);

            return this;
        }

        public readonly ref struct DismissToast(SukiToastBuilder builder)
        {
            public SukiToastBuilder Builder { get; } = builder;
        }
    }
}