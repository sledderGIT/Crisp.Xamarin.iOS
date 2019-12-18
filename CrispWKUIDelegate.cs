using UIKit;
using WebKit;

namespace Crisp.iOS
{
    public class CrispWKUIDelegate : WKUIDelegate
    {
        public override WKWebView CreateWebView(WKWebView webView, WKWebViewConfiguration configuration, 
            WKNavigationAction navigationAction, WKWindowFeatures windowFeatures)
        {
            if (navigationAction.TargetFrame == null)
            {
                var url = navigationAction.Request.Url;
                var descr = url.Description.ToLower();
                if (descr.Contains("http://") ||
                    descr.Contains("https://") ||
                    descr.Contains("mailto:"))
                {
                    UIApplication.SharedApplication.OpenUrl(url);
                }
            }

            return null;
        }
    }
}