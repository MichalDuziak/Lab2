using System;
using System.Windows.Forms;

namespace Zadanie2
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(12, 12);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(260, 20);
            this.textBoxResult.TabIndex = 0;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBoxResult);
            this.Name = "Form2";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            // 
            // Add buttons for digits and operations
            // 
            int x = 12, y = 50;
            for (int i = 0; i <= 9; i++)
            {
                Button button = new Button();
                button.Text = i.ToString();
                button.Size = new System.Drawing.Size(50, 50);
                button.Location = new System.Drawing.Point(x, y);
                button.Click += new System.EventHandler(this.button_Click);
                this.Controls.Add(button);

                x += 55;
                if (x > 180)
                {
                    x = 12;
                    y += 55;
                }
            }

            string[] operators = { "+", "-", "*", "/" };
            x = 180;
            y = 50;
            foreach (var op in operators)
            {
                Button button = new Button();
                button.Text = op;
                button.Size = new System.Drawing.Size(50, 50);
                button.Location = new System.Drawing.Point(x, y);
                button.Click += new System.EventHandler(this.button_Click);
                this.Controls.Add(button);
                y += 55;
            }

            // Equal button
            Button buttonEqual = new Button();
            buttonEqual.Text = "=";
            buttonEqual.Size = new System.Drawing.Size(50, 50);
            buttonEqual.Location = new System.Drawing.Point(180, 265);
            buttonEqual.Click += new System.EventHandler(this.buttonEqual_Click);
            this.Controls.Add(buttonEqual);

            // Clear button
            Button buttonClear = new Button();
            buttonClear.Text = "C";
            buttonClear.Size = new System.Drawing.Size(50, 50);
            buttonClear.Location = new System.Drawing.Point(12, 265);
            buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            this.Controls.Add(buttonClear);
        }

        private System.Windows.Forms.TextBox textBoxResult;
    }
}
