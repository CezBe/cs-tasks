using System;
using System.Diagnostics;
using System.Windows.Forms;
using SimpleCalculator;

namespace WinFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var stopwatch = Stopwatch.StartNew();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
            stopwatch.Stop();

            // Sprawdź czas inicjalizacji
            var initializationTime = stopwatch.ElapsedMilliseconds;
            const long threshold = 2000; // Próg (w ms)

            if (initializationTime > threshold)
            {
                EventLog.WriteEntry("Application", 
                    $"Aplikacja kalkulatora uruchomiła się zbyt długo: {initializationTime} ms.", 
                    EventLogEntryType.Warning);
            }
        }
    }
}