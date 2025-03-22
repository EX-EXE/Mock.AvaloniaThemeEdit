using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using Avalonia.Threading;
using ObservableCollections;
using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.AvaloniaThemeEdit.ViewModels;


public class Custom : Avalonia.Themes.Fluent.ColorPaletteResources
{
    public Custom()
        : base()
    {
        Accent = new Color(
            Convert.ToByte(Random.Shared.Next(0, 254)),
            Convert.ToByte(Random.Shared.Next(0, 254)),
            Convert.ToByte(Random.Shared.Next(0, 254)),
            Convert.ToByte(Random.Shared.Next(0, 254)));
        //BaseLow = Colors.Green;

        BaseLow = new Color(
            Convert.ToByte(Random.Shared.Next(0, 254)),
            Convert.ToByte(Random.Shared.Next(0, 254)),
            Convert.ToByte(Random.Shared.Next(0, 254)),
            Convert.ToByte(Random.Shared.Next(0, 254)));
    }

}

public class ApplicationStyle : Style
{
    public ApplicationStyle()
        : base()
    {
        Resources.Add("SystemAccentColor", Colors.Red);
        Resources.Add("SystemBaseLowColor", Colors.Red);
    }
}
public class ApplicationResource : ResourceDictionary
{
    public ApplicationResource()
    {
        this["SystemAccentColor"] = Colors.Red;
        this["SystemBaseLowColor"] = Colors.Red;

    }
}

public class ApplicationViewModel
{
    public BindableReactiveProperty<ThemeVariant> CurrentTheme { get; }
        = new BindableReactiveProperty<ThemeVariant>(ThemeVariant.Default);

    public ReactiveCommand UpdateCommand { get; } = new();

    public ApplicationViewModel()
    {
        //UpdateCommand.Subscribe(_ =>
        //{
        //    Dispatcher.UIThread.Invoke(() =>
        //    {
        //        ApplicationThemeData.Instance.SetColorPalette(ThemeVariant.Dark, new Custom());
        //    });
        //});
        //Task.Run(async () =>
        //{
        //    while (true)
        //    {
        //        await Task.Delay(3000);

        //        try
        //        {
        //            Dispatcher.UIThread.Invoke(() =>
        //            {
        //                //ApplicationThemeData.Instance.SetColorPalette(ThemeVariant.Dark, new Custom());
        //            });
        //        }
        //        catch
        //        {

        //        }
        //        continue;
        //        if (CurrentTheme.Value == ThemeVariant.Default)
        //        {
        //            CurrentTheme.Value = ThemeVariant.Light;
        //        }
        //        else if (CurrentTheme.Value == ThemeVariant.Light)
        //        {
        //            CurrentTheme.Value = ThemeVariant.Dark;
        //        }
        //        else if (CurrentTheme.Value == ThemeVariant.Dark)
        //        {
        //            CurrentTheme.Value = ThemeVariant.Default;
        //        }
        //        await Task.Delay(3000);
        //    }
        //}
        //);
    }
}
