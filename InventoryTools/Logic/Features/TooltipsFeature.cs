using System.Collections.Generic;
using InventoryTools.Logic.Settings;
using InventoryTools.Logic.Settings.Abstract;

namespace InventoryTools.Logic.Features;

public class TooltipsFeature : Feature
{
    public TooltipsFeature(IEnumerable<ISetting> settings) : base(new[]
        {
            typeof(TooltipDisplayAmountOwnedSetting),
            typeof(TooltipMinimumMarketPriceSetting),
            typeof(TooltipDisplayUnlockSetting),
            typeof(TooltipSourceInformationEnabledSetting),
            typeof(TooltipUseInformationEnabledSetting),
            typeof(TooltipDisplayIngredientPatchSetting),
        },
        settings)
    {
    }

    public override string Name { get; } = "工具提示";
    public override string Description { get; } =
        "库存工具可以为物品工具提示添加额外信息。选择您想要在工具提示中显示的内容。如需进一步配置（包括更改每个工具提示的颜色和特定于每个工具提示的设置），请打开配置窗口。";
}