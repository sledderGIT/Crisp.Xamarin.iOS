using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Extensions;
using Foundation;
using UIKit;
using WebKit;

namespace Crisp.iOS
{
    public class CrispView: UIView
    {
        private static WKWebView _webView;
        private static readonly Queue<string> CommandQueue = new Queue<string>();
        public static bool IsLoaded { get; set; }
        
        public CrispView()
        {
            Initialize();
        }

        public CrispView(CGRect frame) : base(frame)
        {
            Initialize();
        }

        private void Initialize()
        {
            _webView = new WKWebView(Frame, new WKWebViewConfiguration())
            {
                NavigationDelegate = new CrispWKNavigationDelegate(), 
                UIDelegate = new CrispWKUIDelegate(),
            };
            AddSubview(_webView);
            _webView.SetVerticalMargins(this);
            _webView.SetHorizontalMargins(this);
            Load();
            _webView.ScrollView.ScrollEnabled = false;
        }

        public override void RemoveFromSuperview()
        {
            IsLoaded = false;
            _webView?.RemoveFromSuperview();
            _webView = null;
            base.RemoveFromSuperview();
        }

        public static void Load()
        {
            if (string.IsNullOrEmpty(Crisp.Instance.WebsiteId))
            {
                Console.WriteLine(@"=====================================");
                Console.WriteLine(@"Warning. Please initiate the Crisp SDK from your AppDelegate");
                Console.WriteLine(@"=====================================");
                return;
            }
            var crispUrl = $"https://go.crisp.chat/chat/embed/?website_id={Crisp.Instance.WebsiteId}";
            if (!string.IsNullOrEmpty(Crisp.Instance.TokenId))
            {
                crispUrl += $"&token_id" + Crisp.Instance.TokenId;
            }
            if (!string.IsNullOrEmpty(Crisp.Instance.Locale))
            {
                crispUrl += $"&locale" + Crisp.Instance.Locale;
            }

            _webView.LoadRequest(new NSUrlRequest(new NSUrl(crispUrl)));
        }

        public static void Execute(string script)
        {
            CommandQueue.Enqueue(script);
        
            if (IsLoaded)
            {
                FlushQueue();
            }
        }

        public static void FlushQueue()
        {
            while (CommandQueue.Any())
            {
                CallJavascript(CommandQueue.Dequeue());
            }
        }

        public static void CallJavascript(string script)
        {
            _webView.EvaluateJavaScript(script, null);
        }
    }
}
