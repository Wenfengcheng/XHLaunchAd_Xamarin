using System;
using FLAnimatedImage;
using UIKit;
using Foundation;

namespace FLAnimatedImage.Sample
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            FLAnimatedImage image = new FLAnimatedImage(NSData.FromUrl(NSUrl.FromString("https://upload.wikimedia.org/wikipedia/commons/2/2c/Rotating_earth_%28large%29.gif")));
            FLAnimatedImageView imageView = new FLAnimatedImageView()
            {
                AnimatedImage = image,
                Frame = new CoreGraphics.CGRect(100,100,200,200)
            };
            this.View.AddSubview(imageView);
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
