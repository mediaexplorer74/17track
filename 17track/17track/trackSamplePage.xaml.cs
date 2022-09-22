using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace trackSample
{
    public partial class trackSamplePage : ContentPage
    {
        public trackSamplePage()
        {
            InitializeComponent();
            webView.Source = LoadHTMLFileFromResource();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            webView.Eval(string.Format("doTrack('{0}')", txtRastrear.Text));
        }


        HtmlWebViewSource LoadHTMLFileFromResource()
        {
            var source = new HtmlWebViewSource();

            var assembly = typeof(trackSamplePage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("trackSample.Track.html");
            using (var reader = new StreamReader(stream))
            {
                source.Html = reader.ReadToEnd();
            }
            return source;
        }
    }
}
