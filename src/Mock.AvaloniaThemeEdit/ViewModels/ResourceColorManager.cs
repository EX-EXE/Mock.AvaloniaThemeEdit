using Avalonia.Media;
using Avalonia.Themes.Fluent;
using ObservableCollections;
using R3;
using System.Collections.Generic;

namespace Mock.AvaloniaThemeEdit.ViewModels;

public class ResourceColorManager
{
    public ObservableList<ResourceColorGroup> GroupColors { get; set; } = new();
    public INotifyCollectionChangedSynchronizedViewList<ResourceColorGroup> GroupColorView { get; set; }

    public ResourceColorManager()
    {
        GroupColorView = GroupColors
            .ToNotifyCollectionChangedSlim();

        var accentGroup = new ResourceColorGroup();
        foreach (var colorName in new string[] {
            "Accent",
            "RegionColor",
            "ListLow",
            "ListMedium",
            "ErrorText",
        })
        {
            accentGroup.ResourceColors.Add(new ResourceColorItem()
            {
                Name = colorName,
                ResourceColor = new(Colors.Black),
            });
        }
        GroupColors.Add(accentGroup);

        var baseGroup = new ResourceColorGroup();
        foreach (var colorName in new string[] {
            "AltLow",
            "AltMedium",
            "AltMediumHigh",
            "AltMediumLow",
            "AltHigh",
            "BaseLow",
            "BaseMedium",
            "BaseMediumLow",
            "BaseMediumHigh",
            "BaseHigh"
        })
        {
            baseGroup.ResourceColors.Add(new ResourceColorItem()
            {
                Name = colorName,
                ResourceColor = new(Colors.Black),
            });
        }
        GroupColors.Add(baseGroup);

        var chromeGroup = new ResourceColorGroup();
        foreach (var colorName in new string[] {
            "ChromeLow",
            "ChromeMedium",
            "ChromeMediumLow",
            "ChromeHigh",
            "ChromeAltLow",
            "ChromeBlackLow",
            "ChromeBlackMedium",
            "ChromeBlackMediumLow",
            "ChromeBlackHigh",
            "ChromeWhite",
            "ChromeGray",
            "ChromeDisabledLow",
            "ChromeDisabledHigh"
        })
        {
            chromeGroup.ResourceColors.Add(new ResourceColorItem()
            {
                Name = colorName,
                ResourceColor = new(Colors.Black),
            });
        }
        GroupColors.Add(chromeGroup);
    }

    public ColorPaletteResources CreateColorPalette()
    {
        var colorPalette = new ColorPaletteResources();
        foreach (var groupColor in GroupColors)
        {
            foreach (var resourceColor in groupColor.ResourceColors)
            {
                colorPalette.SetColor(resourceColor.Name, resourceColor.ResourceColor.Value);
            }
        }
        return colorPalette;
    }

    public void Load(Dictionary<string, string> colors)
    {
        foreach (var groupColor in GroupColors)
        {
            groupColor.Load(colors);
        }
    }

}

public class ResourceColorGroup
{
    public ObservableList<ResourceColorItem> ResourceColors { get; set; } = new();
    public INotifyCollectionChangedSynchronizedViewList<ResourceColorItem> ResourceColorView { get; set; }

    public ResourceColorGroup()
    {
        ResourceColorView = ResourceColors
            .ToNotifyCollectionChangedSlim();
    }

    public void Load(Dictionary<string, string> colors)
    {
        foreach (var resourceColor in ResourceColors)
        {
            resourceColor.Load(colors);
        }
    }
}

public class ResourceColorItem
{
    public string Name { get; set; } = "";
    public BindableReactiveProperty<Color> ResourceColor { get; set; } = new();
    public void Load(Dictionary<string, string> colors)
    {
        if (colors.TryGetValue(Name, out var colorString) &&
            Color.TryParse(colorString, out var color))
        {
            ResourceColor.Value = color;
        }
    }
}
