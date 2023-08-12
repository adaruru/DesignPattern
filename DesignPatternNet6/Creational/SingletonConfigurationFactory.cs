//創建型、建立型
using Microsoft.Extensions.Configuration;

namespace DesignPatternNet6.Creational;
public static class ConfigurationFactory
{
    public static string AppSettingName { get; set; }
    public static IConfigurationRoot ConfigurationRoot { get; set; }

    public static void Initial(IConfigurationRoot config)
    {
        ConfigurationRoot = config; ;
    }

    public static IConfigurationRoot Create()
    {
        if (ConfigurationRoot == null)
        {
            var Iconfig = new ConfigurationBuilder();
            var config = Iconfig.SetBasePath(AppContext.BaseDirectory)
                                .AddJsonFile(AppSettingName, false).Build();
            ConfigurationRoot = config;
        }
        return ConfigurationRoot;
    }
}


