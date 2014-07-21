using System.Drawing;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class WaveFormViewer : UserControl
    {
        private float[] peaks;
        private Brush backBrush;
        private Pen waveformPen;

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
        }
    }
}
