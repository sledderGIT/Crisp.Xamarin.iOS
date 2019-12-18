# Crisp.Xamarin.iOS
Crisp for Xamarin iOS

To use crisp in your iOS project just initialize it in your 
AppDelegate FinishedLaunching method

Crisp.Instance.Initialize("your_id");

And add the view to your VC

public class SupportView: UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var crispView = new CrispView(View.Bounds);
            View.AddSubview(crispView);
            crispView.SetHorizontalMargins(View);
            crispView.SetVerticalMargins(View);
        }
    }

