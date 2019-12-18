using UIKit;

namespace iOS.Extensions
{
    public static class LayoutExtensions
    {
        public static void SetHorizontalMargins(this UIView view, UIView parent, float margin = 0)
        {
            view.LeadingAnchor.ConstraintEqualTo(parent.LeadingAnchor, margin).Active = true;
            view.TrailingAnchor.ConstraintEqualTo(parent.TrailingAnchor, -margin).Active = true;
        }
        
        public static void SetVerticalMargins(this UIView view, UIView parent, float margin = 0)
        {
            view.TopAnchor.ConstraintEqualTo(parent.TopAnchor, margin).Active = true;
            view.BottomAnchor.ConstraintEqualTo(parent.BottomAnchor, -margin).Active = true;
        }
    }
}
