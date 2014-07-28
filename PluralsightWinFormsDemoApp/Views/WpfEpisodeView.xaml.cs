using System;
using System.Linq;
using System.Windows.Controls;

namespace PluralsightWinFormsDemoApp.Views
{
    /// <summary>
    /// Interaction logic for WpfEpisodeView.xaml
    /// </summary>
    public partial class WpfEpisodeView : UserControl
    {
        public WpfEpisodeView()
        {
            InitializeComponent();
            DescriptionWebBrowser.NavigateToString("<p>This is a description in a paragraph.</p>" +
                                                   "<p>The second paragraph has <b>bold</b>, <i>italics</i> and <a href=\"http://markheath.net\">a link</a>");
            var r = new Random();
            var peaks = Enumerable.Range(1, 3000).Select(n => r.NextDouble()).Select(d => (float)d).ToArray();
            WaveformControl.SetPeaks(peaks);

        }


    }
}
