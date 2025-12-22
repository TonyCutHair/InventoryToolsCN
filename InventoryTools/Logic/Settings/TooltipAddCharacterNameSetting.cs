using InventoryTools.Logic.Settings.Abstract;
using InventoryTools.Services;
using Microsoft.Extensions.Logging;

namespace InventoryTools.Logic.Settings
{
    public class TooltipAddCharacterNameSetting : BooleanSetting
    {
        public override bool DefaultValue { get; set; } = false;

        public override bool CurrentValue(InventoryToolsConfiguration configuration)
        {
            return configuration.TooltipAddCharacterNameOwned;
        }

        public override void UpdateFilterConfiguration(InventoryToolsConfiguration configuration, bool newValue)
        {
            configuration.TooltipAddCharacterNameOwned = newValue;
        }

        public override string Key { get; set; } = "TooltipCharacterName";
        public override string Name { get; set; } = "显示物品位置（附加角色名称）";

        public override string HelpText { get; set; } =
            "当悬停物品时，如果您有由雇员拥有的物品，是否应该在物品旁边附加该雇员的所有者名称？";

        public override SettingCategory SettingCategory { get; set; } = SettingCategory.ToolTips;
        public override SettingSubCategory SettingSubCategory { get; } = SettingSubCategory.AddItemLocations;
        public override string Version => "1.7.0.0";

        public TooltipAddCharacterNameSetting(ILogger<TooltipAddCharacterNameSetting> logger, ImGuiService imGuiService) : base(logger, imGuiService)
        {
        }
    }
}