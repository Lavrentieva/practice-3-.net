using System.Windows.Forms.VisualStyles;

namespace WinFormsControlLibrary
{
    partial class RangePicker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // RangePicker
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "RangePicker";
            Size = new Size(826, 439);
            Paint += RangePicker_Paint;
            MouseUp += RangePicker_MouseUp;
            Leave += RangePicker_Leave;
            ResumeLayout(false);
        }

        #endregion
    }
}