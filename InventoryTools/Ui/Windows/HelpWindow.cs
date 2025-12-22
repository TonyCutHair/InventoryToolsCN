using System.Numerics;
using AllaganLib.Shared.Extensions;
using CriticalCommonLib.Services.Mediator;
using DalaMock.Host.Mediator;
using Dalamud.Bindings.ImGui;
using InventoryTools.Extensions;
using InventoryTools.Logic;
using Dalamud.Interface.Utility.Raii;
using InventoryTools.Services;
using Microsoft.Extensions.Logging;

namespace InventoryTools.Ui
{
    public class HelpWindow : GenericWindow
    {
        private readonly InventoryToolsConfiguration _configuration;

        public HelpWindow(ILogger<HelpWindow> logger, MediatorService mediator, ImGuiService imGuiService, InventoryToolsConfiguration configuration, string name = "帮助窗口") : base(logger, mediator, imGuiService, configuration, name)
        {
            _configuration = configuration;
        }
        public override void Initialize()
        {
            WindowName = "帮助";
            Key = "help";
        }

        public override bool SaveState => false;
        public override Vector2? DefaultSize { get; } = new Vector2(700, 700);
        public override  Vector2? MaxSize { get; } = new Vector2(2000, 2000);
        public override  Vector2? MinSize { get; } = new Vector2(200, 200);
        public override string GenericKey { get; } = "help";
        public override string GenericName { get; } = "帮助";
        public override bool DestroyOnClose => true;


        public override void Draw()
        {
            using (var sideBarChild =
                   ImRaii.Child("SideBar", new Vector2(150, -1) * ImGui.GetIO().FontGlobalScale, true))
            {
                if (sideBarChild.Success)
                {
                    if (ImGui.Selectable("1. 常规", _configuration.SelectedHelpPage == 0))
                    {
                        _configuration.SelectedHelpPage = 0;
                    }

                    if (ImGui.Selectable("2. 筛选基础", _configuration.SelectedHelpPage == 1))
                    {
                        _configuration.SelectedHelpPage = 1;
                    }

                    if (ImGui.Selectable("3. 筛选", _configuration.SelectedHelpPage == 2))
                    {
                        _configuration.SelectedHelpPage = 2;
                    }

                    if (ImGui.Selectable("4. 关于", _configuration.SelectedHelpPage == 3))
                    {
                        _configuration.SelectedHelpPage = 3;
                    }
                }
            }

            ImGui.SameLine();

            using (var mainChild = ImRaii.Child("###ivHelpView", new Vector2(-1, -1), true))
            {
                if (mainChild.Success)
                {
                    if (_configuration.SelectedHelpPage == 0)
                    {
                        ImGui.TextWrapped(
                            "库存工具是一个多功能插件，提供3个主要功能：追踪/显示您的库存数据、帮助您规划制作以及提供有关物品的信息。还有其他功能，它们涵盖在'功能'中");
                        ImGui.TextWrapped(
                            "如果您使用过 Teamcraft 或 Garland Tools，该插件从两者都汲取了灵感。");
                        ImGui.NewLine();
                        ImGui.TextUnformatted("库存追踪：");
                        ImGui.Separator();
                        ImGui.TextWrapped("插件将尽力跟踪您的库存。有些库存仅在首次访问时缓存。如果您看不到您的雇员/自由公司/风采柜/等，请确保首先查看它们，否则插件将无法缓存它们。");
                        ImGui.TextWrapped("一旦插件了解了物品，您就可以创建列表来缩小特定物品的搜索范围，帮助您整理物品和许多其他事情。");
                        ImGui.NewLine();

                        ImGui.TextUnformatted("制作规划：");
                        ImGui.Separator();
                        ImGui.TextWrapped("该插件有一个专门的制作窗口，让您可以创建要制作的物品列表。它将创建一个计划，将每件物品分解为各个部分，并告诉您缺少什么。它会告诉您需要的所有内容在哪里，如果您缺少任何东西，它会指导您去找到/购买缺失的物品。");
                        ImGui.TextWrapped("如果您曾经使用过 Teamcraft，您应该会很熟悉。");
                        ImGui.NewLine();

                        ImGui.TextUnformatted("物品信息：");
                        ImGui.Separator();
                        ImGui.TextWrapped("该插件对每件物品都有相当全面的信息数据库。如果您使用过 garland tools，提供的信息非常相似。在插件中点击物品的图标将始终打开物品信息窗口。");
                        ImGui.NewLine();

                        ImGui.TextUnformatted("高亮显示：");
                        ImGui.Separator();
                        ImGui.TextWrapped("使用物品列表或制作列表时，您可以切换高亮显示。这将高亮显示游戏中的物品，以便您可以看到物品的确切位置。当插件窗口处于活动状态时，您可以点击'高亮'复选框为该列表激活高亮。如果您想通过宏触发此功能，请查看帮助的命令部分，您可以切换'后台'高亮。");
                        ImGui.NewLine();

                        ImGui.TextUnformatted("这是一个非常基础的指南，有关更多信息，请参阅 wiki。");
                        if (ImGui.Button("Open Wiki"))
                        {
                            "https://github.com/Critical-Impact/InventoryTools/wiki/1.-Overview".OpenBrowser();
                        }
                    }
                    else if (_configuration.SelectedHelpPage == 1)
                    {
                        ImGui.PushTextWrapPos();
                        ImGui.Text("列表是插件提供的核心方式，让您可以查看要查找或尝试整理的物品。");
                        ImGui.Text("目前可以创建3种类型的列表。");
                        ImGui.PopTextWrapPos();
                        ImGui.NewLine();

                        ImGui.Text("搜索列表");
                        ImGui.Separator();
                        ImGui.PushTextWrapPos();

                        ImGui.TextUnformatted("此类型列表允许您在所有库存中搜索特定物品。如果您只需要查找物品，但不想获得整理帮助，这是您想要的列表类型。");
                        ImGui.TextUnformatted("使用示例：");
                        ImGui.BulletText("查找制作所需的材料。");
                        ImGui.BulletText("查找您放在某处的房屋物品。");
                        ImGui.BulletText("查看刚拿起的物品价值多少。");
                        ImGui.BulletText("查看特定物品是否已在您的风采柜或兵装库中。");
                        ImGui.BulletText("检查您的雇员装备而不实际去雇员铃。");
                        ImGui.BulletText("检查您拥有的任何物品是否可以进入兵装库。");
                        ImGui.PopTextWrapPos();
                        ImGui.NewLine();

                        ImGui.Text("整理筛选");
                        ImGui.Separator();
                        ImGui.PushTextWrapPos();
                        ImGui.TextUnformatted("此类型列表建立在'搜索列表'之上，但还允许您选择要将物品整理的位置。它将尝试为您显示在选择的目的地中存储物品的最优化计划。");
                        ImGui.TextUnformatted("使用示例：");
                        ImGui.BulletText("制作后放置材料而不重复。");
                        ImGui.BulletText("在您的陆行鸟鞍囊中存储超过一定物品等级的物品以供日后使用。");
                        ImGui.BulletText("查找自由公司柜中独有的物品并将其放在那里。");
                        ImGui.PopTextWrapPos();

                        ImGui.NewLine();
                        ImGui.Text("游戏物品筛选");
                        ImGui.Separator();
                        ImGui.PushTextWrapPos();
                        ImGui.TextUnformatted("此筛选允许您在游戏物品目录中存在的所有物品中搜索。");
                        ImGui.TextUnformatted("使用示例：");
                        ImGui.BulletText("搜索风采品");
                        ImGui.BulletText("查看您未获得的坐骑/随从");
                        ImGui.BulletText("追踪游戏内所有物品的价格");
                        ImGui.PopTextWrapPos();
                    }
                    else if (_configuration.SelectedHelpPage == 2)
                    {
                        ImGui.TextUnformatted("高级搜索/筛选语法：");
                        ImGui.Separator();
                        ImGui.TextWrapped(
                            "创建列表或搜索列表结果时，可以使用一系列运算符来使搜索更具体。可用的运算符取决于您搜索的内容，但目前支持 !, <, >, >=, <=, = 。");
                        ImGui.TextWrapped(
                            "! - 显示不包含输入内容的任何结果 - 可用于文本和数字。");
                        ImGui.TextWrapped(
                            "< - 显示值小于输入值的任何结果 - 仅可用于数字。");
                        ImGui.TextWrapped(
                            "> - 显示值大于输入值的任何结果 - 仅可用于数字。");
                        ImGui.TextWrapped(
                            ">= - 显示值大于或等于输入值的任何结果 - 仅可用于数字。");
                        ImGui.TextWrapped(
                            "<= - 显示值小于或等于输入值的任何结果 - 仅可用于数字。");
                        ImGui.TextWrapped(
                            "= - 显示值恰好等于输入值的任何结果 - 可用于文本和数字。");
                        ImGui.TextWrapped(
                            "&& 和 || 分别代表 AND 和 OR - 可用于将运算符链接在一起。");
                    }
                    else if (_configuration.SelectedHelpPage == 3)
                    {
                        ImGui.TextUnformatted("关于：");
                        ImGui.TextUnformatted(
                            "此插件在我的空闲时间编写，这是一项热情的工作，我希望在一段时间内继续积极发布更新。");
                        ImGui.TextUnformatted(
                            "如果您遇到任何问题，请通过插件安装程序反馈按钮提交反馈。");
                        ImGui.TextUnformatted("插件 Wiki： ");
                        ImGui.SameLine();
                        if (ImGui.Button("打开##WikiBtn"))
                        {
                            "https://github.com/Critical-Impact/InventoryTools/wiki/1.-Overview".OpenBrowser();
                        }

                        ImGui.TextUnformatted("发现错误？");
                        ImGui.SameLine();
                        if (ImGui.Button("打开##BugBtn"))
                        {
                            "https://github.com/Critical-Impact/InventoryTools/issues".OpenBrowser();
                        }
                    }
                }
            }
        }

        public override FilterConfiguration? SelectedConfiguration => null;

        public override void Invalidate()
        {

        }
    }
}