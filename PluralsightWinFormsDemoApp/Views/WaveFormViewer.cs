using System;
using System.Drawing;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class WaveFormViewer : UserControl
    {
        private float[] peaks;
        private Brush backBrush;
        private Pen waveformPen;
        private int positionMilliseconds;
        private Rectangle thumbRect;
        private bool isDragging;

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

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (isDragging)
            {
                InternalSetPosition(PixelToMillisecond(hScrollBar1.Value + e.X));
            }
            else
            {
                Cursor = IsDraggable(new Point(e.X, e.Y)) ? Cursors.SizeWE : Cursors.Default;
            }
        }

        private int PixelToMillisecond(int pixel)
        {
            if (peaks == null || pixel < 0) return 0;
            pixel = Math.Min(pixel, peaks.Length);
            return pixel*10;
        }

        private bool IsDraggable(Point pos)
        {
            if (thumbRect.Contains(pos))
            {
                return true;
            }
            else if (pos.Y > thumbRect.Bottom)
            {
                var pX = GetPositionX();
                if (pos.X >= pX - 5 && pos.X <= pX + 5)
                {
                    return true;
                }
            }
            return false;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                if (isDragging)
                {
                    isDragging = false;
                    Cursor = Cursors.Default;
                    OnPositionChanged();
                }
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                if (IsDraggable(new Point(mouseEventArgs.X, mouseEventArgs.Y)))
                {
                    // start dragging
                    isDragging = true;
                    Cursor = Cursors.SizeWE;
                }
                else
                {
                    // reposition
                    var desiredPosition = hScrollBar1.Value + mouseEventArgs.X;
                    if (desiredPosition < peaks.Length)
                    {
                        PositionMilliseconds = PixelToMillisecond(desiredPosition);
                        OnPositionChanged();
                    }
                }
            }
            else if (mouseEventArgs.Button == MouseButtons.Right)
            {
                var desiredPosition = hScrollBar1.Value + mouseEventArgs.X;
                if (desiredPosition < peaks.Length)
                {
                    PositionMilliseconds = PixelToMillisecond(desiredPosition);
                    OnPositionChanged();
                    var f = new NoteForm();
                    f.Location = PointToScreen(new Point(mouseEventArgs.X, hScrollBar1.Top));
                    f.Show(this);
                    f.FormClosed += OnNoteFormClosed;
                }
            }
        }

        private void OnNoteFormClosed(object sender, FormClosedEventArgs formClosedEventArgs)
        {
            var nf = (NoteForm) sender;
            nf.FormClosed -= OnNoteFormClosed;
            if (!String.IsNullOrEmpty(nf.Note))
                OnNoteCreated(new NoteArgs(nf.Note, TimeSpan.FromMilliseconds(PositionMilliseconds)));

        }

        public event EventHandler<NoteArgs> NoteCreated;

        protected virtual void OnNoteCreated(NoteArgs e)
        {
            EventHandler<NoteArgs> handler = NoteCreated;
            if (handler != null) handler(this, e);
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
                if (positionMilliseconds != value && !isDragging)
                {                    
                    InternalSetPosition(value);
                }

            }
        }

        private void InternalSetPosition(int value)
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

        private static readonly Pen positionPen = new Pen(Color.FromArgb(80,80,80), 2);
        private static readonly Brush positionBrush = new SolidBrush(Color.FromArgb(229, 215, 200));

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

            var timeString = TimeSpan.FromMilliseconds(PositionMilliseconds).ToString(@"hh\:mm\:ss");
            var timeWidth = e.Graphics.MeasureString(timeString, Font);

            var positionX =  GetPositionX();
            e.Graphics.DrawLine(positionPen, positionX, 0, positionX, Height);

            this.thumbRect = new Rectangle(positionX, 1, (int)timeWidth.Width + 6, 15);

            e.Graphics.FillRectangle(positionBrush, thumbRect);
            e.Graphics.DrawRectangle(positionPen, thumbRect);
            var timeRect = thumbRect;
            timeRect.Inflate(-2,-2);
            e.Graphics.DrawString(timeString, Font, Brushes.Black, timeRect);
        }

        private int GetPositionX()
        {
            return (positionMilliseconds / 10) - hScrollBar1.Value;
        }
    }


}
