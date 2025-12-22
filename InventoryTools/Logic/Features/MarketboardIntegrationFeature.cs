using System.Collections.Generic;
using InventoryTools.Logic.Settings;
using InventoryTools.Logic.Settings.Abstract;

namespace InventoryTools.Logic.Features;

public class MarketboardIntegrationFeature : Feature
{
    public MarketboardIntegrationFeature(IEnumerable<ISetting> settings) : base(new[]
        {
            typeof(AutomaticallyDownloadPricesSetting),
            typeof(MarketRefreshTimeHoursSetting),
            typeof(MarketBoardSaleCountLimitSetting),
        },
        settings)
    {
    }
    public override string Name { get; } = "交易上梯整合";
    public override string Description { get; } =
        "配置交易上梯整合。此功能会按设定时间执行器下载 Universalis 数据，使您能够根据多个游戏世界的物品最低价格和平均价格进行筛选。";
}