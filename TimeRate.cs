using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using TShockAPI.Hooks;

namespace TimeRate
{
    [ApiVersion(2, 1)]
    public class TimeRate : TerrariaPlugin
    {

        #region 插件模版信息
        public override string Name => "时间加速";
        public override string Author => "羽学";
        public override Version Version => new Version(1, 0, 0);
        public override string Description => "涡轮增压不蒸鸭";
        #endregion

        #region 注册与释放
        public TimeRate(Main game) : base(game) { }
        public override void Initialize()
        {
            LoadConfig();
            GeneralHooks.ReloadEvent += LoadConfig;
            On.Terraria.Main.UpdateTimeRate += UpdateTimeRate;
            TShockAPI.Commands.ChatCommands.Add(new Command("times.admin", Commands.times, "times", "时间加速"));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GeneralHooks.ReloadEvent -= LoadConfig;
                On.Terraria.Main.UpdateTimeRate -= UpdateTimeRate;
                TShockAPI.Commands.ChatCommands.RemoveAll(x => x.CommandDelegate == Commands.times);
            }
            base.Dispose(disposing);
        }
        #endregion

        #region 配置重载读取与写入方法
        internal static Configuration Config = new();
        private static void LoadConfig(ReloadEventArgs args = null!)
        {
            Config = Configuration.Read();
            Config.Write();
            TShock.Log.ConsoleInfo("[时间加速插件]重新加载配置完毕。");
        }
        #endregion

        #region 时间加速方法
        private void UpdateTimeRate(On.Terraria.Main.orig_UpdateTimeRate orig)
        {
            orig.Invoke();

            if (!Config.Enabled)
            {
                Terraria.Main.dayRate = 1;
                Terraria.Main.desiredWorldTilesUpdateRate = 1;
            }

            else
            {
                Terraria.Main.dayRate = Config.UpdateRate;
                Terraria.Main.desiredWorldTilesUpdateRate = Config.UpdateRate;
                TSPlayer.All.SendData((PacketTypes)7);
            }
        } 
        #endregion
    }
}