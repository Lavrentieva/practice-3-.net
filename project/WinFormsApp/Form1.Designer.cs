namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            trackBar1 = new TrackBar();
            rangePicker1 = new WinFormsControlLibrary.RangePicker();
            rangePicker2 = new WinFormsControlLibrary.RangePicker();
            rangePicker3 = new WinFormsControlLibrary.RangePicker();
            rangePicker4 = new WinFormsControlLibrary.RangePicker();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(40, 12);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(184, 69);
            trackBar1.TabIndex = 0;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // rangePicker1
            // 
            rangePicker1.FillColor = Color.Orchid;
            rangePicker1.ForeColor = Color.DarkOrange;
            rangePicker1.Location = new Point(12, 71);
            rangePicker1.Max = 30;
            rangePicker1.Min = -30;
            rangePicker1.MinimumSize = new Size(184, 104);
            rangePicker1.Name = "rangePicker1";
            rangePicker1.SelectedMax = 20;
            rangePicker1.SelectedMin = -10;
            rangePicker1.Size = new Size(437, 104);
            rangePicker1.TabIndex = 1;
            // 
            // rangePicker2
            // 
            rangePicker2.FillColor = Color.Crimson;
            rangePicker2.ForeColor = Color.DarkRed;
            rangePicker2.Location = new Point(12, 209);
            rangePicker2.Max = 100;
            rangePicker2.Min = 0;
            rangePicker2.MinimumSize = new Size(184, 104);
            rangePicker2.Name = "rangePicker2";
            rangePicker2.SelectedMax = 100;
            rangePicker2.SelectedMin = 0;
            rangePicker2.Size = new Size(745, 104);
            rangePicker2.TabIndex = 2;
            // 
            // rangePicker3
            // 
            rangePicker3.FillColor = Color.Blue;
            rangePicker3.ForeColor = Color.ForestGreen;
            rangePicker3.Location = new Point(12, 334);
            rangePicker3.Max = 0;
            rangePicker3.Min = -10;
            rangePicker3.MinimumSize = new Size(184, 104);
            rangePicker3.Name = "rangePicker3";
            rangePicker3.SelectedMax = 0;
            rangePicker3.SelectedMin = -5;
            rangePicker3.Size = new Size(776, 104);
            rangePicker3.TabIndex = 3;
            // 
            // rangePicker4
            // 
            rangePicker4.FillColor = Color.Green;
            rangePicker4.ForeColor = Color.ForestGreen;
            rangePicker4.Location = new Point(455, 71);
            rangePicker4.Max = 5;
            rangePicker4.Min = 0;
            rangePicker4.MinimumSize = new Size(184, 104);
            rangePicker4.Name = "rangePicker4";
            rangePicker4.SelectedMax = 2;
            rangePicker4.SelectedMin = 1;
            rangePicker4.Size = new Size(320, 104);
            rangePicker4.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rangePicker4);
            Controls.Add(rangePicker3);
            Controls.Add(rangePicker2);
            Controls.Add(rangePicker1);
            Controls.Add(trackBar1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBar1;
        private WinFormsControlLibrary.RangePicker rangePicker1;
        private WinFormsControlLibrary.RangePicker rangePicker2;
        private WinFormsControlLibrary.RangePicker rangePicker3;
        private WinFormsControlLibrary.RangePicker rangePicker4;
    }
}