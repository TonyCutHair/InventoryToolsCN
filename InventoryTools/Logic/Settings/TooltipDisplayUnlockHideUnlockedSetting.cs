using InventoryTools.Logic.Settings.Abstract;
using InventoryTools.Logic.Settings.Abstract.Generic;
using InventoryTools.Services;
using Microsoft.Extensions.Logging;

namespace InventoryTools.Logic.Settings;

public class TooltipDisplayUnlockHideUnlockedSetting : GenericBooleanSetting
{
    public TooltipDisplayUnlockHideUnlockedSetting(ILogger<TooltipDisplayUnlockHideUnlockedSetting> logger, ImGuiService imGuiService) : base("TooltipDisplayUnlockHideUnlocked", "显示物品解锁状态（隐藏已解锁角色）", "是否应该隐藏已经解锁此物品的角色？如果在分组模式下，这将隐藏已获得组。", false, SettingCategory.ToolTips, SettingSubCategory.ItemUnlockStatus, "1.11.1.1", logger, imGuiService)
    {
    }
}