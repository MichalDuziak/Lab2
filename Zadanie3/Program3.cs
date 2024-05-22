using System;
using System.Windows.Forms;

namespace Zadanie3
{
    static class Program3
    {
        [STAThread]
        static void Main()
        {
            PerformanceMonitor monitor = new PerformanceMonitor();
            monitor.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());

            monitor.Stop();
        }
    }
}
