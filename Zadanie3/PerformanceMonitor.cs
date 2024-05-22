using System;
using System.Diagnostics;
using System.IO;
using System.Timers;

namespace Zadanie3
{
    public class PerformanceMonitor
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private Timer timer;
        private const float cpuThreshold = 80.0f; // Próg dla CPU w %
        private const float ramThreshold = 1024.0f; // Próg dla RAM w MB
        private const string logFilePath = "performance_log.txt";
        //u mnie plik generuje sie w folderze C:\Users\Michal\source\repos\Lab2\Zadanie3\bin\Debug

        public PerformanceMonitor()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            timer = new Timer(10000);
            timer.Elapsed += Timer_Elapsed;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            float cpuUsage = cpuCounter.NextValue();
            float availableRam = ramCounter.NextValue();

            LogPerformance(cpuUsage, availableRam);

            if (cpuUsage > cpuThreshold)
            {
                LogEvent($"CPU usage exceeded threshold: {cpuUsage}%");
            }

            if (availableRam < ramThreshold)
            {
                LogEvent($"Available RAM below threshold: {availableRam} MB");
            }
        }

        private void LogPerformance(float cpuUsage, float availableRam)
        {
            string logMessage = $"{DateTime.Now}: CPU Usage: {cpuUsage}% | Available RAM: {availableRam} MB";
            try
            {
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }

        private void LogEvent(string message)
        {
            string source = "PerformanceMonitor";
            string log = "Application";

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }

            EventLog.WriteEntry(source, message, EventLogEntryType.Warning);
        }
    }
}
