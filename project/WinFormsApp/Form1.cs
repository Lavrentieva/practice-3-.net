using System.Diagnostics;
using WinFormsControlLibrary;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        int OldMin;
        int OldMax;

        public Form1()
        {
            InitializeComponent();
            OldMin = rangePicker1.SelectedMin;
            OldMax = rangePicker1.SelectedMax;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void rangePicker1_SelectedMaxChanged(object sender, EventArgs e)
        {
            //Debug.Print("Верхня межа змінилася");
        }

        private void rangePicker1_SelectedMinChanged(object sender, EventArgs e)
        {
            //Debug.Print("Нижня межа змінилася");
        }

        private void rangePicker1_SelectionChanged(object sender, EventArgs e)
        {
            //Debug.Print($"Інтервал змінився. Новий: {Math.Abs(rangePicker1.SelectedMax - rangePicker1.SelectedMin)}, Старий: {Math.Abs(OldMax - OldMin)}.");
            OldMin = rangePicker1.SelectedMin;
            OldMax = rangePicker1.SelectedMax;
        }

        private void rangePicker1_IntervalDecreased(object sender, EventArgs e)
        {
            Debug.Print("Інтервал зменшився");
        }

        private void rangePicker1_IntervalIncreased(object sender, EventArgs e)
        {
            Debug.Print("Інтервал збільшився");
        }
    }
}