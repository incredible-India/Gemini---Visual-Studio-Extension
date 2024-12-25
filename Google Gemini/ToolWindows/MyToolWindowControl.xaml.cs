using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Google_Gemini
{
    public partial class MyToolWindowControl : UserControl
    {
        public MyToolWindowControl()
        {
            InitializeComponent();
            InitializeAsync();
        }


        private async void InitializeAsync()
        {
            Random rnd = new Random();
            string subFolder = rnd.Next().ToString();
            var env = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(userDataFolder: Path.Combine(Path.GetTempPath(), $"{Environment.UserName}", subFolder));
            await GoogleGemini.EnsureCoreWebView2Async(env);
            var request = GoogleGemini.CoreWebView2.Environment.CreateWebResourceRequest("https://gemini.google.com/app?hl=en-IN", "GET", null, null);
            GoogleGemini.CoreWebView2.NavigateWithWebResourceRequest(request);
        }
    }
}