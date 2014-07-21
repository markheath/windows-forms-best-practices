using System;
using System.Drawing;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class WaveFormViewer : UserControl
    {
        private float[] peaks;
        private Brush backBrush;
        private Pen waveformPen;
        private int positionMilliseconds;

        public WaveFormViewer()
        {
            InitializeComponent();
            DoubleBuffered = true;
            hScrollBar1.Scroll += HScrollBar1OnScroll;
            hScrollBar1.Enabled = false;
            MouseDown += OnMouseDown;
        }

        public event EventHandler PositionChanged;

        protected virtual void OnPositionChanged()
        {
            EventHandler handler = PositionChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void OnMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                var desiredPosition = hScrollBar1.Value + mouseEventArgs.X;
                if (desiredPosition < peaks.Length)
                {
                    PositionMilliseconds = desiredPosition * 10;
                    OnPositionChanged();
                }
            }
        }

        private void HScrollBar1OnScroll(object sender, ScrollEventArgs scrollEventArgs)
        {
            this.Invalidate();
        }

        public void SetPeaks(float[] newPeaks)
        {
            peaks = newPeaks;            
            CalculateScrollBar();
            hScrollBar1.Enabled = peaks!= null;
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            
            base.OnResize(e);
            CalculateScrollBar();
        }

        private void CalculateScrollBar()
        {
            if (peaks != null)
            {
                hScrollBar1.Maximum = peaks.Length;
                hScrollBar1.LargeChange = Width;
                hScrollBar1.SmallChange = Width/10;
            }
        }

        public int PositionMilliseconds
        {
            get { return positionMilliseconds; }
            set
            {
                if (positionMilliseconds != value)
                {
                    positionMilliseconds = value;
                    var xPosition = positionMilliseconds/10;
                    if (xPosition < hScrollBar1.Value)
                    {
                        hScrollBar1.Value = xPosition;
                    }
                    else if (xPosition > hScrollBar1.Value + Width)
                    {
                        hScrollBar1.Value = xPosition;
                    }
                    Invalidate();
                }

            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (peaks != null)
            {
                backBrush = backBrush ?? new SolidBrush(BackColor);
                waveformPen = waveformPen ?? new Pen(ForeColor);

                var startPeak = hScrollBar1.Value;
                

                e.Graphics.FillRectangle(backBrush, ClientRectangle);
                for (int x = 0; x < Width && (startPeak + x < peaks.Length) ; x++)
                {
                    var availableHeight = Height - hScrollBar1.Height;
                    var height = peaks[startPeak + x] * availableHeight;
                    var top = (availableHeight - height)/2;
                    e.Graphics.DrawLine(waveformPen, x, top, x, top + height);
                }
            }

            var positionX = (positionMilliseconds / 10) - hScrollBar1.Value;
            e.Graphics.DrawLine(Pens.LightGray, positionX, 0, positionX, Height);
            e.Graphics.DrawLine(Pens.DarkGray, positionX + 1, 0, positionX + 1, Height);

            var thumbRect = new Rectangle(positionX, 0, 60, 15);

            e.Graphics.FillRectangle(Brushes.LightGray, thumbRect);
            e.Graphics.DrawRectangle(Pens.DarkGray, thumbRect);
            thumbRect.Inflate(-2,-2);
            e.Graphics.DrawString(TimeSpan.FromMilliseconds(PositionMilliseconds).ToString(), Font, Brushes.Black, thumbRect);
        }
    }
}
