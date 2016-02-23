using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PluralsightWinFormsDemoApp.Views
{
    /// <summary>
    /// Interaction logic for WpfWaveformControl.xaml
    /// </summary>
    public partial class WpfWaveformControl : UserControl
    {
        private int positionInSeconds = 0;
        private bool isScrolling;

        public WpfWaveformControl()
        {
            InitializeComponent();
            peaksCanvas.MouseDown += LinesCanvasOnMouseDown;
            peaksCanvas.MouseLeftButtonUp += PeaksCanvasOnMouseLeftButtonUp;
            peaksCanvas.MouseRightButtonUp += PeaksCanvasOnMouseRightButtonUp;
            NotePopup.Closed += NotePopupOnClosed;
            nowBarCanvas.MouseEnter += NowBarCanvasOnMouseEnter;
            nowBarCanvas.MouseLeave += NowBarCanvasOnMouseLeave;
            peaksCanvas.MouseMove += PeaksCanvasOnMouseMove;
        }

        public event EventHandler PositionUpdated;

        protected virtual void OnPositionUpdated()
        {
            var handler = PositionUpdated;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void PeaksCanvasOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (isScrolling)
            {
                isScrolling = false;
                Cursor = Cursors.Arrow;
                OnPositionUpdated();
            }
        }

        private void PeaksCanvasOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (isScrolling)
            {
                var x = mouseEventArgs.GetPosition(linesCanvas).X;
                PositionInSeconds = (int)x;
            }
        }

        private void NowBarCanvasOnMouseLeave(object sender, MouseEventArgs mouseEventArgs)
        {
            Cursor = Cursors.Arrow;
        }

        private void NowBarCanvasOnMouseEnter(object sender, MouseEventArgs mouseEventArgs)
        {
            Cursor = Cursors.SizeWE;
        }

        private void NotePopupOnClosed(object sender, EventArgs routedEventArgs)
        {
            if (!string.IsNullOrEmpty(noteTextBox.Text))
            {
                OnNoteCreated(new NoteArgs(noteTextBox.Text, TimeSpan.FromSeconds(PositionInSeconds)));
            }
        }

        private void PeaksCanvasOnMouseRightButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var x = mouseButtonEventArgs.GetPosition(linesCanvas).X;
            
            NotePopup.PlacementRectangle = new Rect(x, 0, 1, 60);
            NotePopup.StaysOpen = false;
            noteTextBox.Text = "";
            NotePopup.IsOpen = true;
            // reason why the popup form doesn't really work properly
            //http://connect.microsoft.com/VisualStudio/feedback/details/707184/textbox-in-pop-up-window-cant-get-keyboard-focus-after-some-controls-in-windowsformhost-lost-focus
            
            mouseButtonEventArgs.Handled = true;
        }

        private void LinesCanvasOnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (mouseButtonEventArgs.ChangedButton == MouseButton.Left && !NotePopup.IsOpen)
            {
                if (Cursor == Cursors.SizeWE)
                {
                    isScrolling = true;
                }
                else
                {
                    var x = mouseButtonEventArgs.GetPosition(linesCanvas).X;
                    PositionInSeconds = (int)x;
                    OnPositionUpdated();
                }
            }
        }

        public int PositionInSeconds
        {
            get { return positionInSeconds; }
            set
            {
                if (positionInSeconds != value)
                {
                    positionInSeconds = value;  
                    Canvas.SetLeft(nowBarCanvas, value-3);
                    nowTime.Text = TimeSpan.FromSeconds(value).ToString(@"hh\:mm\:ss");
                }
            }
        }

        public void SetPeaks(float[] peaks)
        {
            if (peaks == null) peaks = new float[0];
            peaksCanvas.Width = peaks.Length;
            linesCanvas.Children.Clear();
            const int peaksHeight = 60;
            var lines = peaks.Select((peak, n) =>
                                     {

                                         var lineHeight = peaksHeight*peak;
                                         var lineTop = (peaksHeight - lineHeight)/2;
                                         return new Line()
                                                {
                                                    Stroke = Brushes.DarkOliveGreen,
                                                    StrokeThickness = 1,
                                                    X1 = n,
                                                    Y1 = lineTop,
                                                    X2 = n,
                                                    Y2 = lineTop + lineHeight,
                                                    SnapsToDevicePixels = true
                                                };
                                     });
            foreach (var l in lines)
            {
                linesCanvas.Children.Add(l);
            }
        }

        private void OnPopupButtonClick(object sender, RoutedEventArgs e)
        {
            NotePopup.IsOpen = false;
        }

        public event EventHandler<NoteArgs> NoteCreated;

        protected virtual void OnNoteCreated(NoteArgs e)
        {
            EventHandler<NoteArgs> handler = NoteCreated;
            if (handler != null) handler(this, e);
        }
    }
}
