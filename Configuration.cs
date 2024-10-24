using Newtonsoft.Json;
using TShockAPI;

namespace TimeRate
{
    internal class Configuration
    {
        #region 实例变量
        [JsonProperty("开关", Order = -8)]
        public bool Enabled { get; set; } = false;

        [JsonProperty("速率", Order = -6)]
        public int UpdateRate = 60;
        #endregion

        #region 读取与创建配置文件方法
        public static readonly string FilePath = Path.Combine(TShock.SavePath, "时间加速.json");

        public void Write()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented); 
            File.WriteAllText(FilePath, json);
        }

        public static Configuration Read()
        {
            if (!File.Exists(FilePath))
            {
                var NewConfig = new Configuration();
                new Configuration().Write();
                return NewConfig;
            }
            else
            {
                string jsonContent = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<Configuration>(jsonContent)!;
            }
        }
        #endregion
    }
}