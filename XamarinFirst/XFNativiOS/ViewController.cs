using System;

using UIKit;
using XFShare;

namespace XFNativiOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            button.TouchUpInside += (s, e) =>
            {
                //label.Text = "XF:"+textField.Text;
                ShareRules fooShareRules = new ShareRules();
                label.Text = fooShareRules.CalString(textField.Text);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}