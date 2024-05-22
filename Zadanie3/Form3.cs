using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;

namespace Zadanie3
{
    public partial class Form3 : Form
    {
        private Stopwatch stopwatch;

        public Form3()
        {
            stopwatch = Stopwatch.StartNew();
            InitializeComponent();
            stopwatch.Stop();
            LogInitializationTime();
        }

        private void LogInitializationTime()
        {
            const long threshold = 2000;
            if (stopwatch.ElapsedMilliseconds > threshold)
            {
                string source = "Zadanie3";
                string log = "Application";
                string message = $"Application initialization took {stopwatch.ElapsedMilliseconds} ms.";

                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, log);
                }

                EventLog.WriteEntry(source, message, EventLogEntryType.Warning);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                textBoxResult.Text += button.Text;
            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            try
            {
                var result = new DataTable().Compute(textBoxResult.Text, null);
                textBoxResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in calculation: " + ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
          
        }
    }
}
