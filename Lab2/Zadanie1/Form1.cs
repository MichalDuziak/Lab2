using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double dividend = Convert.ToDouble(textBoxDividend.Text);
                double divisor = Convert.ToDouble(textBoxDivisor.Text);
                
                if (divisor == 0)
                {
                    throw new DivideByZeroException("Dzielnik nie może być zerem.");
                }

                //wynik
                double result = dividend / divisor;
                textBoxResult.Text = result.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Proszę wprowadzić poprawne liczby.", "Błąd formatu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError("FormatException", ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Dzielnik nie może być zerem.", "Błąd arytmetyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError("DivideByZeroException", ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError("Exception", ex.Message);
            }
        }

        private void LogError(string errorType, string message)
        {
            // Logowanie błędu do dziennika zdarzeń systemu Windows
            string source = "Lab2";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "Application");
            }
            EventLog.WriteEntry(source, $"{errorType}: {message}", EventLogEntryType.Error);
        }
    }
}
