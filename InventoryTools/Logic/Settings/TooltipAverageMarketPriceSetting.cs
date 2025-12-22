using InventoryTools.Logic.Settings.Abstract;
using InventoryTools.Services;
using Microsoft.Extensions.Logging;

namespace InventoryTools.Logic.Settings
{
    public class TooltipAverageMarketPriceSetting : BooleanSetting
    {
        public override bool DefaultValue { get; set; } = false;

        public override bool CurrentValue(InventoryToolsConfiguration configuration)
        {
            return configuration.TooltipDisplayMarketAveragePrice;
        }

        public override void UpdateFilterConfiguration(InventoryToolsConfiguration configuration, bool newValue)
        {
            configuration.TooltipDisplayMarketAveragePrice = newValue;
        }

        public override string Key { get; set; } = "TooltipDisplayMBAverage";
        public override string Name { get; set; } = "显示交易板平均价格（NQ/HQ）";

        public override string HelpText { get; set; } =
            "悬停物品时，工具提示是否应该包含NQ和HQ的平均交易板价格？请确保已启用\"自动下载价格\"。";

        public override SettingCategory SettingCategory { get; set; } = SettingCategory.ToolTips;
        public override SettingSubCategory SettingSubCategory { get; } = SettingSubCategory.MarketPricing;
        public override string Version => "1.7.0.0";

        public override uint? Order => 0;

        public TooltipAverageMarketPriceSetting(ILogger<TooltipAverageMarketPriceSetting> logger, ImGuiService imGuiService) : base(logger, imGuiService)
        {
        }
    }
}