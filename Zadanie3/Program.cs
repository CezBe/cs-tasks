using System;

class Program
{
    static void Main()
    {
        string configPath = "config.json";
        MonitorConfig config = MonitorConfig.Load(configPath);

        Console.WriteLine("Aktualne progi:");
        Console.WriteLine($"CPU: {config.CpuThreshold}%, RAM: {config.RamThreshold}%");

        Console.Write("Chcesz zmienić konfigurację? (t/n): ");
        if (Console.ReadLine()?.ToLower() == "t")
        {
            Console.Write("Nowy próg CPU (%): ");
            config.CpuThreshold = float.Parse(Console.ReadLine()!);

            Console.Write("Nowy próg RAM (%): ");
            config.RamThreshold = float.Parse(Console.ReadLine()!);

            MonitorConfig.Save(configPath, config);
        }

        SystemMonitor monitor = new SystemMonitor(config);
        monitor.Start();

        Console.WriteLine("Monitoring rozpoczęty. Wciśnij dowolny klawisz, aby zakończyć...");
        Console.ReadKey();
        monitor.Stop();
    }
}