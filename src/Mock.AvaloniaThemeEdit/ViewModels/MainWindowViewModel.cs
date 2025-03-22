using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using Avalonia.Threading;
using ObservableCollections;
using R3;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tmds.DBus.Protocol;

namespace Mock.AvaloniaThemeEdit.ViewModels;


public partial class MainWindowViewModel
{
    public ObservableList<ThemeVariant> ThemeItems { get; set; } = new();
    public BindableReactiveProperty<ThemeVariant> SelectedTheme { get; set; } = new();
    public BindableReactiveProperty<int> SelectedTabIndex { get; set; } = new(0);

    public BindableReactiveProperty<ResourceColorManager> LightThemeColors { get; set; } = new();
    public BindableReactiveProperty<ResourceColorManager> DarkThemeColors { get; set; } = new();


    public ReactiveCommand UpdateCommand { get; set; } = new();

    public MainWindowViewModel()
    {
        ThemeItems.AddRange(new[]
        {
            ThemeVariant.Light,
            ThemeVariant.Dark,
        });
        SelectedTheme.Value = Application.Current?.ActualThemeVariant ?? ThemeVariant.Light;
        SelectedTabIndex.Value = ThemeItems.IndexOf(SelectedTheme.Value);

        LightThemeColors.Value = new();
        DarkThemeColors.Value = new();

        LightThemeColors.Value.Load(new()
        {
            {"Accent","#ff0073cf"},
            {"AltHigh","White"},
            {"AltLow","White"},
            {"AltMedium","White"},
            {"AltMediumHigh","White"},
            {"AltMediumLow","White"},
            {"BaseHigh","Black"},
            {"BaseLow","#ffcccccc"},
            {"BaseMedium","#ff898989"},
            {"BaseMediumHigh","#ff5d5d5d"},
            {"BaseMediumLow","#ff737373"},
            {"ChromeAltLow","#ff5d5d5d"},
            {"ChromeBlackHigh","Black"},
            {"ChromeBlackLow","#ffcccccc"},
            {"ChromeBlackMedium","#ff5d5d5d"},
            {"ChromeBlackMediumLow","#ff898989"},
            {"ChromeDisabledHigh","#ffcccccc"},
            {"ChromeDisabledLow","#ff898989"},
            {"ChromeGray","#ff737373"},
            {"ChromeHigh","#ffcccccc"},
            {"ChromeLow","#ffececec"},
            {"ChromeMedium","#ffe6e6e6"},
            {"ChromeMediumLow","#ffececec"},
            {"ChromeWhite","White"},
            {"ListLow","#ffe6e6e6"},
            {"ListMedium","#ffcccccc"},
            {"RegionColor","White"},
        });
        DarkThemeColors.Value.Load(new()
        {
            {"Accent","#ff0073cf"},
            {"AltHigh","Black"},
            {"AltLow","Black"},
            {"AltMedium","Black"},
            {"AltMediumHigh","Black"},
            {"AltMediumLow","Black"},
            {"BaseHigh","White"},
            {"BaseLow","#ff333333"},
            {"BaseMedium","#ff9a9a9a"},
            {"BaseMediumHigh","#ffb4b4b4"},
            {"BaseMediumLow","#ff676767"},
            {"ChromeAltLow","#ffb4b4b4"},
            {"ChromeBlackHigh","Black"},
            {"ChromeBlackLow","#ffb4b4b4"},
            {"ChromeBlackMedium","Black"},
            {"ChromeBlackMediumLow","Black"},
            {"ChromeDisabledHigh","#ff333333"},
            {"ChromeDisabledLow","#ff9a9a9a"},
            {"ChromeGray","Gray"},
            {"ChromeHigh","Gray"},
            {"ChromeLow","#ff151515"},
            {"ChromeMedium","#ff1d1d1d"},
            {"ChromeMediumLow","#ff2c2c2c"},
            {"ChromeWhite","White"},
            {"ListLow","#ff1d1d1d"},
            {"ListMedium","#ff333333"},
            {"RegionColor","Black"},
        });

        UpdateCommand.Subscribe(_ =>
        {
            var theme = new FluentTheme();
            theme.Palettes[ThemeVariant.Light] = LightThemeColors.Value.CreateColorPalette();
            theme.Palettes[ThemeVariant.Dark] = DarkThemeColors.Value.CreateColorPalette();
            ApplicationThemeData.Instance.SetThemeColor(SelectedTheme.Value);
            ApplicationThemeData.Instance.SetColorPalette(theme);
        });

    }
}
