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

namespace XFMoreGesture.Droid.Helpers
{
    public class FancyGestureListener : GestureDetector.SimpleOnGestureListener
    {
        public override void OnLongPress(MotionEvent e)
        {
            Console.WriteLine("擴充手勢事件 : ----->> OnLongPress");
            base.OnLongPress(e);
        }

        public override bool OnDoubleTap(MotionEvent e)
        {
            Console.WriteLine("擴充手勢事件 : ----->> OnDoubleTap");
            return base.OnDoubleTap(e);
        }

        public override bool OnDoubleTapEvent(MotionEvent e)
        {
            Console.WriteLine("擴充手勢事件 : ----->> OnDoubleTapEvent");
            return base.OnDoubleTapEvent(e);
        }

        public override bool OnSingleTapUp(MotionEvent e)
        {
            Console.WriteLine("擴充手勢事件 : ----->> OnSingleTapUp");
            return base.OnSingleTapUp(e);
        }

        public override bool OnDown(MotionEvent e)
        {
            Console.WriteLine("擴充手勢事件 : ----->> OnDown");
            return base.OnDown(e);
        }

        public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            Console.WriteLine("擴充手勢事件 : ----->> OnFling");
            return base.OnFling(e1, e2, velocityX, velocityY);
        }

        public override bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            Console.WriteLine("擴充手勢事件 : ----->> OnScroll");
            return base.OnScroll(e1, e2, distanceX, distanceY);
        }

        public override void OnShowPress(MotionEvent e)
        {
            Console.WriteLine("擴充手勢事件 : ----->> OnShowPress");
            base.OnShowPress(e);
        }

        public override bool OnSingleTapConfirmed(MotionEvent e)
        {
            Console.WriteLine("擴充手勢事件 : ----->> OnSingleTapConfirmed");
            return base.OnSingleTapConfirmed(e);
        }
    }
}