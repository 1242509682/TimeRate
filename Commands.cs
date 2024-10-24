using Microsoft.Xna.Framework;
using TShockAPI;

namespace TimeRate;

internal class Commands
{
    public static void times(CommandArgs args)
    {
        var info = TimeRate.Config.Enabled ? "启用" : "禁用";

        if (args.Parameters.Count == 0)
        {
            if (args.Player != null)
            {
                args.Player.SendMessage("【时间加速菜单】\n" +
                    "/times —— 查看时间流速指令菜单\n" +
                    "/times on 或 off —— 开启|关闭时间流速功能\n" +
                    "/times set 数字 —— 设置时间流速(日晷为60 正常为1)\n" +
                    "/reload —— 重载配置文件\n" +
                    $"服务器流速开关:[c/C9C7F5:{info}] 预设速率:[c/FFFCCF:{Terraria.Main.dayRate}]", Color.AntiqueWhite);
            }
            return;
        }

        if (args.Parameters.Count == 1 && args.Parameters[0].ToLower() == "on")
        {
            TimeRate.Config.Enabled = true;
            TimeRate.Config.Write();
            info = TimeRate.Config.Enabled ? "启用" : "禁用";
            args.Player.SendSuccessMessage("已成功[c/C9C7F5:{0}]时间流速! 当前速率为：[c/FFFCCF:{1}]",info, TimeRate.Config.UpdateRate);
            return;
        }

        if (args.Parameters.Count == 1 && args.Parameters[0].ToLower() == "off")
        {
            TimeRate.Config.Enabled = false;
            TimeRate.Config.Write();
            info = TimeRate.Config.Enabled ? "启用" : "禁用";
            args.Player.SendSuccessMessage("已[c/C9C7F5:{0}]时间流速!当前速率为：[c/FFFCCF:{1}]!", info, Terraria.Main.dayRate);
            return;
        }

        if (args.Parameters.Count == 2)
        {
            switch (args.Parameters[0].ToLower())
            {
                case "s":
                case "set":
                    {
                        if (int.TryParse(args.Parameters[1], out int num))
                        {
                            TimeRate.Config.UpdateRate = num;
                            TimeRate.Config.Write();
                            args.Player.SendSuccessMessage("已成功时间流速设置为: [c/C9C7F5:{0}] !", num);
                        }
                        break;
                    }
                default:
                    args.Player.SendInfoMessage("【时间流速菜单】\n" +
                        "/times —— 查看时间流速指令菜单\n" +
                        "/times on 或 off —— 开启|关闭时间流速功能\n" +
                        "/times set 数字 —— 设置时间流速(附魔日晷速度是60 正常为1)\n" +
                        "/reload —— 重载配置文件\n" +
                        $"服务器流速开关:[c/C9C7F5:{info}] 速率:[c/FFFCCF:{TimeRate.Config.UpdateRate}]", Color.AntiqueWhite);
                    return;
            }
        }
    }
}