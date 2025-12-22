using InventoryTools.Logic.Settings.Abstract;
using InventoryTools.Logic.Settings.Abstract.Generic;
using InventoryTools.Services;
using Microsoft.Extensions.Logging;

namespace InventoryTools.Logic.Settings;

public class TooltipDisplayIngredientPatchSetting : GenericBooleanSetting
{
    public TooltipDisplayIngredientPatchSetting(ILogger<TooltipDisplayIngredientPatchSetting> logger, ImGuiService imGuiService) : base("TooltipDisplayIngredientPatch", "显示材料版本", "显示材料最后一次被使用的版本。这是通过遍历物品所属的每个配方，然后通过其配方等等，直到确定最高版本来计算的。", false, SettingCategory.ToolTips, SettingSubCategory.IngredientPatch, "1.12.0.11", logger, imGuiService)
    {
    }
}