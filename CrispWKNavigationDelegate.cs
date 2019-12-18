using System;
using CoreFoundation;
using WebKit;

namespace Crisp.iOS
{
    public class CrispWKNavigationDelegate: WKNavigationDelegate
    {
        public override void DidCommitNavigation(WKWebView webView, WKNavigation navigation)
        {
            CrispView.IsLoaded = true;
            DispatchQueue.MainQueue.DispatchAsync(CrispView.FlushQueue);
        }

        public override void DecidePolicy(WKWebView webView, WKNavigationAction navigationAction, Action<WKNavigationActionPolicy> decisionHandler)
        {
            decisionHandler(WKNavigationActionPolicy.Allow);
        }
    }
}