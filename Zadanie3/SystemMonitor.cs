using System;
using System.Diagnostics;
using System.IO;
using System.Timers;
using Timer = System.Timers.Timer;

public class SystemMonitor
{
    private readonly PerformanceCounter cpuCounter;
    private readonly PerformanceCounter ramCounter;
    private readonly MonitorConfig config;
    private readonly Timer timer;
    private readonly string logPath = "event_log.txt";

    public SystemMonitor(MonitorConfig config)
    {
        this.config = config;
        cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

        timer = new Timer(5000); // co 5 sek.
        timer.Elapsed += TimerElapsed;
    }

    public void Start() => timer.Start();
    public void Stop() => timer.Stop();

    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        float cpu = cpuCounter.NextValue();
        float ram = ramCounter.NextValue();

        Console.WriteLine($"CPU: {cpu:F1}%, RAM: {ram:F1}%");

        if (cpu > config.CpuThreshold || ram > config.RamThreshold)
        {
            string message = $"{DateTime.Now}: ALERT! CPU: {cpu:F1}%, RAM: {ram:F1}%";
            File.AppendAllText(logPath, message + Environment.NewLine);
        }
    }
}