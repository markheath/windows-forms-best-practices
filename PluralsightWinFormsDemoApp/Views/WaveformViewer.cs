using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class WaveformViewer : UserControl
    {
        private float[] peaks;
        private Brush backBrush;
        private Pen waveformPen;

        public WaveformViewer()
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
                for (int x = 0; x < peaks.Length && x < Width; x++)
                {
                    var height = peaks[x]*Height;
                    var top = (Height - height)/2;
                    e.Graphics.DrawLine(waveformPen, x, top, x, top + height);
                }
            }
        }
    }
}
