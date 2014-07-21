using System;
using System.Drawing;
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
        }

        public void SetPeaks(float[] newPeaks)
        {
            peaks = newPeaks;
            Invalidate();
        }

        public int PositionMilliseconds
        {
            get { return positionMilliseconds; }
            set
            {
                if (positionMilliseconds != value)
                {
                    positionMilliseconds = value;
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
                
                e.Graphics.FillRectangle(backBrush, ClientRectangle);
                for (int x = 0; x < peaks.Length; x++)
                {
                    var height = peaks[x]*Height;
                    var top = (Height - height)/2;
                    e.Graphics.DrawLine(waveformPen, x, top, x, top + height);
                }


            }

            var positionX = positionMilliseconds / 10;
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
