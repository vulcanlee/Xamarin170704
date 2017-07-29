using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFMoreGesture.Droid.Helpers;


[assembly: ExportRenderer(typeof(XFMoreGesture.CustomControls.FancyLabel), typeof(XFMoreGesture.Droid.Renderers.FancyLabelRenderer))]
namespace XFMoreGesture.Droid.Renderers
{
    class FancyLabelRenderer : LabelRenderer
    {
        private readonly FancyGestureListener _listener;
        private readonly GestureDetector _detector;

        public FancyLabelRenderer()
        {
            _listener = new FancyGestureListener();
            _detector = new GestureDetector(_listener);

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                this.GenericMotion -= HandleGenericMotion;
                this.Touch -= HandleTouch;
            }

            if (e.OldElement == null)
            {
                this.GenericMotion += HandleGenericMotion;
                this.Touch += HandleTouch;
            }
        }

        void HandleTouch(object sender, TouchEventArgs e)
        {
            _detector.OnTouchEvent(e.Event);
        }

        void HandleGenericMotion(object sender, GenericMotionEventArgs e)
        {
            _detector.OnTouchEvent(e.Event);
        }
    }
}