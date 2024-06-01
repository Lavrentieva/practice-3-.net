using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;

namespace WinFormsControlLibrary
{
    [ToolboxBitmap(@"D:\ХАІ\1 курс\АППЗ .Net\ЛР 1\Lab1_Heoka_Program\WinFormsControlLibrary\RangePicker.ico")]
    [Description("Very basic slider control with selection range.")]
    public partial class RangePicker : UserControl
    {
        /// <summary>
        /// Minimum value of the slider.
        /// </summary>
        [Description("Minimum value of the slider.")]
        public int Min
        {
            get { return min; }
            set
            {
                if (value < max)
                {
                    min = value;
                    Invalidate();
                    if (value > selectedMin)
                    {
                        selectedMin = value;
                    }
                }
            }
        }
        int min = 0;

        /// <summary>
        /// Maximum value of the slider.
        /// </summary>
        [Description("Maximum value of the slider.")]
        public int Max
        {
            get { return max; }
            set
            {
                if (value > min)
                {
                    max = value;
                    Invalidate();
                    if (value < selectedMax)
                    {
                        selectedMax = value;
                    }
                }
            }
        }
        int max = 100;

        /// <summary>
        /// Minimum value of the selection range.
        /// </summary>
        [Description("Minimum value of the selection range.")]
        public int SelectedMin
        {
            get { return selectedMin; }
            set
            {
                if (value >= min && value <= max)
                {
                    int oldValue = selectedMin;
                    selectedMin = value;
                    SelectionChanged?.Invoke(this, null);
                    SelectedMinChanged?.Invoke(this, null);
                    if (Math.Abs(SelectedMax - SelectedMin) < Math.Abs(SelectedMax - oldValue))
                    {
                        IntervalDecreased?.Invoke(this, null);
                    }
                    else if (Math.Abs(SelectedMax - SelectedMin) > Math.Abs(SelectedMax - oldValue))
                    {
                        IntervalIncreased?.Invoke(this, null);
                    }
                    else
                    {
                        // interval hasn`t been changed
                    }
                    Invalidate();
                }
            }
        }
        int selectedMin = 0;

        /// <summary>
        /// Maximum value of the selection range.
        /// </summary>
        [Description("Maximum value of the selection range.")]
        public int SelectedMax
        {
            get { return selectedMax; }
            set
            {
                if (value <= max && value >= min)
                {
                    int oldValue = selectedMax;
                    selectedMax = value;
                    SelectionChanged?.Invoke(this, null);
                    SelectedMaxChanged?.Invoke(this, null);
                    if (Math.Abs(SelectedMax - SelectedMin) < Math.Abs(oldValue - SelectedMin))
                    {
                        IntervalDecreased?.Invoke(this, null);

                    }
                    else if (Math.Abs(SelectedMax - SelectedMin) > Math.Abs(oldValue - SelectedMin))
                    {
                        IntervalIncreased?.Invoke(this, null);
                    }
                    else
                    {
                        // interval hasn`t been changed
                    }
                    Invalidate();
                }
            }
        }
        int selectedMax = 100;

        /// <summary>
        /// Colour used to fill the selected area line.
        /// </summary>       
        [Description("Colour used to fill the selected area line.")]
        public Color FillColor 
        {
            get 
            { 
                return fillColor; 
            }
            set 
            {
                fillColor = value; Invalidate(); 
            }
        }
        Color fillColor = Color.Blue;


        /// <summary>
        /// The size of a thumb
        /// </summary>
        private int thumbSize = 30;

        /// <summary>
        /// The height of the track
        /// </summary>
        private int trackHeight = 10;

        /// <summary>
        /// The distance between the track and thumbs
        /// </summary>
        private int thumbTrackDistance = 15;

        /// <summary>
        /// Is any thumb being dragged right now
        /// </summary>
        private bool thumbDragged = false;

        /// <summary>
        /// A constant value for the height of the component
        /// </summary>
        private const int fixedHeight = 104;

        /// <summary>
        /// A font variable for those numbers that indicate the borders of selected interval.
        /// I tried using default Font property, but it caused some weird issues that I am too lazy to deal with.
        /// </summary>
        private Font font;

        

        /// <summary>
        /// Fired when SelectedMin or SelectedMax changes.
        /// </summary>
        [Description("Fired when SelectedMin or SelectedMax changes.")]
        public event EventHandler SelectionChanged;

        /// <summary>
        /// Fired when SelectedMin changes.
        /// </summary>
        [Description("Fired when SelectedMin changes.")]
        public event EventHandler SelectedMinChanged;

        /// <summary>
        /// Fired when SelectedMax changes.
        /// </summary>
        [Description("Fired when SelectedMax changes.")]
        public event EventHandler SelectedMaxChanged;

        /// <summary>
        /// Fired when Interval increased.
        /// </summary>
        [Description("Fired when Interval increased.")]
        public event EventHandler IntervalIncreased;

        /// <summary>
        /// Fired when Interval decreased.
        /// </summary>
        [Description("Fired when Interval decreased.")]
        public event EventHandler IntervalDecreased;

        public RangePicker()
        {
            InitializeComponent();
            //avoid flickering
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Paint += new PaintEventHandler(RangePicker_Paint);
            MouseDown += new MouseEventHandler(RangePicker_MouseDown);
            MouseMove += new MouseEventHandler(RangePicker_MouseMove);
            MinimumSize = new Size(184, fixedHeight);
            ForeColor = Color.ForestGreen;
            font = new Font("Arial", 16);
            Size = MinimumSize;
        }
        

        /// <summary>
        /// On Paint event do all the rendering
        /// </summary>
        void RangePicker_Paint(object sender, PaintEventArgs e)
        {
            VisualStyleRenderer trackRenderer = new VisualStyleRenderer(VisualStyleElement.TrackBar.Track.Normal);
            VisualStyleRenderer minThumbRenderer = new VisualStyleRenderer(VisualStyleElement.TrackBar.ThumbTop.Disabled);
            VisualStyleRenderer maxThumbRenderer = new VisualStyleRenderer(VisualStyleElement.TrackBar.ThumbTop.Disabled);

            if (Focused)
            {
                minThumbRenderer = new VisualStyleRenderer(VisualStyleElement.TrackBar.ThumbTop.Focused);
                maxThumbRenderer = new VisualStyleRenderer(VisualStyleElement.TrackBar.ThumbTop.Focused);
            }

            if (movingMode == MovingMode.MovingMin)
            {
                minThumbRenderer = new VisualStyleRenderer(VisualStyleElement.TrackBar.ThumbTop.Hot);
            }
            else if (movingMode == MovingMode.MovingMax)
            {
                maxThumbRenderer = new VisualStyleRenderer(VisualStyleElement.TrackBar.ThumbTop.Hot);
            }


            //paint background in transparent
            e.Graphics.FillRectangle(Brushes.Transparent, ClientRectangle);

            //draw a black frame around our control
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);

            //render track
            Rectangle track;
            track = new Rectangle(ClientRectangle.X + thumbSize / 2, ClientRectangle.Height / 2, ClientRectangle.Width - thumbSize, trackHeight);
            trackRenderer.DrawBackground(e.Graphics, track);

            //paint selection range in selected colour
            SolidBrush fillBrush = new SolidBrush(FillColor);
            Rectangle selectionRect = new Rectangle(((selectedMin - Min) * (Width - thumbSize) / (Max - Min) + thumbSize / 2), ClientRectangle.Height / 2, ((selectedMax - selectedMin) * (Width - thumbSize) / (Max - Min)), trackHeight);
            e.Graphics.FillRectangle(fillBrush, selectionRect);

            //draw ticks
            for (int i = 0; i <= Math.Abs(Max) + Math.Abs(Min); i++)
            {
                Rectangle tick = new Rectangle((int)Math.Round(track.X + i * (double)track.Width / (Max + Math.Abs(Min)), 0), track.Y, 1, trackHeight);
                e.Graphics.DrawRectangle(Pens.Black, tick);
            }

            //render thumbs
            Rectangle thumbMin = new Rectangle(selectionRect.X - thumbSize / 2, ClientRectangle.Height / 2 + thumbTrackDistance, thumbSize, thumbSize);
            Rectangle thumbMax = new Rectangle(selectionRect.X + selectionRect.Width - thumbSize / 2, ClientRectangle.Height / 2 + thumbTrackDistance, thumbSize, thumbSize);
            minThumbRenderer.DrawBackground(e.Graphics, thumbMin);
            maxThumbRenderer.DrawBackground(e.Graphics, thumbMax);

            SolidBrush fontBrush = new SolidBrush(ForeColor);
            e.Graphics.DrawString(SelectedMin.ToString(), font, fontBrush, ClientRectangle.Left, ClientRectangle.Top);
            e.Graphics.DrawString(SelectedMax.ToString(), font, fontBrush, ClientRectangle.Right - SelectedMax.ToString().Length * font.Size - 15, ClientRectangle.Top);

        }

        /// <summary>
        /// On MouseDown event check if user clicked on thumb area and decide which one to move
        /// </summary>
        void RangePicker_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y >= ClientRectangle.Height / 2 + thumbTrackDistance && e.Y <= ClientRectangle.Height / 2 + thumbTrackDistance + thumbSize)
            {
                //check where the user clicked so we can decide which thumb to move
                int Value = (SelectedMax - SelectedMin) / 2;
                int pointedValue = Min + (e.X - thumbSize / 2) * (Max - Min) / (Width - thumbSize);
                int distValue = Math.Abs(pointedValue - Value);
                int distMin = Math.Abs(pointedValue - SelectedMin);
                int distMax = Math.Abs(pointedValue - SelectedMax);
                int minDist = Math.Min(distValue, Math.Min(distMin, distMax));
                if (minDist == distMin)
                {
                    movingMode = MovingMode.MovingMin;
                }
                else if (minDist == distMax)
                {
                    movingMode = MovingMode.MovingMax;
                }    
                thumbDragged = true;
            }
            //call this to refreh the position of the selected thumb
            RangePicker_MouseMove(sender, e);
        }

        /// <summary>
        /// On MouseMove event check the constraints for dragging the thumbs
        /// </summary>
        void RangePicker_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (thumbDragged)
            {
                int pointedValue = Min + (e.X - thumbSize / 2) * (Max - Min) / (Width - thumbSize);

                if (movingMode == MovingMode.MovingMax && pointedValue > max)
                {
                    pointedValue = max;
                }

                if (movingMode == MovingMode.MovingMax && pointedValue < selectedMin)
                {
                    pointedValue = selectedMin;
                }

                if (movingMode == MovingMode.MovingMin && pointedValue < min)
                {
                    pointedValue = min;
                }

                if (movingMode == MovingMode.MovingMin && pointedValue > selectedMax)
                {
                    pointedValue = selectedMax;
                }


                if (movingMode == MovingMode.MovingMin)
                    SelectedMin = pointedValue;
                else if (movingMode == MovingMode.MovingMax)
                    SelectedMax = pointedValue;
            }
        }

        /// <summary>
        /// When mouse button is unpressed we want to reset thump drag related things
        /// </summary>
        private void RangePicker_MouseUp(object sender, MouseEventArgs e)
        {
            thumbDragged = false;
            movingMode = MovingMode.MovingNone;
            Invalidate();
        }


        /// <summary>
        /// When mouse leaves our contol we want to repaint it
        /// </summary>
        private void RangePicker_Leave(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// To know which thumb is moving
        /// </summary>
        enum MovingMode 
        {
            MovingMin,
            MovingMax,
            MovingNone
        }

        MovingMode movingMode = MovingMode.MovingNone;

        /// <summary>
        /// Disable resize on Y axis
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="specified"></param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, fixedHeight, specified);
        }
    }

}