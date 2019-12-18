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
        
        public static NSLayoutConstraint SetLeadingMargin(this UIView view, UIView parent, float margin = 0)
        {
            var la = view.LeadingAnchor.ConstraintEqualTo(parent.LeadingAnchor, margin);
            la.Active = true;
            return la;
        }
        
        public static NSLayoutConstraint SetHeight(this UIView view, float height)
        {
            var la = view.HeightAnchor.ConstraintEqualTo(height);
            la.Active = true;
            return la;
        }
        
        public static NSLayoutConstraint SetWidth(this UIView view, float width)
        {
            var la = view.WidthAnchor.ConstraintEqualTo(width);
            la.Active = true;
            return la;
        }
        
        public static void SetSize(this UIView view, float size)
        {
            view.SetHeight(size);
            view.SetWidth(size);
        }

        public static NSLayoutConstraint SetTrailingMargin(this UIView view, UIView parent, float margin = 0)
        {
            var la = view.TrailingAnchor.ConstraintEqualTo(parent.TrailingAnchor, -margin);
            la.Active = true;
            return la;
        }
        
        public static NSLayoutConstraint SetTopMargin(this UIView view, UIView parent, float margin = 0)
        {
            var la = view.TopAnchor.ConstraintEqualTo(parent.TopAnchor, margin);
            la.Active = true;
            return la;
        }
        
        public static NSLayoutConstraint SetBottomMargin(this UIView view, UIView parent, float margin = 0)
        {
            var la = view.BottomAnchor.ConstraintEqualTo(parent.BottomAnchor, -margin);
            la.Active = true;
            return la;
        }
        
        public static NSLayoutConstraint SetBottomToTopMargin(this UIView view, UIView to, float margin = 0)
        {
            var la = view.BottomAnchor.ConstraintEqualTo(to.TopAnchor, -margin);
            la.Active = true;
            return la;
        }
        
        public static NSLayoutConstraint SetLeadingToTrailingMargin(this UIView view, UIView to, float margin = 0)
        {
            var la = view.LeadingAnchor.ConstraintEqualTo(to.TrailingAnchor, margin);
            la.Active = true;
            return la;
        }
        
        public static NSLayoutConstraint CenterYTo(this UIView view, UIView to)
        {
            var la = view.CenterYAnchor.ConstraintEqualTo(to.CenterYAnchor);
            la.Active = true;
            return la;
        }
        
        public static NSLayoutConstraint CenterXTo(this UIView view, UIView to)
        {
            var la = view.CenterXAnchor.ConstraintEqualTo(to.CenterXAnchor);
            la.Active = true;
            return la;
        }
        
        public static void CenterTo(this UIView view, UIView to)
        {
            view.CenterXTo(to);
            view.CenterYTo(to);
        }
        
        public static NSLayoutConstraint SetTrailingToLeadingMargin(this UIView view, UIView to, float margin = 0)
        {
            var la = view.TrailingAnchor.ConstraintEqualTo(to.LeadingAnchor, -margin);
            la.Active = true;
            return la;
        }
        
        public static NSLayoutConstraint SetTopToBottomMargin(this UIView view, UIView to, float margin = 0)
        {
            var la = view.TopAnchor.ConstraintEqualTo(to.BottomAnchor, margin);
            la.Active = true;
            return la;
        }
    }
}
