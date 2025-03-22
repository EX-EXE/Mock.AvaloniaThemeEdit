using Avalonia.Media;
using Avalonia.Themes.Fluent;
using System;

namespace Mock.AvaloniaThemeEdit.ViewModels;

public static class ColorPaletteResourcesExtensions
{
    public static void SetColor(this ColorPaletteResources colorPaletteResources, string key, Color color)
    {
        switch (key)
        {
            case "Accent":
                colorPaletteResources.Accent = color;
                break;
            case "AltHigh":
            case "SystemAltHighColor":
                colorPaletteResources.AltHigh = color;
                break;
            case "AltLow":
            case "SystemAltLowColor":
                colorPaletteResources.AltLow = color;
                break;
            case "AltMedium":
            case "SystemAltMediumColor":
                colorPaletteResources.AltMedium = color;
                break;
            case "AltMediumHigh":
            case "SystemAltMediumHighColor":
                colorPaletteResources.AltMediumHigh = color;
                break;
            case "AltMediumLow":
            case "SystemAltMediumLowColor":
                colorPaletteResources.AltMediumLow = color;
                break;
            case "BaseHigh":
            case "SystemBaseHighColor":
                colorPaletteResources.BaseHigh = color;
                break;
            case "BaseLow":
            case "SystemBaseLowColor":
                colorPaletteResources.BaseLow = color;
                break;
            case "BaseMedium":
            case "SystemBaseMediumColor":
                colorPaletteResources.BaseMedium = color;
                break;
            case "BaseMediumHigh":
            case "SystemBaseMediumHighColor":
                colorPaletteResources.BaseMediumHigh = color;
                break;
            case "BaseMediumLow":
            case "SystemBaseMediumLowColor":
                colorPaletteResources.BaseMediumLow = color;
                break;
            case "ChromeAltLow":
            case "SystemChromeAltLowColor":
                colorPaletteResources.ChromeAltLow = color;
                break;
            case "ChromeBlackHigh":
            case "SystemChromeBlackHighColor":
                colorPaletteResources.ChromeBlackHigh = color;
                break;
            case "ChromeBlackLow":
            case "SystemChromeBlackLowColor":
                colorPaletteResources.ChromeBlackLow = color;
                break;
            case "ChromeBlackMedium":
            case "SystemChromeBlackMediumColor":
                colorPaletteResources.ChromeBlackMedium = color;
                break;
            case "ChromeBlackMediumLow":
            case "SystemChromeBlackMediumLowColor":
                colorPaletteResources.ChromeBlackMediumLow = color;
                break;
            case "ChromeDisabledHigh":
            case "SystemChromeDisabledHighColor":
                colorPaletteResources.ChromeDisabledHigh = color;
                break;
            case "ChromeDisabledLow":
            case "SystemChromeDisabledLowColor":
                colorPaletteResources.ChromeDisabledLow = color;
                break;
            case "ChromeGray":
            case "SystemChromeGrayColor":
                colorPaletteResources.ChromeGray = color;
                break;
            case "ChromeHigh":
            case "SystemChromeHighColor":
                colorPaletteResources.ChromeHigh = color;
                break;
            case "ChromeLow":
            case "SystemChromeLowColor":
                colorPaletteResources.ChromeLow = color;
                break;
            case "ChromeMedium":
            case "SystemChromeMediumColor":
                colorPaletteResources.ChromeMedium = color;
                break;
            case "ChromeMediumLow":
            case "SystemChromeMediumLowColor":
                colorPaletteResources.ChromeMediumLow = color;
                break;
            case "ChromeWhite":
            case "SystemChromeWhiteColor":
                colorPaletteResources.ChromeWhite = color;
                break;
            case "ErrorText":
            case "SystemErrorTextColor":
                colorPaletteResources.ErrorText = color;
                break;
            case "ListLow":
            case "SystemListLowColor":
                colorPaletteResources.ListLow = color;
                break;
            case "ListMedium":
            case "SystemListMediumColor":
                colorPaletteResources.ListMedium = color;
                break;
            case "RegionColor":
            case "SystemRegionColor":
                colorPaletteResources.RegionColor = color;
                break;
            default:
                throw new NotImplementedException($"NotImpl. {key}");
        }
    }
}
