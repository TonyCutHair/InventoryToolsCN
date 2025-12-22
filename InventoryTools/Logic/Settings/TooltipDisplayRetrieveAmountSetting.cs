using InventoryTools.Logic.Settings.Abstract;
using InventoryTools.Services;
using Microsoft.Extensions.Logging;

namespace InventoryTools.Logic.Settings;

public partial class TooltipDisplayRetrieveAmountSetting : BooleanSetting
{
    public override bool DefaultValue { get; set; }
    public override bool CurrentValue(InventoryToolsConfiguration configuration)
    {
        return configuration.TooltipDisplayRetrieveAmount;
    }

    public override void UpdateFilterConfiguration(InventoryToolsConfiguration configuration, bool newValue)
    {
        configuration.TooltipDisplayRetrieveAmount = newValue;
    }

    public override string Key { get; set; } = "DisplayRetrievalAmount";
    public override string Name { get; set; } = "显示要检索的数量";

    public override string WizardName { get; } = "要检索的数量";

    public override string HelpText { get; set; } =
        "是否应该在工具提示中显示需要检索的数量？";

    public override SettingCategory SettingCategory { get; set; } = SettingCategory.ToolTips;
    public override SettingSubCategory SettingSubCategory { get; } = SettingSubCategory.AmountToRetrieve;
    public override string Version => "1.7.0.0";

    public override uint? Order => 0;

    public TooltipDisplayRetrieveAmountSetting(ILogger<TooltipDisplayRetrieveAmountSetting> logger, ImGuiService imGuiService) : base(logger, imGuiService)
    {
    }
}