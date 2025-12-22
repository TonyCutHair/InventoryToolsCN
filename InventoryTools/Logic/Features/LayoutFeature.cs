using System.Collections.Generic;
using InventoryTools.Logic.Settings;
using InventoryTools.Logic.Settings.Abstract;

namespace InventoryTools.Logic.Features;

public class LayoutFeature : Feature
{
    public LayoutFeature(IEnumerable<ISetting> settings) : base(new[]
        {
            typeof(CraftWindowLayoutSetting),
            typeof(FiltersWindowLayoutSetting),
        },
        settings)
    {
    }

    public override string Name { get; } = "布局";
    public override string Description { get; } =
        "如何排版主物品窗口和制作窗口？是否应该以选项卡或侧边栏的方式显示列表？";
}