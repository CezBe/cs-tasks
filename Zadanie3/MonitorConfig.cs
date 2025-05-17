using System;
using System.IO;
using Newtonsoft.Json;

public class MonitorConfig
{
    public float CpuThreshold { get; set; }
    public float RamThreshold { get; set; }

    public static void Save(string filePath, MonitorConfig config)
    {
        string json = JsonConvert.SerializeObject(config);
    }

    public static MonitorConfig Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new MonitorConfig { CpuThreshold = 80.0f, RamThreshold = 80.0f };
        }

        string json = File.ReadAllText(filePath);
        MonitorConfig config = JsonConvert.DeserializeObject<MonitorConfig>(json);
        return config;
    }
}