using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using Avalonia.Threading;
using Mock.AvaloniaThemeEdit.Views;
using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.AvaloniaThemeEdit.ViewModels;

internal class ApplicationThemeData
{
    public static ApplicationThemeData Instance { get; } = new ApplicationThemeData();
    public BindableReactiveProperty<ThemeVariant> CurrentTheme { get; }
        = new BindableReactiveProperty<ThemeVariant>(ThemeVariant.Light);

    private Avalonia.Application? app = null;

    public void Init(Avalonia.Application app)
    {
        this.app = app;
    }

    public void SetColorPalette(FluentTheme newTheme)
    {
        Dispatcher.UIThread.Invoke(() =>
        {
            if (app != null)
            {
                var theme = app.Styles.OfType<FluentTheme>().FirstOrDefault();
                if (theme != default)
                {
                    app.Styles.Remove(theme);
                }
                app.Styles.Add(newTheme);

                if (app.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
                {
                    var newWindow = new MainWindow();
                    var oldWindow = desktopLifetime.MainWindow;
                    if (oldWindow != null)
                    {
                        newWindow.DataContext = oldWindow.DataContext;
                        newWindow.Width = oldWindow.Width;
                        newWindow.Height = oldWindow.Height;
                        newWindow.Position = oldWindow.Position;
                    }
                    desktopLifetime.MainWindow = newWindow;
                    newWindow.Show();
                    oldWindow?.Close();
                }

            }
        });
    }

    internal void SetThemeColor(ThemeVariant value)
    {
        Dispatcher.UIThread.Invoke(() =>
        {
            app.RequestedThemeVariant = value;
            CurrentTheme.Value = value;
        });
    }
}
