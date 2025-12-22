using InventoryTools.Logic.Settings.Abstract;
using InventoryTools.Logic.Settings.Abstract.Generic;
using InventoryTools.Services;
using Microsoft.Extensions.Logging;

namespace InventoryTools.Logic.Settings;

public class ShopHighlightingDisableItemsSetting : GenericBooleanSetting
{
    public ShopHighlightingDisableItemsSetting(ILogger<ShopHighlightingDisableItemsSetting> logger, ImGuiService imGuiService) : base("ShopHighlightingDisableItems", "商店高亮 - 禁用未高亮项目", "在商店中高亮物品时，是否禁用未高亮的项目？", false, SettingCategory.Highlighting, SettingSubCategory.General, "1.12.0.15", logger, imGuiService)
    {
    }
}