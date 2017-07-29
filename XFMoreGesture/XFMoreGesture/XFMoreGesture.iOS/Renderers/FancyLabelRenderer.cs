using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(XFMoreGesture.CustomControls.FancyLabel), typeof(XFMoreGesture.iOS.Renderers.FancyLabelRenderer))]
namespace XFMoreGesture.iOS.Renderers
{
    class FancyLabelRenderer :  LabelRenderer
    {
        UILongPressGestureRecognizer longPressGestureRecognizer;
        UIPinchGestureRecognizer pinchGestureRecognizer;
        UIPanGestureRecognizer panGestureRecognizer;
        UISwipeGestureRecognizer swipeGestureRecognizer;
        UIRotationGestureRecognizer rotationGestureRecognizer; protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            longPressGestureRecognizer = new UILongPressGestureRecognizer(() => Console.WriteLine("擴充手勢事件 : ----->> Long Press"));
            pinchGestureRecognizer = new UIPinchGestureRecognizer(() => Console.WriteLine("擴充手勢事件 : ----->> Pinch"));
            panGestureRecognizer = new UIPanGestureRecognizer(() => Console.WriteLine("擴充手勢事件 : ----->> Pan"));
            swipeGestureRecognizer = new UISwipeGestureRecognizer(() => Console.WriteLine("擴充手勢事件 : ----->> Swipe"));
            rotationGestureRecognizer = new UIRotationGestureRecognizer(() => Console.WriteLine("擴充手勢事件 : ----->> Rotation"));

            if (e.NewElement == null)
            {
                if (longPressGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(longPressGestureRecognizer);
                }
                if (pinchGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(pinchGestureRecognizer);
                }
                if (panGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(panGestureRecognizer);
                }
                if (swipeGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(swipeGestureRecognizer);
                }
                if (rotationGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(rotationGestureRecognizer);
                }
            }

            if (e.OldElement == null)
            {
                this.AddGestureRecognizer(longPressGestureRecognizer);
                this.AddGestureRecognizer(pinchGestureRecognizer);
                this.AddGestureRecognizer(panGestureRecognizer);
                this.AddGestureRecognizer(swipeGestureRecognizer);
                this.AddGestureRecognizer(rotationGestureRecognizer);
            }
        }
    }
}